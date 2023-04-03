using System;

namespace Monomite.Common.MessageBus.Impl.NativeEvent
{
    internal class NativeEventMessageHandler<E> : IMessageHandler<E>
    {
        public event EventHandler MessageEventHandler;

        public void Emit(E data)
        {
            MessageEventHandler?.Invoke(this, data);
        }

        public void AddListener(Action<E> listener)
        {
            MessageEventHandler += listener;
        }

        public void RemoveListener(Action<E> listener)
        {
            MessageEventHandler -= listener;
        }

        public void RemoveAllListeners()
        {
            MessageEventHandler = null;
        }
    }
}
