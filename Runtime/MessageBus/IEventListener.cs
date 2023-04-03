using System;

namespace Monomite.Common.MessageBus
{
    public interface IEventListener<E>
    {
        public void AddEventListener(Action<E> listener);
        public void RemoveEventListener(Action<E> listener);
        public void RemoveAllEventListeners();
    }
}