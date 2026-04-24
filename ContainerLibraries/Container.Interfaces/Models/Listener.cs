using System;

namespace Container.Interfaces.Models
{
    public class Listener
    {
        private readonly Action _unsubscribe;

        public Listener() { }

        public Listener(Action unsubscribe)
        {
            _unsubscribe = unsubscribe;
        }

        public void Unsubscribe() => _unsubscribe?.Invoke();
    }
}
