namespace Monomite.Common.Dialogue.Logic
{
    public abstract class DialogueCommand
    {
        internal abstract string GetName();
        internal abstract void Handler();
    }
}
