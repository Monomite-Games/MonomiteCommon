namespace Monomite.Common.MessageBus
{
    // Interface for the MessageBus for receiving events and emitting states (designed for logic components)
    public interface IProducerMessageBus<E, S> : IEventListener<E>, IStateEmitter<S>
    {

    }
}