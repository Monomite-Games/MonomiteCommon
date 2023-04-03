namespace Monomite.Common.MessageBus.Impl.NativeAction
{
    public class NativeActionMessageBus<E, S> : MessageBus<E, S>
    {
        public NativeActionMessageBus() : base(new NativeActionMessageHandler<E>(), new NativeActionMessageHandler<S>()) { }
    }
}