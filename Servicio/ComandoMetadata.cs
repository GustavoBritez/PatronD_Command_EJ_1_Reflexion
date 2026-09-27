using System;

namespace Servicio
{
    /// <summary>
    /// Representa los metadatos de un comando descubierto mediante Reflection.
    /// </summary>
    public class ComandoMetadata
    {
        public Type Tipo { get; set; } = null!;
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public TipoParametroRequerido ParametroRequerido { get; set; }

        public override string ToString()
        {
            return $"{Nombre} ({Tipo.Name})";
        }
    }
}
