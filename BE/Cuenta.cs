namespace BE
{
    public class Cuenta
    {
        public string Numero { get; set; } = string.Empty;
        public string Titular { get; set; } = string.Empty;
        public decimal Saldo { get; set; }

        public Cuenta() { }

        public Cuenta(string numero, string titular, decimal saldoInicial = 0)
        {
            Numero = numero;
            Titular = titular;
            Saldo = saldoInicial;
        }

        public override string ToString()
        {
            return $"Cuenta {Numero} - Titular: {Titular}";
        }
    }
}
