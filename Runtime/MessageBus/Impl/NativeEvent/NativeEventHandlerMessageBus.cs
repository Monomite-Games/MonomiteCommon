namespace Monomite.Common.MessageBus.Impl.NativeEvent
{
    public class NativeEventMessageBus<E, S> : MessageBus<E, S>
    {
        public NativeEventMessageBus() : base(new NativeEventMessageHandler<E>(), new NativeEventMessageHandler<S>()) { }
    }
}
