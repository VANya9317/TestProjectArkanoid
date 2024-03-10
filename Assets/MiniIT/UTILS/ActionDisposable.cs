using System;

namespace MiniIT.UTILS
{
    public class ActionDisposable : IDisposable
    {
        private Action onDispose;
        public ActionDisposable(Action onDispose)
        {
            this.onDispose = onDispose;
        }
        public void Dispose()
        {
            onDispose?.Invoke();
            onDispose = null;
        }
    }
}