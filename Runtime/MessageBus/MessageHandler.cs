using System;

namespace Monomite.Common.MessageBus
{
    internal abstract class MessageHandler<M>
    {
        internal abstract void Emit(M message);
        internal abstract void AddListener(Action<M> listener);
        internal abstract void RemoveListener(Action<M> listener);
        internal abstract void RemoveAllListeners();
    }
}
