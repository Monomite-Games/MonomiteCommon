namespace Monomite.Common.Dialogue
{
    public class DialogueOption
    {
        public readonly int Id;
        public readonly string Text;
        public readonly bool IsAvailable;
        public readonly string Style;

        public DialogueOption(int id, string text, bool isAvailable, string style)
        {
            Id = id;
            Text = text;
            IsAvailable = isAvailable;
            Style = style;
        }
    }
}