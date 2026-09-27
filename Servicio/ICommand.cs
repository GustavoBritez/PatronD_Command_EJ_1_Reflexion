namespace Servicio
{
    /// <summary>
    /// Interfaz del Patrón Command.
    /// Define los métodos obligatorios para ejecutar y revertir cualquier acción.
    /// </summary>
    public interface ICommand
    {
        string Descripcion { get; }
        decimal Monto { get; }
        DateTime Fecha { get; }

        void Execute();
        void Undo();
    }
}
