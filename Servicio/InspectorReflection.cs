using System;
using System.Collections.Generic;
using System.Reflection;

namespace Servicio
{
    public class InfoPropiedadReflection
    {
        public string Nombre { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public string Valor { get; set; } = string.Empty;
    }

    /// <summary>
    /// Servicio de utilidades que aplica System.Reflection para inspeccionar cualquier objeto o tipo.
    /// </summary>
    public static class InspectorReflection
    {
        /// <summary>
        /// Inspecciona las propiedades públicas de un objeto en tiempo de ejecución.
        /// </summary>
        public static List<InfoPropiedadReflection> InspeccionarPropiedades(object? objeto)
        {
            var resultado = new List<InfoPropiedadReflection>();
            if (objeto == null) return resultado;

            Type tipo = objeto.GetType();
            PropertyInfo[] propiedades = tipo.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var prop in propiedades)
            {
                object? valor;
                try
                {
                    valor = prop.CanRead ? prop.GetValue(objeto) : "[No legible]";
                }
                catch (Exception ex)
                {
                    valor = $"[Error: {ex.Message}]";
                }

                resultado.Add(new InfoPropiedadReflection
                {
                    Nombre = prop.Name,
                    Tipo = prop.PropertyType.Name,
                    Valor = valor?.ToString() ?? "null"
                });
            }

            return resultado;
        }

        /// <summary>
        /// Obtiene los nombres y firmas de los métodos declarados en un tipo mediante Reflection.
        /// </summary>
        public static List<string> InspeccionarMetodos(Type tipo)
        {
            var resultado = new List<string>();
            if (tipo == null) return resultado;

            MethodInfo[] metodos = tipo.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            foreach (var metodo in metodos)
            {
                if (metodo.IsSpecialName) continue; // Ignorar getters/setters

                var parametros = metodo.GetParameters();
                string paramsStr = string.Join(", ", Array.ConvertAll(parametros, p => $"{p.ParameterType.Name} {p.Name}"));
                resultado.Add($"{metodo.ReturnType.Name} {metodo.Name}({paramsStr})");
            }

            return resultado;
        }
    }
}
