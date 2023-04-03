using System;

namespace Monomite.Common.MessageBus.Impl.NativeAction
{
    internal class NativeActionMessageHandler<E> : IMessageHandler<E>
    {
        private event Action<E> MessageAction;

        public void Emit(E data)
        {
            MessageAction?.Invoke(data);
        }

        public void AddListener(Action<E> listener)
        {
            MessageAction += listener;
        }

        public void RemoveListener(Action<E> listener)
        {
            MessageAction -= listener;
        }

        public void RemoveAllListeners()
        {
            MessageAction = null;
        }
    }
}