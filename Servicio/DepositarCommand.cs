using BE;
using BLL;

namespace Servicio
{
    /// <summary>
    /// Comando Concreto para Depósito de dinero.
    /// </summary>
    [ComandoInfo("Depósito de Dinero", "Acredita fondos en la cuenta bancaria", TipoParametroRequerido.Monto)]
    public class DepositarCommand : ICommand
    {
        private readonly Cuenta _cuenta;
        private readonly CuentaBLL _cuentaBLL;
        private readonly decimal _monto;

        public string Descripcion => $"Depósito de ${_monto:N2} en cuenta {_cuenta.Numero}";
        public decimal Monto => _monto;
        public DateTime Fecha { get; } = DateTime.Now;

        public DepositarCommand(Cuenta cuenta, CuentaBLL cuentaBLL, decimal monto)
        {
            _cuenta = cuenta ?? throw new ArgumentNullException(nameof(cuenta));
            _cuentaBLL = cuentaBLL ?? throw new ArgumentNullException(nameof(cuentaBLL));
            _monto = monto;
        }

        public void Execute()
        {
            _cuentaBLL.Depositar(_cuenta, _monto);
        }

        public void Undo()
        {
            _cuentaBLL.RevertirDeposito(_cuenta, _monto);
        }
    }
}
