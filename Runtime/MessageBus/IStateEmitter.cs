namespace Monomite.Common.MessageBus
{
    public interface IStateEmitter<S>
    {
        public void EmitState(S data);
    }
}