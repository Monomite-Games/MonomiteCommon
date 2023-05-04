using UnityEngine;

namespace Monomite.Common.MessageBus
{
    public abstract class EventEmitter<E, S> : MonoBehaviour
    {
        [Tooltip("Bus to register with.")]
        [SerializeField]
        private MessageBus<E, S> MessageBus;

        protected void EmitEvent(E message)
        {
            MessageBus.EmitEvent(message);
        }
    }
}
