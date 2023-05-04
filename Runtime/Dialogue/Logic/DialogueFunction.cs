namespace Monomite.Common.Dialogue.Logic
{
    public abstract class DialogueFunction<T>
    {
        internal abstract string GetName();
        internal abstract T Handler();
    }
}
