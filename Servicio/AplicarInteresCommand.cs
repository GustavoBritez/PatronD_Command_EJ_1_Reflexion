using BE;
using BLL;

namespace Servicio
{
    /// <summary>
    /// Comando Concreto para Aplicar un % de Interés o Bonificación al Saldo.
    /// Guarda el importe exacto generado para revertirlo en caso de Undo.
    /// </summary>
    [ComandoInfo("Bonificación / Interés %", "Aplica un porcentaje sobre el saldo actual", TipoParametroRequerido.Porcentaje)]
    public class AplicarInteresCommand : ICommand
    {
        private readonly Cuenta _cuenta;
        private readonly CuentaBLL _cuentaBLL;
        private readonly decimal _porcentaje;
        private decimal _montoCalculado;

        public string Descripcion => $"Bonificación / Interés del {_porcentaje}% (+${_montoCalculado:N2})";
        public decimal Monto => _montoCalculado;
        public DateTime Fecha { get; } = DateTime.Now;

        public AplicarInteresCommand(Cuenta cuenta, CuentaBLL cuentaBLL, decimal porcentaje)
        {
            _cuenta = cuenta ?? throw new ArgumentNullException(nameof(cuenta));
            _cuentaBLL = cuentaBLL ?? throw new ArgumentNullException(nameof(cuentaBLL));
            _porcentaje = porcentaje;
        }

        public void Execute()
        {
            _montoCalculado = _cuentaBLL.AplicarInteres(_cuenta, _porcentaje);
        }

        public void Undo()
        {
            _cuentaBLL.RevertirInteres(_cuenta, _montoCalculado);
        }
    }
}
