using System;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

namespace Monomite.Common.Dialogue.Logic
{
    /// <summary>Clase
    /// <c>EventsDialogueView</c> implementa <c>Yarn.Unity.DialogueViewBase</c> de Yarn para
    /// mandar eventos de <c>DialogueState</c> cada vez que recibe llamadas internas de <c>Yarn.Unity.DialogueRunner</c>.
    /// </summary>
    internal class EventsDialogueView : DialogueViewBase
    {
        [SerializeField]
        private DialogueSystem DialogueSystem;

        private const string StyleSeparator = "++";

        private Action OnDialogueLineFinished;

        private Action<int> OnOptionSelectedCallback;

        internal void SelectOption(int option)
        {
            if (OnOptionSelectedCallback != null)
            {
                OnOptionSelectedCallback(option);
                OnOptionSelectedCallback = null;
            }
        }

        public override void DialogueStarted()
        {
            DialogueSystem.RunDialogueStart();
        }

        public override void DialogueComplete()
        {
            DialogueSystem.RunDialogueEnd();
        }

        public override void RunLine(LocalizedLine dialogueLine, Action onDialogueLineFinished)
        {
            OnDialogueLineFinished = onDialogueLineFinished;

            ProcessLine(dialogueLine, out string characterName, out string dialogueText, out string dialogueStyle);
            DialogueSystem.RunDialogueLine(characterName, dialogueText, dialogueStyle);
        }

        public override void RunOptions(Yarn.Unity.DialogueOption[] dialogueOptions, Action<int> onOptionSelected)
        {
            OnOptionSelectedCallback = onOptionSelected;

            List<DialogueOption> options = new();
            foreach (Yarn.Unity.DialogueOption dialogueOption in dialogueOptions)
            {
                ProcessLine(dialogueOption.Line, out _, out string dialogueText, out string dialogueStyle);
                DialogueOption option = new(dialogueOption.DialogueOptionID, dialogueText, dialogueOption.IsAvailable, dialogueStyle);
                options.Add(option);
            }
            DialogueSystem.RunDialogueOptions(options);
        }

        public override void UserRequestedViewAdvancement()
        {
            OnDialogueLineFinished();
        }

        private static void ProcessLine(LocalizedLine dialogueLine, out string characterName, out string dialogueText, out string dialogueStyle)
        {
            dialogueText = dialogueLine.TextWithoutCharacterName.Text;
            DialogueSeparator.SeparateNameAndStyle(dialogueLine.CharacterName, StyleSeparator, out characterName, out dialogueStyle);
        }
    }
}