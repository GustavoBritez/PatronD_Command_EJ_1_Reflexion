using BE;
using BLL;

namespace Servicio
{
    /// <summary>
    /// Comando Concreto para Extracción (Retiro) de dinero.
    /// </summary>
    [ComandoInfo("Extracción de Dinero", "Debita fondos de la cuenta validando saldo suficiente", TipoParametroRequerido.Monto)]
    public class RetirarCommand : ICommand
    {
        private readonly Cuenta _cuenta;
        private readonly CuentaBLL _cuentaBLL;
        private readonly decimal _monto;

        public string Descripcion => $"Extracción de ${_monto:N2} de cuenta {_cuenta.Numero}";
        public decimal Monto => _monto;
        public DateTime Fecha { get; } = DateTime.Now;

        public RetirarCommand(Cuenta cuenta, CuentaBLL cuentaBLL, decimal monto)
        {
            _cuenta = cuenta ?? throw new ArgumentNullException(nameof(cuenta));
            _cuentaBLL = cuentaBLL ?? throw new ArgumentNullException(nameof(cuentaBLL));
            _monto = monto;
        }

        public void Execute()
        {
            _cuentaBLL.Retirar(_cuenta, _monto);
        }

        public void Undo()
        {
            _cuentaBLL.RevertirRetiro(_cuenta, _monto);
        }
    }
}
