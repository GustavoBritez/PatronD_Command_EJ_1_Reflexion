using BE;

namespace BLL
{
    /// <summary>
    /// Actúa como el Receiver (Receptor) en el Patrón Command.
    /// Contiene la lógica y reglas de negocio para operar sobre la Cuenta.
    /// </summary>
    public class CuentaBLL
    {
        public void Depositar(Cuenta cuenta, decimal monto)
        {
            if (monto <= 0)
                throw new ArgumentException("El monto a depositar debe ser mayor a 0.");

            cuenta.Saldo += monto;
        }

        public void RevertirDeposito(Cuenta cuenta, decimal monto)
        {
            if (cuenta.Saldo < monto)
                throw new InvalidOperationException("No es posible revertir el depósito: fondos insuficientes.");

            cuenta.Saldo -= monto;
        }

        public void Retirar(Cuenta cuenta, decimal monto)
        {
            if (monto <= 0)
                throw new ArgumentException("El monto a retirar debe ser mayor a 0.");

            if (cuenta.Saldo < monto)
                throw new InvalidOperationException($"Fondos insuficientes. Saldo disponible: ${cuenta.Saldo:N2}");

            cuenta.Saldo -= monto;
        }

        public void RevertirRetiro(Cuenta cuenta, decimal monto)
        {
            cuenta.Saldo += monto;
        }

        public decimal AplicarInteres(Cuenta cuenta, decimal porcentaje)
        {
            if (porcentaje <= 0)
                throw new ArgumentException("El porcentaje debe ser mayor a 0.");

            decimal montoInteres = Math.Round(cuenta.Saldo * (porcentaje / 100m), 2);
            cuenta.Saldo += montoInteres;
            return montoInteres;
        }

        public void RevertirInteres(Cuenta cuenta, decimal montoInteres)
        {
            if (cuenta.Saldo < montoInteres)
                throw new InvalidOperationException("No es posible revertir el interés: saldo insuficiente.");

            cuenta.Saldo -= montoInteres;
        }
    }
}
