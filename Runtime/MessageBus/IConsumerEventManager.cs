namespace Monomite.Common.MessageBus
{
    // Interface for the MessageBus for emitting events and receiving states (designed for UI components)
    public interface IConsumerMessageBus<E, S> : IEventEmitter<E>, IStateListener<S>
    {

    }
}