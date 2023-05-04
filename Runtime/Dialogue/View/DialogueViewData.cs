using System;
using UnityEngine;

namespace Monomite.
    Dialogue.View
{
    [CreateAssetMenu(menuName = "Dialogue/Dialogue View Data", fileName = "Dialogue View Data")]
    internal class DialogueViewData : ScriptableObject
    {
        [SerializeField]
        private DefaultMinMax TextDelay;

        [SerializeField]
        private DefaultMinMax TextSize;

        [SerializeField]
        private float NextLineDelaySeconds;

        [SerializeField]
        private float PanelScaleTimeSeconds;

        internal DefaultMinMax GetTextDelay()
        {
            return TextDelay;
        }

        internal DefaultMinMax GetTextSize()
        {
            return TextSize;
        }

        internal float GetNextLineDelaySeconds()
        {
            return NextLineDelaySeconds;
        }

        internal float GetScaleTimeSeconds()
        {
            return PanelScaleTimeSeconds;
        }
    }

    [Serializable]
    internal class DefaultMinMax
    {
        [SerializeField]
        private float Default;

        [SerializeField]
        private float Minimum;

        [SerializeField]
        private float Maximum;

        internal float GetDefault()
        {
            return Default;
        }

        internal float GetMinimum()
        {
            return Minimum;
        }

        internal float GetMaximum()
        {
            return Maximum;
        }
    }
}
