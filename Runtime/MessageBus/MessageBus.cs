using System;
using UnityEngine;

namespace Monomite.Common.MessageBus
{
    public abstract class MessageBus<E, S> : ScriptableObject
    {
        private readonly MessageHandler<E> EventHandler = new ActionMessageHandler<E>();
        private readonly MessageHandler<S> StateHandler = new ActionMessageHandler<S>();

        public void EmitEvent(E message)
        {
            EventHandler.Emit(message);
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

        public void EmitState(S message)
        {
            StateHandler.Emit(message);
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
