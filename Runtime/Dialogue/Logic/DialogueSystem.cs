using Monomite.Common.MessageBus;
using System;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

namespace Monomite.Common.Dialogue.Logic
{
    /// <summary>
    /// Clase <c>DialogueManager</c> se suscribe a eventos de diálogos para llamar a <c>Yarn.Unity.DialogueRunner</c> y <c>Yarn.Unity.DialogueViewBase</c>
    /// </summary>
    public class DialogueSystem : MessageProducer<DialogueEvent, DialogueState>
    {
        [SerializeField]
        private DialogueRunner DialogueRunner;

        [SerializeField]
        private DialogueSystemData Data;

        [SerializeField]
        private EventsDialogueView DialogueView;

        private bool ReadyForNextLine = false;

        protected override void EventListener(DialogueEvent message)
        {
            if (message is StartDialogue)
            {
                HandleStartDialogue(message as StartDialogue);
            }
            else if (message is EndDialogue)
            {
                HandleEndDialogue();
            }
            else if (message is ContinueDialogue)
            {
                HandleContinueDialogue();
            }
            else if (message is PrepareForNextDialogueLine)
            {
                HandlePrepareForNextLine();
            }
            else if (message is SelectDialogueOption)
            {
                HandleSelectDialogueOption(message as SelectDialogueOption);
            }
        }

        internal void RunDialogueStart()
        {
            EmitState(new DialogueStarted());
        }

        internal void RunDialogueEnd()
        {
            EmitState(new DialogueEnded());
        }

        internal void RunDialogueLine(string characterName, string dialogueText, string dialogueStyle)
        {
            EmitState(new DialogueLineRun(characterName, dialogueText, dialogueStyle));
        }

        internal void RunDialogueOptions(List<DialogueOption> options)
        {
            EmitState(new DialogueOptionsRun(options));
        }

        private void HandleStartDialogue(StartDialogue message)
        {
            if (!DialogueRunner.IsDialogueRunning)
            {
                ReadyForNextLine = false;

                string node = message.Node;
                DialogueRunner.StartDialogue(node);
                Data.AddVisitedNode(node);
            }
            else
            {
                Debug.LogWarning("Requesting start dialogue but dialogue is already running");
            }
        }

        private void HandleEndDialogue()
        {
            if (DialogueRunner.IsDialogueRunning)
            {
                DialogueRunner.Stop();
                // State is emitted when view gets notified
            }
            else
            {
                Debug.LogWarning("Requesting end dialogue but dialogue is not running");
            }
        }

        private void HandleContinueDialogue()
        {
            if (DialogueRunner.IsDialogueRunning)
            {
                if (ReadyForNextLine)
                {
                    ReadyForNextLine = false;
                    DialogueView.UserRequestedViewAdvancement();
                }
                else
                {
                    EmitState(new DialogueNextLineRequestedButNotPrepared());
                }
            }
        }

        private void HandlePrepareForNextLine()
        {
            if (DialogueRunner.IsDialogueRunning)
            {
                ReadyForNextLine = true;
            }
        }

        private void HandleSelectDialogueOption(SelectDialogueOption message)
        {
            if (DialogueRunner.IsDialogueRunning)
            {
                DialogueView.SelectOption(message.OptionId);
            }
        }
    }
}