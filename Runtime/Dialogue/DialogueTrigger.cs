using Monomite.Common.Interact;
using Monomite.Common.MessageBus;
using UnityEngine;

namespace Monomite.Common.Dialogue
{
    public class DialogueTrigger : EventEmitter<DialogueEvent, DialogueState>, IInteractable
    {
        [SerializeField]
        private string Node;

        public void Action()
        {
            EmitEvent(new StartDialogue(Node));
        }

        public void Dispose()
        {
            // TODO Possibly remove trigger
        }
    }
}
