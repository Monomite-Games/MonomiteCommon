namespace Monomite.Common.MessageBus.Impl.NativeEvent
{
    public class NativeActionMessageBus<E, S> : MessageBus<E, S>
    {
        public NativeActionMessageBus() : base(new NativeEventMessageHandler<E>(), new NativeEventMessageHandler<S>()) { }
    }
}
