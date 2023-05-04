using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

namespace Monomite.Common.Dialogue.Logic
{
    internal class DialogueFunctionHandler : MonoBehaviour
    {
        [SerializeField]
        DialogueRunner DialogueRunner;

        [SerializeField]
        private List<DialogueFunction<dynamic>> Functions = new();

        private void Awake()
        {
            foreach (DialogueFunction<dynamic> function in Functions)
            {
                DialogueRunner.AddFunction(
                    function.GetName(),
                    function.Handler
                );
            }
        }
    }
}