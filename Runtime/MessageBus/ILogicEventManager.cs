namespace Monomite.Common.MessageBus
{
    // Interface for the EventManager for receiving events and emitting states (designed for logic components)
    public interface ILogicEventManager<E, S> : IEventListener<E>, IStateEmitter<S>
    {

    }
}