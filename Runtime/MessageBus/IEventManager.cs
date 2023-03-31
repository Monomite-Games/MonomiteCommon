namespace Monomite.Common.MessageBus
{
    public interface IEventManager<E> : IEventEmitter<E>, IEventListener<E> { }
    public interface IStateManager<S> : IStateEmitter<S>, IStateListener<S> { }
    public interface IEventStateManager<E, S> : IEventManager<E>, IStateManager<S>, ILogicEventManager<E, S>, IPresentationEventManager<E, S> { }
}