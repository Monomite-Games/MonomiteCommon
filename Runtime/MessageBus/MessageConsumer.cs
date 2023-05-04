using UnityEngine;

namespace Monomite.Common.MessageBus
{
    public abstract class MessageConsumer<E, S> : MonoBehaviour
    {
        [Tooltip("Bus to register with.")]
        [SerializeField]
        private MessageBus<E, S> MessageBus;

        private void OnEnable()
        {
            MessageBus.AddStateListener(StateListener);
        }

        private void OnDisable()
        {
            MessageBus.RemoveStateListener(StateListener);
        }

        protected void EmitEvent(E message)
        {
            MessageBus.EmitEvent(message);
        }

        protected abstract void StateListener(S message);
    }
}
