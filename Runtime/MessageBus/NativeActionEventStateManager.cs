using System;

namespace Monomite.Common.MessageBus
{
    public class NativeActionEventStateManager<E, S> : IEventStateManager<E, S>
    {
        private event Action<E> EventHandler; // TODO change to EventHandler
        private event Action<S> StateHandler; // TODO change to EventHandler

        public void EmitEvent(E data)
        {
            EventHandler?.Invoke(data);
        }

        public int AddEventListener(Action<E> listener)
        {
            EventHandler += listener;

            return -1; // TODO
        }
        public void RemoveEventListener(int listenerId)
        {
            throw new NotImplementedException();
        }

        public void RemoveAllEventListeners()
        {
            throw new NotImplementedException();
        }

        public void EmitState(S data)
        {
            StateHandler?.Invoke(data);
        }

        public int AddStateListener(Action<S> listener)
        {
            StateHandler += listener;

            return -1; // TODO
        }

        public void RemoveStateListener(int listenerId)
        {
            throw new NotImplementedException();
        }

        public void RemoveAllStateListeners()
        {
            throw new NotImplementedException();
        }
    }
}