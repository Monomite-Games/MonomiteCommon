using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

namespace Monomite.Common.Dialogue.Logic
{
    internal class DialogueCommandHandler : MonoBehaviour
    {
        [SerializeField]
        private DialogueRunner DialogueRunner;

        [SerializeField]
        private List<DialogueCommand> Commands = new();

        private void Awake()
        {
            foreach (DialogueCommand command in Commands)
            {
                DialogueRunner.AddCommandHandler(
                    command.GetName(),
                    command.Handler
                );
            }
        }
    }
}