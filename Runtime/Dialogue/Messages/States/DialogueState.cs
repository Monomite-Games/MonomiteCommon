using Monomite.Common.MessageBus;
using System.Collections.Generic;

namespace Monomite.Common.Dialogue
{
    public class DialogueState { }

    public class DialogueStarted : DialogueState { }

    public class DialogueEnded : DialogueState { }

    public class DialogueOptionsRun : DialogueState
    {
        public readonly IList<DialogueOption> Options;

        public DialogueOptionsRun(IList<DialogueOption> options)
        {
            Options = options;
        }
    }

    public class DialogueLineRun : DialogueState
    {
        public readonly string Name;
        public readonly string Text;
        public readonly string Style;

        public DialogueLineRun(string name, string text, string style)
        {
            Name = name;
            Text = text;
            Style = style;
        }
    }

    public class DialogueNextLineRequestedButNotPrepared : DialogueState { }
}
