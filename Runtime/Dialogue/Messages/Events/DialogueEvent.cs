namespace Monomite.Common.Dialogue
{
    public class DialogueEvent { }

    public class StartDialogue : DialogueEvent
    {
        public readonly string Node;

        public StartDialogue(string node)
        {
            Node = node;
        }
    }

    public class EndDialogue : DialogueEvent { }

    public class ContinueDialogue : DialogueEvent { }

    public class SelectDialogueOption : DialogueEvent
    {
        public readonly int OptionId;

        public SelectDialogueOption(int optionId)
        {
            OptionId = optionId;
        }
    }

    public class PrepareForNextDialogueLine : DialogueEvent { }
}
