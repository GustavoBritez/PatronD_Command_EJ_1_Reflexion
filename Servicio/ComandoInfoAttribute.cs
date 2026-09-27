using System;

namespace Servicio
{
    public enum TipoParametroRequerido
    {
        Ninguno,
        Monto,
        Porcentaje
    }

    /// <summary>
    /// Atributo personalizado para decorar comandos y permitir su descubrimiento por Reflection.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class ComandoInfoAttribute : Attribute
    {
        public string Nombre { get; }
        public string Descripcion { get; }
        public TipoParametroRequerido ParametroRequerido { get; }

        public ComandoInfoAttribute(string nombre, string descripcion, TipoParametroRequerido parametroRequerido = TipoParametroRequerido.Monto)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            ParametroRequerido = parametroRequerido;
        }
    }
}
