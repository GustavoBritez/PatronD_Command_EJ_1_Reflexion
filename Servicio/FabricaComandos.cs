using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BE;
using BLL;

namespace Servicio
{
    /// <summary>
    /// Fábrica dinámica de comandos que utiliza System.Reflection para:
    /// 1. Descubrir todas las clases que implementan ICommand en tiempo de ejecución.
    /// 2. Leer sus atributos de metadatos (ComandoInfoAttribute).
    /// 3. Instanciar los comandos resolviendo dinámicamente los parámetros de su constructor.
    /// </summary>
    public static class FabricaComandos
    {
        /// <summary>
        /// Descubre por Reflection todos los comandos disponibles en el ensamblado.
        /// </summary>
        public static List<ComandoMetadata> ObtenerComandosDisponibles()
        {
            var resultado = new List<ComandoMetadata>();

            // Obtenemos el ensamblado donde residen los comandos (Servicio)
            Assembly ensamblado = Assembly.GetExecutingAssembly();

            // Filtrar todos los tipos concretos que implementan ICommand
            var tiposComando = ensamblado.GetTypes()
                .Where(t => typeof(ICommand).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

            foreach (var tipo in tiposComando)
            {
                // Leer el atributo personalizado mediante Reflection
                var atributo = tipo.GetCustomAttribute<ComandoInfoAttribute>();

                var metadata = new ComandoMetadata
                {
                    Tipo = tipo,
                    Nombre = atributo?.Nombre ?? tipo.Name,
                    Descripcion = atributo?.Descripcion ?? "Sin descripción",
                    ParametroRequerido = atributo?.ParametroRequerido ?? TipoParametroRequerido.Monto
                };

                resultado.Add(metadata);
            }

            return resultado;
        }

        /// <summary>
        /// Instancia dinámicamente un comando mediante Reflection inspeccionando su constructor.
        /// </summary>
        public static ICommand CrearComando(Type tipoComando, Cuenta cuenta, CuentaBLL cuentaBLL, decimal valorParametro)
        {
            if (!typeof(ICommand).IsAssignableFrom(tipoComando))
                throw new ArgumentException($"El tipo {tipoComando.Name} no implementa la interfaz ICommand.");

            // Obtener constructores públicos del tipo usando Reflection
            ConstructorInfo? constructor = tipoComando.GetConstructors()
                .OrderByDescending(c => c.GetParameters().Length)
                .FirstOrDefault();

            if (constructor == null)
                throw new InvalidOperationException($"No se encontró un constructor público para {tipoComando.Name}.");

            // Inspeccionar los parámetros del constructor dinámicamente
            ParameterInfo[] parametrosInfo = constructor.GetParameters();
            object[] argumentos = new object[parametrosInfo.Length];

            for (int i = 0; i < parametrosInfo.Length; i++)
            {
                Type tipoParametro = parametrosInfo[i].ParameterType;

                if (tipoParametro == typeof(Cuenta))
                {
                    argumentos[i] = cuenta;
                }
                else if (tipoParametro == typeof(CuentaBLL))
                {
                    argumentos[i] = cuentaBLL;
                }
                else if (tipoParametro == typeof(decimal))
                {
                    argumentos[i] = valorParametro;
                }
                else
                {
                    throw new NotSupportedException($"Tipo de parámetro '{tipoParametro.Name}' no soportado en la instanciación por Reflection.");
                }
            }

            // Invocación dinámica del constructor mediante Reflection
            return (ICommand)constructor.Invoke(argumentos);
        }
    }
}
