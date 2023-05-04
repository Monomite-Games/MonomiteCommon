using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Monomite.Common.MessageBus
{
    internal class ActionMessageHandler<M> : MessageHandler<M>
    {
        /// <summary>
        /// The list of listeners that this event will notify if it is raised.
        /// </summary>
        private readonly IList<Action<M>> MessageListeners = new List<Action<M>>();

        internal override void Emit(M message)
        {
            // Backwards to allow self-removing callbacks
            for (int i = MessageListeners.Count - 1; i >= 0; i--)
            {
                try
                {
                    MessageListeners[i].Invoke(message);
                }
                catch (Exception e)
                {
                    UnityEngine.Debug.LogWarning("Error on message callback" + e);
                }
            }
        }

        internal override void AddListener(Action<M> listener)
        {
            if (!MessageListeners.Contains(listener))
            {
                MessageListeners.Add(listener);
            }
        }

        internal override void RemoveListener(Action<M> listener)
        {
            if (MessageListeners.Contains(listener))
            {
                MessageListeners.Remove(listener);
            }
        }

        internal override void RemoveAllListeners()
        {
            MessageListeners.Clear();
        }
    }
}
