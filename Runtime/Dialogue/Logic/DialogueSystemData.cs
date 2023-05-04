using System.Collections.Generic;
using UnityEngine;

namespace Monomite.Common.Dialogue.Logic
{
    [CreateAssetMenu(menuName = "Dialogue/Dialogue System Data", fileName = "Dialogue System Data")]
    internal class DialogueSystemData : ScriptableObject
    {
        [SerializeField]
        private List<string> VisitedNodes = new();

        internal void AddVisitedNode(string node)
        {
            if (!VisitedNodes.Contains(node))
            {
                VisitedNodes.Add(node);
            }
        }
    }
}