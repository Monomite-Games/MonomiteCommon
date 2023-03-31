namespace Monomite.Common.MessageBus
{
    // Interface for the EventManager for emitting events and receiving states (designed for UI components)
    public interface IPresentationEventManager<E, S> : IEventEmitter<E>, IStateListener<S>
    {

    }
}