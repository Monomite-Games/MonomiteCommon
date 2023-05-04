namespace Monomite.Common.Interact
{
    public interface IInteractable
    {
        /// <summary>
        /// Entrypoint for external classes interaction
        /// </summary>
        public void Action();

        /// <summary>
        /// Entrypoint for disposing of object after use
        /// </summary>
        public void Dispose();

        /// <summary>
        /// Decides action to be done when interactable (close to player)
        /// </summary>
        public virtual void Highlight() { }

        /// <summary>
        /// Decides action to be done when not interactable any more (further from player)
        /// </summary>
        public virtual void Unhighlight() { }
    }
}
