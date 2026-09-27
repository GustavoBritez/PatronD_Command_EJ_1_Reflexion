using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using BE;
using BLL;
using Servicio;

namespace Command
{
    public partial class Form1 : Form
    {
        // 1. Capa BE (Entidad del negocio)
        private Cuenta _cuenta = null!;

        // 2. Capa BLL (Receiver / Lógica de negocio)
        private CuentaBLL _cuentaBLL = null!;

        // 3. Capa Servicio (Invoker / Administrador del Patrón Command)
        private GestorComandos _gestorComandos = null!;

        // Último comando ejecutado (para inspección por Reflection)
        private ICommand? _ultimoComando = null;

        // Lista para la grilla de auditoría
        private readonly BindingList<MovimientoRegistro> _bitacora = new();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Inicialización de componentes y capas
            _cuenta = new Cuenta("CC-00984-2026", "Juan Pérez", 5000.00m);
            _cuentaBLL = new CuentaBLL();
            _gestorComandos = new GestorComandos();

            // Configurar DataGridView de bitácora
            dgvMovimientos.DataSource = _bitacora;

            if (dgvMovimientos.Columns["Fecha"] != null)
                dgvMovimientos.Columns["Fecha"].DefaultCellStyle.Format = "HH:mm:ss";
            if (dgvMovimientos.Columns["Monto"] != null)
                dgvMovimientos.Columns["Monto"].DefaultCellStyle.Format = "C2";
            if (dgvMovimientos.Columns["SaldoResultante"] != null)
                dgvMovimientos.Columns["SaldoResultante"].DefaultCellStyle.Format = "C2";

            // 1. REFLECTION: Descubrimiento dinámico de comandos en el ensamblado
            CargarComandosPorReflection();

            // Seleccionar por defecto el primer elemento para el inspector de Reflection
            cboObjetosReflection.SelectedIndex = 0;

            ActualizarInterfaz();
        }

        #region Descubrimiento y Ejecución de Comandos por Reflection

        /// <summary>
        /// Utiliza FabricaComandos (que usa System.Reflection) para descubrir
        /// todos los tipos que implementan ICommand y llenar el ComboBox.
        /// </summary>
        private void CargarComandosPorReflection()
        {
            List<ComandoMetadata> comandosDescubiertos = FabricaComandos.ObtenerComandosDisponibles();

            cboComandos.DataSource = comandosDescubiertos;
            cboComandos.DisplayMember = "Nombre";

            if (cboComandos.Items.Count > 0)
            {
                cboComandos.SelectedIndex = 0;
            }
        }

        private void cboComandos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboComandos.SelectedItem is ComandoMetadata metadata)
            {
                lblDescripcionComando.Text = $"ℹ {metadata.Descripcion}";

                // Ajustar UI según el tipo de parámetro requerido leído por Reflection
                if (metadata.ParametroRequerido == TipoParametroRequerido.Porcentaje)
                {
                    lblParametro.Text = "Porcentaje (%):";
                    numParametro.Minimum = 1;
                    numParametro.Maximum = 100;
                    numParametro.Value = 10;
                    numParametro.DecimalPlaces = 1;
                }
                else
                {
                    lblParametro.Text = "Monto ($):";
                    numParametro.Minimum = 1;
                    numParametro.Maximum = 1000000;
                    numParametro.Value = 500;
                    numParametro.DecimalPlaces = 2;
                }
            }
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            if (cboComandos.SelectedItem is not ComandoMetadata metadata)
                return;

            try
            {
                decimal valorParametro = numParametro.Value;

                // 2. REFLECTION: Instanciación dinámica del comando resolviendo el constructor en tiempo de ejecución
                ICommand comando = FabricaComandos.CrearComando(metadata.Tipo, _cuenta, _cuentaBLL, valorParametro);

                // Ejecutar a través del Invoker (GestorComandos)
                _gestorComandos.Ejecutar(comando);
                _ultimoComando = comando;

                RegistrarEnBitacora(comando.Descripcion, comando.Monto, _cuenta.Saldo, "Ejecutado");
                ActualizarInterfaz();

                // Actualizar automáticamente el inspector de Reflection si está visible
                ActualizarInspectorReflection();
            }
            catch (Exception ex)
            {
                // Manejo de excepciones capturadas de la invocación o de la lógica de negocio
                string mensaje = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                MessageBox.Show(mensaje, "Error en la ejecución", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion

        #region Deshacer y Rehacer (Patrón Command)

        private void btnDeshacer_Click(object sender, EventArgs e)
        {
            try
            {
                ICommand? comandoDeshecho = _gestorComandos.Deshacer();

                if (comandoDeshecho != null)
                {
                    _ultimoComando = comandoDeshecho;
                    RegistrarEnBitacora($"[DESHACER] {comandoDeshecho.Descripcion}", comandoDeshecho.Monto, _cuenta.Saldo, "Deshecho");
                    ActualizarInterfaz();
                    ActualizarInspectorReflection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al deshacer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRehacer_Click(object sender, EventArgs e)
        {
            try
            {
                ICommand? comandoRehecho = _gestorComandos.Rehacer();

                if (comandoRehecho != null)
                {
                    _ultimoComando = comandoRehecho;
                    RegistrarEnBitacora($"[REHACER] {comandoRehecho.Descripcion}", comandoRehecho.Monto, _cuenta.Saldo, "Rehecho");
                    ActualizarInterfaz();
                    ActualizarInspectorReflection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al rehacer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Inspector de Objetos con System.Reflection

        private void btnInspeccionar_Click(object sender, EventArgs e)
        {
            ActualizarInspectorReflection();
        }

        private void cboObjetosReflection_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarInspectorReflection();
        }

        /// <summary>
        /// 3. REFLECTION: Inspecciona dinámicamente el objeto seleccionado en memoria,
        /// obteniendo sus propiedades, valores actuales y lista de métodos declarados.
        /// </summary>
        private void ActualizarInspectorReflection()
        {
            object? objetoAInspeccionar = cboObjetosReflection.SelectedIndex switch
            {
                0 => _cuenta,
                1 => _cuentaBLL,
                2 => _gestorComandos,
                3 => _ultimoComando,
                _ => null
            };

            if (objetoAInspeccionar == null)
            {
                dgvPropiedadesReflection.DataSource = null;
                lstMetodosReflection.Items.Clear();
                lstMetodosReflection.Items.Add("(No hay instancia disponible para inspeccionar)");
                return;
            }

            // Inspeccionar propiedades con Reflection (PropertyInfo)
            var listaPropiedades = InspectorReflection.InspeccionarPropiedades(objetoAInspeccionar);
            dgvPropiedadesReflection.DataSource = listaPropiedades;

            // Inspeccionar métodos con Reflection (MethodInfo)
            lstMetodosReflection.Items.Clear();
            var listaMetodos = InspectorReflection.InspeccionarMetodos(objetoAInspeccionar.GetType());
            foreach (var metodo in listaMetodos)
            {
                lstMetodosReflection.Items.Add(metodo);
            }
        }

        #endregion

        #region Métodos de Apoyo Visual

        private void ActualizarInterfaz()
        {
            // Saldo
            lblSaldo.Text = $"${_cuenta.Saldo:N2}";
            lblSaldo.ForeColor = _cuenta.Saldo >= 0 ? System.Drawing.Color.DarkGreen : System.Drawing.Color.DarkRed;

            // Estado de botones Deshacer / Rehacer
            btnDeshacer.Enabled = _gestorComandos.PuedeDeshacer;
            btnRehacer.Enabled = _gestorComandos.PuedeRehacer;

            // Visualizar el contenido de las pilas en memoria
            lstPilaDeshacer.Items.Clear();
            foreach (var cmd in _gestorComandos.ObtenerPilaDeshacer())
            {
                lstPilaDeshacer.Items.Add($"• {cmd.Descripcion}");
            }

            lstPilaRehacer.Items.Clear();
            foreach (var cmd in _gestorComandos.ObtenerPilaRehacer())
            {
                lstPilaRehacer.Items.Add($"• {cmd.Descripcion}");
            }
        }

        private void RegistrarEnBitacora(string operacion, decimal monto, decimal saldoResultante, string estado)
        {
            _bitacora.Insert(0, new MovimientoRegistro(operacion, monto, saldoResultante, estado));
        }

        #endregion
    }
}
