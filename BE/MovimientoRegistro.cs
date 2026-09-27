namespace BE
{
    public class MovimientoRegistro
    {
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string Operacion { get; set; } = string.Empty;
        public decimal Monto { get; set; }
        public decimal SaldoResultante { get; set; }
        public string Estado { get; set; } = "Ejecutado";

        public MovimientoRegistro() { }

        public MovimientoRegistro(string operacion, decimal monto, decimal saldoResultante, string estado = "Ejecutado")
        {
            Fecha = DateTime.Now;
            Operacion = operacion;
            Monto = monto;
            SaldoResultante = saldoResultante;
            Estado = estado;
        }
    }
}
