using Monomite.Common.MessageBus;
using UnityEngine;

namespace Monomite.Common.Dialogue.View
{
    public class DialogueController : StateListener<DialogueEvent, DialogueState>
    {
        [SerializeField]
        private Canvas Canvas;

        [SerializeField]
        private DialogueStyleController StyleController;

        [SerializeField]
        private DialogueLineController LineController;
        [SerializeField]
        private DialogueOptionsController OptionsController;

        protected override void OnStateEmitted(DialogueState message)
        {
            if (message is DialogueStarted)
            {
                HandleDialogueStarted();
            }
            else if (message is DialogueEnded)
            {
                HandleDialogueEnded();
            }
            else if (message is DialogueLineRun)
            {
                HandleDialogueLineRun(message as DialogueLineRun);
            }
            else if (message is DialogueOptionsRun)
            {
                HandleDialogueOptionsRun(message as DialogueOptionsRun);
            }
        }

        private void HandleDialogueStarted()
        {
            ClearAll();
            Canvas.enabled = true;
        }

        private void HandleDialogueEnded()
        {
            Canvas.enabled = false;
            ClearAll();
        }

        private void HandleDialogueLineRun(DialogueLineRun message)
        {
            LineController.Clear();
            OptionsController.Clear();

            DialogueStyle style = StyleController.GetStyle(message.Style);
            LineController.SetText(message.Name, message.Text, style.GetTextStyle());
        }

        private void HandleDialogueOptionsRun(DialogueOptionsRun message)
        {
            OptionsController.Clear();
            OptionsController.StartOptions();

            foreach (DialogueOption option in message.Options)
            {
                DialogueStyle style = StyleController.GetStyle(option.Style);
                OptionsController.AddOption(option.Id, option.Text, style.GetTextStyle());
            }
        }

        private void ClearAll()
        {
            LineController.Clear(popOut: true);
            OptionsController.Clear();
        }
    }
}