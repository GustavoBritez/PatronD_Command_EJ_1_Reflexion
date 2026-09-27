namespace Command
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        // Grupo Cuenta
        private System.Windows.Forms.GroupBox grpCuenta;
        private System.Windows.Forms.Label lblNumeroCuenta;
        private System.Windows.Forms.Label lblTitular;
        private System.Windows.Forms.Label lblSaldoTitulo;
        private System.Windows.Forms.Label lblSaldo;

        // Grupo Ejecución Dinámica por Reflection
        private System.Windows.Forms.GroupBox grpOperaciones;
        private System.Windows.Forms.Label lblComboTitulo;
        private System.Windows.Forms.ComboBox cboComandos;
        private System.Windows.Forms.Label lblDescripcionComando;
        private System.Windows.Forms.Label lblParametro;
        private System.Windows.Forms.NumericUpDown numParametro;
        private System.Windows.Forms.Button btnEjecutar;

        // Grupo Historial y Reversión
        private System.Windows.Forms.GroupBox grpHistorial;
        private System.Windows.Forms.Button btnDeshacer;
        private System.Windows.Forms.Button btnRehacer;
        private System.Windows.Forms.Label lblPilaDeshacer;
        private System.Windows.Forms.ListBox lstPilaDeshacer;
        private System.Windows.Forms.Label lblPilaRehacer;
        private System.Windows.Forms.ListBox lstPilaRehacer;

        // Tabs inferiores
        private System.Windows.Forms.TabControl tabControlPrincipal;
        private System.Windows.Forms.TabPage tabBitacora;
        private System.Windows.Forms.DataGridView dgvMovimientos;
        private System.Windows.Forms.TabPage tabReflection;
        private System.Windows.Forms.Label lblSeleccionarObjeto;
        private System.Windows.Forms.ComboBox cboObjetosReflection;
        private System.Windows.Forms.Button btnInspeccionar;
        private System.Windows.Forms.GroupBox grpPropiedadesRef;
        private System.Windows.Forms.DataGridView dgvPropiedadesReflection;
        private System.Windows.Forms.GroupBox grpMetodosRef;
        private System.Windows.Forms.ListBox lstMetodosReflection;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            grpCuenta = new System.Windows.Forms.GroupBox();
            lblSaldo = new System.Windows.Forms.Label();
            lblSaldoTitulo = new System.Windows.Forms.Label();
            lblTitular = new System.Windows.Forms.Label();
            lblNumeroCuenta = new System.Windows.Forms.Label();
            grpOperaciones = new System.Windows.Forms.GroupBox();
            btnEjecutar = new System.Windows.Forms.Button();
            numParametro = new System.Windows.Forms.NumericUpDown();
            lblParametro = new System.Windows.Forms.Label();
            lblDescripcionComando = new System.Windows.Forms.Label();
            cboComandos = new System.Windows.Forms.ComboBox();
            lblComboTitulo = new System.Windows.Forms.Label();
            grpHistorial = new System.Windows.Forms.GroupBox();
            lstPilaRehacer = new System.Windows.Forms.ListBox();
            lblPilaRehacer = new System.Windows.Forms.Label();
            lstPilaDeshacer = new System.Windows.Forms.ListBox();
            lblPilaDeshacer = new System.Windows.Forms.Label();
            btnRehacer = new System.Windows.Forms.Button();
            btnDeshacer = new System.Windows.Forms.Button();
            tabControlPrincipal = new System.Windows.Forms.TabControl();
            tabBitacora = new System.Windows.Forms.TabPage();
            dgvMovimientos = new System.Windows.Forms.DataGridView();
            tabReflection = new System.Windows.Forms.TabPage();
            grpMetodosRef = new System.Windows.Forms.GroupBox();
            lstMetodosReflection = new System.Windows.Forms.ListBox();
            grpPropiedadesRef = new System.Windows.Forms.GroupBox();
            dgvPropiedadesReflection = new System.Windows.Forms.DataGridView();
            btnInspeccionar = new System.Windows.Forms.Button();
            cboObjetosReflection = new System.Windows.Forms.ComboBox();
            lblSeleccionarObjeto = new System.Windows.Forms.Label();
            grpCuenta.SuspendLayout();
            grpOperaciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numParametro).BeginInit();
            grpHistorial.SuspendLayout();
            tabControlPrincipal.SuspendLayout();
            tabBitacora.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMovimientos).BeginInit();
            tabReflection.SuspendLayout();
            grpMetodosRef.SuspendLayout();
            grpPropiedadesRef.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPropiedadesReflection).BeginInit();
            SuspendLayout();
            // 
            // grpCuenta
            // 
            grpCuenta.Controls.Add(lblSaldo);
            grpCuenta.Controls.Add(lblSaldoTitulo);
            grpCuenta.Controls.Add(lblTitular);
            grpCuenta.Controls.Add(lblNumeroCuenta);
            grpCuenta.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            grpCuenta.Location = new System.Drawing.Point(12, 10);
            grpCuenta.Name = "grpCuenta";
            grpCuenta.Size = new System.Drawing.Size(940, 80);
            grpCuenta.TabIndex = 0;
            grpCuenta.TabStop = false;
            grpCuenta.Text = "Información de la Cuenta (Capa BE)";
            // 
            // lblSaldo
            // 
            lblSaldo.AutoSize = true;
            lblSaldo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            lblSaldo.ForeColor = System.Drawing.Color.DarkGreen;
            lblSaldo.Location = new System.Drawing.Point(710, 28);
            lblSaldo.Name = "lblSaldo";
            lblSaldo.Size = new System.Drawing.Size(109, 32);
            lblSaldo.TabIndex = 3;
            lblSaldo.Text = "$ 0.00";
            // 
            // lblSaldoTitulo
            // 
            lblSaldoTitulo.AutoSize = true;
            lblSaldoTitulo.Font = new System.Drawing.Font("Segoe UI", 11F);
            lblSaldoTitulo.Location = new System.Drawing.Point(610, 37);
            lblSaldoTitulo.Name = "lblSaldoTitulo";
            lblSaldoTitulo.Size = new System.Drawing.Size(97, 20);
            lblSaldoTitulo.TabIndex = 2;
            lblSaldoTitulo.Text = "Saldo Actual:";
            // 
            // lblTitular
            // 
            lblTitular.AutoSize = true;
            lblTitular.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblTitular.Location = new System.Drawing.Point(20, 48);
            lblTitular.Name = "lblTitular";
            lblTitular.Size = new System.Drawing.Size(135, 19);
            lblTitular.TabIndex = 1;
            lblTitular.Text = "Titular: Juan Pérez";
            // 
            // lblNumeroCuenta
            // 
            lblNumeroCuenta.AutoSize = true;
            lblNumeroCuenta.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblNumeroCuenta.Location = new System.Drawing.Point(20, 24);
            lblNumeroCuenta.Name = "lblNumeroCuenta";
            lblNumeroCuenta.Size = new System.Drawing.Size(193, 19);
            lblNumeroCuenta.TabIndex = 0;
            lblNumeroCuenta.Text = "N° de Cuenta: CC-00984-2026";
            // 
            // grpOperaciones
            // 
            grpOperaciones.Controls.Add(btnEjecutar);
            grpOperaciones.Controls.Add(numParametro);
            grpOperaciones.Controls.Add(lblParametro);
            grpOperaciones.Controls.Add(lblDescripcionComando);
            grpOperaciones.Controls.Add(cboComandos);
            grpOperaciones.Controls.Add(lblComboTitulo);
            grpOperaciones.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            grpOperaciones.Location = new System.Drawing.Point(12, 95);
            grpOperaciones.Name = "grpOperaciones";
            grpOperaciones.Size = new System.Drawing.Size(460, 205);
            grpOperaciones.TabIndex = 1;
            grpOperaciones.TabStop = false;
            grpOperaciones.Text = "⚡ Ejecución Dinámica (Reflection + Command)";
            // 
            // btnEjecutar
            // 
            btnEjecutar.BackColor = System.Drawing.Color.SteelBlue;
            btnEjecutar.Cursor = System.Windows.Forms.Cursors.Hand;
            btnEjecutar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnEjecutar.ForeColor = System.Drawing.Color.White;
            btnEjecutar.Location = new System.Drawing.Point(20, 153);
            btnEjecutar.Name = "btnEjecutar";
            btnEjecutar.Size = new System.Drawing.Size(420, 40);
            btnEjecutar.TabIndex = 5;
            btnEjecutar.Text = "▶ Ejecutar Comando Instanciado por Reflection";
            btnEjecutar.UseVisualStyleBackColor = false;
            btnEjecutar.Click += btnEjecutar_Click;
            // 
            // numParametro
            // 
            numParametro.DecimalPlaces = 2;
            numParametro.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            numParametro.Location = new System.Drawing.Point(235, 114);
            numParametro.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numParametro.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numParametro.Name = "numParametro";
            numParametro.Size = new System.Drawing.Size(205, 26);
            numParametro.TabIndex = 4;
            numParametro.Value = new decimal(new int[] { 500, 0, 0, 0 });
            // 
            // lblParametro
            // 
            lblParametro.AutoSize = true;
            lblParametro.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            lblParametro.Location = new System.Drawing.Point(20, 118);
            lblParametro.Name = "lblParametro";
            lblParametro.Size = new System.Drawing.Size(126, 17);
            lblParametro.TabIndex = 3;
            lblParametro.Text = "Valor del Parámetro:";
            // 
            // lblDescripcionComando
            // 
            lblDescripcionComando.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            lblDescripcionComando.ForeColor = System.Drawing.Color.FromArgb(70, 70, 70);
            lblDescripcionComando.Location = new System.Drawing.Point(20, 80);
            lblDescripcionComando.Name = "lblDescripcionComando";
            lblDescripcionComando.Size = new System.Drawing.Size(420, 30);
            lblDescripcionComando.TabIndex = 2;
            lblDescripcionComando.Text = "Descripción leída por Reflection desde ComandoInfoAttribute";
            // 
            // cboComandos
            // 
            cboComandos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboComandos.Font = new System.Drawing.Font("Segoe UI", 10F);
            cboComandos.FormattingEnabled = true;
            cboComandos.Location = new System.Drawing.Point(20, 48);
            cboComandos.Name = "cboComandos";
            cboComandos.Size = new System.Drawing.Size(420, 25);
            cboComandos.TabIndex = 1;
            cboComandos.SelectedIndexChanged += cboComandos_SelectedIndexChanged;
            // 
            // lblComboTitulo
            // 
            lblComboTitulo.AutoSize = true;
            lblComboTitulo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            lblComboTitulo.Location = new System.Drawing.Point(20, 26);
            lblComboTitulo.Name = "lblComboTitulo";
            lblComboTitulo.Size = new System.Drawing.Size(262, 17);
            lblComboTitulo.TabIndex = 0;
            lblComboTitulo.Text = "Comandos descubiertos automáticamente:";
            // 
            // grpHistorial
            // 
            grpHistorial.Controls.Add(lstPilaRehacer);
            grpHistorial.Controls.Add(lblPilaRehacer);
            grpHistorial.Controls.Add(lstPilaDeshacer);
            grpHistorial.Controls.Add(lblPilaDeshacer);
            grpHistorial.Controls.Add(btnRehacer);
            grpHistorial.Controls.Add(btnDeshacer);
            grpHistorial.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            grpHistorial.Location = new System.Drawing.Point(485, 95);
            grpHistorial.Name = "grpHistorial";
            grpHistorial.Size = new System.Drawing.Size(467, 205);
            grpHistorial.TabIndex = 2;
            grpHistorial.TabStop = false;
            grpHistorial.Text = "Historial y Reversión (Patrón Command - GestorComandos)";
            // 
            // lstPilaRehacer
            // 
            lstPilaRehacer.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            lstPilaRehacer.FormattingEnabled = true;
            lstPilaRehacer.ItemHeight = 13;
            lstPilaRehacer.Location = new System.Drawing.Point(237, 105);
            lstPilaRehacer.Name = "lstPilaRehacer";
            lstPilaRehacer.Size = new System.Drawing.Size(215, 82);
            lstPilaRehacer.TabIndex = 5;
            // 
            // lblPilaRehacer
            // 
            lblPilaRehacer.AutoSize = true;
            lblPilaRehacer.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            lblPilaRehacer.Location = new System.Drawing.Point(237, 85);
            lblPilaRehacer.Name = "lblPilaRehacer";
            lblPilaRehacer.Size = new System.Drawing.Size(107, 15);
            lblPilaRehacer.TabIndex = 4;
            lblPilaRehacer.Text = "Pila Rehacer (Redo):";
            // 
            // lstPilaDeshacer
            // 
            lstPilaDeshacer.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            lstPilaDeshacer.FormattingEnabled = true;
            lstPilaDeshacer.ItemHeight = 13;
            lstPilaDeshacer.Location = new System.Drawing.Point(15, 105);
            lstPilaDeshacer.Name = "lstPilaDeshacer";
            lstPilaDeshacer.Size = new System.Drawing.Size(205, 82);
            lstPilaDeshacer.TabIndex = 3;
            // 
            // lblPilaDeshacer
            // 
            lblPilaDeshacer.AutoSize = true;
            lblPilaDeshacer.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            lblPilaDeshacer.Location = new System.Drawing.Point(15, 85);
            lblPilaDeshacer.Name = "lblPilaDeshacer";
            lblPilaDeshacer.Size = new System.Drawing.Size(126, 15);
            lblPilaDeshacer.TabIndex = 2;
            lblPilaDeshacer.Text = "Pila Deshacer (Undo):";
            // 
            // btnRehacer
            // 
            btnRehacer.BackColor = System.Drawing.Color.DarkSlateGray;
            btnRehacer.Cursor = System.Windows.Forms.Cursors.Hand;
            btnRehacer.Enabled = false;
            btnRehacer.ForeColor = System.Drawing.Color.White;
            btnRehacer.Location = new System.Drawing.Point(237, 30);
            btnRehacer.Name = "btnRehacer";
            btnRehacer.Size = new System.Drawing.Size(215, 42);
            btnRehacer.TabIndex = 1;
            btnRehacer.Text = "↷ Rehacer (Redo)";
            btnRehacer.UseVisualStyleBackColor = false;
            btnRehacer.Click += btnRehacer_Click;
            // 
            // btnDeshacer
            // 
            btnDeshacer.BackColor = System.Drawing.Color.DarkSlateGray;
            btnDeshacer.Cursor = System.Windows.Forms.Cursors.Hand;
            btnDeshacer.Enabled = false;
            btnDeshacer.ForeColor = System.Drawing.Color.White;
            btnDeshacer.Location = new System.Drawing.Point(15, 30);
            btnDeshacer.Name = "btnDeshacer";
            btnDeshacer.Size = new System.Drawing.Size(205, 42);
            btnDeshacer.TabIndex = 0;
            btnDeshacer.Text = "↶ Deshacer (Undo)";
            btnDeshacer.UseVisualStyleBackColor = false;
            btnDeshacer.Click += btnDeshacer_Click;
            // 
            // tabControlPrincipal
            // 
            tabControlPrincipal.Controls.Add(tabBitacora);
            tabControlPrincipal.Controls.Add(tabReflection);
            tabControlPrincipal.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            tabControlPrincipal.Location = new System.Drawing.Point(12, 308);
            tabControlPrincipal.Name = "tabControlPrincipal";
            tabControlPrincipal.SelectedIndex = 0;
            tabControlPrincipal.Size = new System.Drawing.Size(940, 310);
            tabControlPrincipal.TabIndex = 3;
            // 
            // tabBitacora
            // 
            tabBitacora.Controls.Add(dgvMovimientos);
            tabBitacora.Location = new System.Drawing.Point(4, 25);
            tabBitacora.Name = "tabBitacora";
            tabBitacora.Padding = new System.Windows.Forms.Padding(3);
            tabBitacora.Size = new System.Drawing.Size(932, 281);
            tabBitacora.TabIndex = 0;
            tabBitacora.Text = "📋 Bitácora de Movimientos (Historial de Transacciones)";
            tabBitacora.UseVisualStyleBackColor = true;
            // 
            // dgvMovimientos
            // 
            dgvMovimientos.AllowUserToAddRows = false;
            dgvMovimientos.AllowUserToDeleteRows = false;
            dgvMovimientos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvMovimientos.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dgvMovimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMovimientos.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvMovimientos.Location = new System.Drawing.Point(3, 3);
            dgvMovimientos.MultiSelect = false;
            dgvMovimientos.Name = "dgvMovimientos";
            dgvMovimientos.ReadOnly = true;
            dgvMovimientos.RowHeadersVisible = false;
            dgvMovimientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvMovimientos.Size = new System.Drawing.Size(926, 275);
            dgvMovimientos.TabIndex = 0;
            // 
            // tabReflection
            // 
            tabReflection.Controls.Add(grpMetodosRef);
            tabReflection.Controls.Add(grpPropiedadesRef);
            tabReflection.Controls.Add(btnInspeccionar);
            tabReflection.Controls.Add(cboObjetosReflection);
            tabReflection.Controls.Add(lblSeleccionarObjeto);
            tabReflection.Location = new System.Drawing.Point(4, 25);
            tabReflection.Name = "tabReflection";
            tabReflection.Padding = new System.Windows.Forms.Padding(3);
            tabReflection.Size = new System.Drawing.Size(932, 281);
            tabReflection.TabIndex = 1;
            tabReflection.Text = "🔍 Inspector de Objetos por System.Reflection";
            tabReflection.UseVisualStyleBackColor = true;
            // 
            // grpMetodosRef
            // 
            grpMetodosRef.Controls.Add(lstMetodosReflection);
            grpMetodosRef.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            grpMetodosRef.Location = new System.Drawing.Point(480, 50);
            grpMetodosRef.Name = "grpMetodosRef";
            grpMetodosRef.Size = new System.Drawing.Size(445, 225);
            grpMetodosRef.TabIndex = 4;
            grpMetodosRef.TabStop = false;
            grpMetodosRef.Text = "Métodos Declarados (Reflection - MethodInfo)";
            // 
            // lstMetodosReflection
            // 
            lstMetodosReflection.Dock = System.Windows.Forms.DockStyle.Fill;
            lstMetodosReflection.Font = new System.Drawing.Font("Consolas", 9F);
            lstMetodosReflection.FormattingEnabled = true;
            lstMetodosReflection.ItemHeight = 14;
            lstMetodosReflection.Location = new System.Drawing.Point(3, 19);
            lstMetodosReflection.Name = "lstMetodosReflection";
            lstMetodosReflection.Size = new System.Drawing.Size(439, 203);
            lstMetodosReflection.TabIndex = 0;
            // 
            // grpPropiedadesRef
            // 
            grpPropiedadesRef.Controls.Add(dgvPropiedadesReflection);
            grpPropiedadesRef.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            grpPropiedadesRef.Location = new System.Drawing.Point(10, 50);
            grpPropiedadesRef.Name = "grpPropiedadesRef";
            grpPropiedadesRef.Size = new System.Drawing.Size(460, 225);
            grpPropiedadesRef.TabIndex = 3;
            grpPropiedadesRef.TabStop = false;
            grpPropiedadesRef.Text = "Propiedades y Valores en Memoria (Reflection - PropertyInfo)";
            // 
            // dgvPropiedadesReflection
            // 
            dgvPropiedadesReflection.AllowUserToAddRows = false;
            dgvPropiedadesReflection.AllowUserToDeleteRows = false;
            dgvPropiedadesReflection.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvPropiedadesReflection.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dgvPropiedadesReflection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPropiedadesReflection.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvPropiedadesReflection.Location = new System.Drawing.Point(3, 19);
            dgvPropiedadesReflection.MultiSelect = false;
            dgvPropiedadesReflection.Name = "dgvPropiedadesReflection";
            dgvPropiedadesReflection.ReadOnly = true;
            dgvPropiedadesReflection.RowHeadersVisible = false;
            dgvPropiedadesReflection.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvPropiedadesReflection.Size = new System.Drawing.Size(454, 203);
            dgvPropiedadesReflection.TabIndex = 0;
            // 
            // btnInspeccionar
            // 
            btnInspeccionar.BackColor = System.Drawing.Color.DarkSlateGray;
            btnInspeccionar.Cursor = System.Windows.Forms.Cursors.Hand;
            btnInspeccionar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnInspeccionar.ForeColor = System.Drawing.Color.White;
            btnInspeccionar.Location = new System.Drawing.Point(620, 12);
            btnInspeccionar.Name = "btnInspeccionar";
            btnInspeccionar.Size = new System.Drawing.Size(200, 30);
            btnInspeccionar.TabIndex = 2;
            btnInspeccionar.Text = "🔍 Inspeccionar con Reflection";
            btnInspeccionar.UseVisualStyleBackColor = false;
            btnInspeccionar.Click += btnInspeccionar_Click;
            // 
            // cboObjetosReflection
            // 
            cboObjetosReflection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboObjetosReflection.FormattingEnabled = true;
            cboObjetosReflection.Items.AddRange(new object[] {
            "1. Cuenta (Entidad BE)",
            "2. CuentaBLL (Receiver en BLL)",
            "3. GestorComandos (Invoker en Servicio)",
            "4. Último Comando Ejecutado"});
            cboObjetosReflection.Location = new System.Drawing.Point(260, 15);
            cboObjetosReflection.Name = "cboObjetosReflection";
            cboObjetosReflection.Size = new System.Drawing.Size(340, 25);
            cboObjetosReflection.TabIndex = 1;
            cboObjetosReflection.SelectedIndexChanged += cboObjetosReflection_SelectedIndexChanged;
            // 
            // lblSeleccionarObjeto
            // 
            lblSeleccionarObjeto.AutoSize = true;
            lblSeleccionarObjeto.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            lblSeleccionarObjeto.Location = new System.Drawing.Point(10, 18);
            lblSeleccionarObjeto.Name = "lblSeleccionarObjeto";
            lblSeleccionarObjeto.Size = new System.Drawing.Size(232, 17);
            lblSeleccionarObjeto.TabIndex = 0;
            lblSeleccionarObjeto.Text = "Seleccionar Objeto para Inspección:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            ClientSize = new System.Drawing.Size(964, 626);
            Controls.Add(tabControlPrincipal);
            Controls.Add(grpHistorial);
            Controls.Add(grpOperaciones);
            Controls.Add(grpCuenta);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Patrón Command + System.Reflection en Arquitectura en Capas";
            Load += Form1_Load;
            grpCuenta.ResumeLayout(false);
            grpCuenta.PerformLayout();
            grpOperaciones.ResumeLayout(false);
            grpOperaciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numParametro).EndInit();
            grpHistorial.ResumeLayout(false);
            grpHistorial.PerformLayout();
            tabControlPrincipal.ResumeLayout(false);
            tabBitacora.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMovimientos).EndInit();
            tabReflection.ResumeLayout(false);
            tabReflection.PerformLayout();
            grpMetodosRef.ResumeLayout(false);
            grpPropiedadesRef.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPropiedadesReflection).EndInit();
            ResumeLayout(false);
        }

        #endregion
    }
}
