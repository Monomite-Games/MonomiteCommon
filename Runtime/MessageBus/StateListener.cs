using UnityEngine;

namespace Monomite.Common.MessageBus
{
    public abstract class StateListener<E, S> : MonoBehaviour
    {
        [Tooltip("Bus to register with.")]
        [SerializeField]
        private MessageBus<E, S> MessageBus;

        private void OnEnable()
        {
            MessageBus.AddStateListener(OnStateEmitted);
        }

        private void OnDisable()
        {
            MessageBus.RemoveStateListener(OnStateEmitted);
        }

        protected abstract void OnStateEmitted(S message);
    }
}
