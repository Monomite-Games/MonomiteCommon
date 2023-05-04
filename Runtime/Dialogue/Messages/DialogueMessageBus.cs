using Monomite.Common.MessageBus;
using UnityEngine;

namespace Monomite.Common.Dialogue
{
    [CreateAssetMenu(menuName = "Dialogue/Dialogue Message Bus", fileName = "Dialogue Message Bus")]
    public class DialogueMessageBus : MessageBus<DialogueEvent, DialogueState> { }
}
