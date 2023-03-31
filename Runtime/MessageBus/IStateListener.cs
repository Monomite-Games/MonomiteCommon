using System;

namespace Monomite.Common.MessageBus
{
    public interface IStateListener<S>
    {
        public int AddStateListener(Action<S> listener);
        public void RemoveStateListener(int listenerId);
        public void RemoveAllStateListeners();
    }
}