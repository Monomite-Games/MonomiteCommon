using UnityEngine;

namespace Monomite.Common.MessageBus
{
    public abstract class MessageProducer<E, S> : MonoBehaviour
    {
        [Tooltip("Bus to register with.")]
        [SerializeField]
        private MessageBus<E, S> MessageBus;

        private void OnEnable()
        {
            MessageBus.AddEventListener(EventListener);
        }

        private void OnDisable()
        {
            MessageBus.RemoveEventListener(EventListener);
        }

        protected void EmitState(S message)
        {
            MessageBus.EmitState(message);
        }

        protected abstract void EventListener(E message);
    }
}
