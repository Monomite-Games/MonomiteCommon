namespace Monomite.Common.Dialogue.Logic
{
    internal static class DialogueSeparator
    {
        internal static void SeparateNameAndStyle(string characterNameRaw, string styleSeparator, out string characterName, out string dialogueStyle)
        {
            DivideStringBy(characterNameRaw, styleSeparator, out string name, out string style);

            if (string.IsNullOrEmpty(style))
            {
                characterName = name;
                // Assume same style name as character name
                dialogueStyle = characterName;
            }
            else
            {
                characterName = name;
                dialogueStyle = style;
            }
        }

        private static void DivideStringBy(string text, string separator, out string leftText, out string rightText)
        {
            text ??= string.Empty;

            int indexOfSeparator = text.IndexOf(separator);

            if (indexOfSeparator < 0) // No separator found
            {
                leftText = text;
                rightText = string.Empty;
            }
            else
            {
                leftText = text.Substring(0, indexOfSeparator);

                int rightStartIndex = indexOfSeparator + separator.Length;
                rightText = text.Substring(rightStartIndex, text.Length - rightStartIndex);
            }
        }
    }
}