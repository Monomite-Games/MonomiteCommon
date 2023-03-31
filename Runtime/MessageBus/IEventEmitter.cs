namespace Monomite.Common.MessageBus
{
    public interface IEventEmitter<E>
    {
        public void EmitEvent(E data);
    }
}