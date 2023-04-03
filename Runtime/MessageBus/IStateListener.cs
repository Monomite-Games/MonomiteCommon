using System;

namespace Monomite.Common.MessageBus
{
    public interface IStateListener<S>
    {
        public void AddStateListener(Action<S> listener);
        public void RemoveStateListener(Action<S> listener);
        public void RemoveAllStateListeners();
    }
}