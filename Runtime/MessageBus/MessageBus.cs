using System;

namespace Monomite.Common.MessageBus
{
    public abstract class MessageBus<E, S> : IMessageBus<E, S>
    {
        private readonly IMessageHandler<E> EventHandler;
        private readonly IMessageHandler<S> StateHandler;

        internal MessageBus(IMessageHandler<E> eventHandler, IMessageHandler<S> stateHandler)
        {
            EventHandler = eventHandler;
            StateHandler = stateHandler;
        }

        public void EmitEvent(E data)
        {
            EventHandler.Emit(data);
        }

        public void AddEventListener(Action<E> listener)
        {
            EventHandler.AddListener(listener);
        }

        public void RemoveEventListener(Action<E> listener)
        {
            EventHandler.RemoveListener(listener);
        }

        public void RemoveAllEventListeners()
        {
            EventHandler.RemoveAllListeners();
        }

        public void EmitState(S data)
        {
            StateHandler.Emit(data);
        }

        public void AddStateListener(Action<S> listener)
        {
            StateHandler.AddListener(listener);
        }

        public void RemoveStateListener(Action<S> listener)
        {
            StateHandler.RemoveListener(listener);
        }

        public void RemoveAllStateListeners()
        {
            StateHandler.RemoveAllListeners();
        }
    }
}