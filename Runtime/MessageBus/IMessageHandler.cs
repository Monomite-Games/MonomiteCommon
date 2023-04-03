using System;

namespace Monomite.Common.MessageBus
{
    internal interface IMessageHandler<E>
    {
        public void Emit(E data);
        public void AddListener(Action<E> listener);
        public void RemoveListener(Action<E> listener);
        public void RemoveAllListeners();
    }
}