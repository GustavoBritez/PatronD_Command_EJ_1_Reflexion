using System.Collections.Generic;

namespace Servicio
{
    /// <summary>
    /// Actúa como el Invoker (Invocador) en el Patrón Command.
    /// Administra la ejecución de comandos y las pilas de Deshacer (Undo) y Rehacer (Redo).
    /// </summary>
    public class GestorComandos
    {
        private readonly Stack<ICommand> _pilaDeshacer = new();
        private readonly Stack<ICommand> _pilaRehacer = new();

        public bool PuedeDeshacer => _pilaDeshacer.Count > 0;
        public bool PuedeRehacer => _pilaRehacer.Count > 0;

        public void Ejecutar(ICommand comando)
        {
            if (comando == null) throw new ArgumentNullException(nameof(comando));

            comando.Execute();
            _pilaDeshacer.Push(comando);
            _pilaRehacer.Clear(); // Nueva acción invalida la pila de rehacer
        }

        public ICommand? Deshacer()
        {
            if (!PuedeDeshacer) return null;

            var comando = _pilaDeshacer.Pop();
            comando.Undo();
            _pilaRehacer.Push(comando);
            return comando;
        }

        public ICommand? Rehacer()
        {
            if (!PuedeRehacer) return null;

            var comando = _pilaRehacer.Pop();
            comando.Execute();
            _pilaDeshacer.Push(comando);
            return comando;
        }

        public IReadOnlyCollection<ICommand> ObtenerPilaDeshacer() => _pilaDeshacer.ToArray();
        public IReadOnlyCollection<ICommand> ObtenerPilaRehacer() => _pilaRehacer.ToArray();
    }
}
