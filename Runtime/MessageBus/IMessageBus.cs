namespace Monomite.Common.MessageBus
{
    public interface IEventMessageBus<E> : IEventEmitter<E>, IEventListener<E> { }
    public interface IStateMessageBus<S> : IStateEmitter<S>, IStateListener<S> { }
    public interface IMessageBus<E, S> : IEventMessageBus<E>, IStateMessageBus<S>, IProducerMessageBus<E, S>, IConsumerMessageBus<E, S> { }
}