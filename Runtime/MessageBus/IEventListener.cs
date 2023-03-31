using System;

namespace Monomite.Common.MessageBus
{
    public interface IEventListener<E>
    {
        public int AddEventListener(Action<E> listener);
        public void RemoveEventListener(int listenerId);
        public void RemoveAllEventListeners();
    }
}