using System;
using TMPro;
using UnityEngine;

namespace Monomite.Common.Dialogue.View
{
    [Serializable]
    internal class CharacterDialogueStyle
    {
        [SerializeField]
        private string Name;

        [SerializeField]
        private DialogueStyle Style;

        internal string GetName()
        {
            return Name;
        }

        internal DialogueStyle GetStyle()
        {
            return Style;
        }
    }

    [Serializable]
    internal class DialogueStyle
    {
        [Tooltip("Afecta velocidad de texto y de habla\nPositivo para que vaya más lento\nNegativo para que vaya más rápido")]
        [Range(-1.0f, 1.0f)]
        [SerializeField]
        private float RelativeDelay;

        [Tooltip("Afecta tamaño de texto y volumen de habla\nPositivo para que sea más grande\nNegativo para que sea más pequeño")]
        [Range(-1.0f, 1.0f)]
        [SerializeField]
        private float RelativeIntensity;

        [SerializeField]
        private TextStyle TextStyle;

        internal TextStyle GetTextStyle()
        {
            return TextStyle;
        }

        internal void NormaliseDelay(DefaultMinMax delay)
        {
            float normalisedDelay = NormaliseRelative(this.RelativeDelay, delay.GetDefault(), delay.GetMinimum(), delay.GetMaximum());

            TextStyle.SetDelaySeconds(normalisedDelay);
        }

        internal void NormaliseSize(DefaultMinMax size)
        {
            float normalisedSize = NormaliseRelative(this.RelativeIntensity, size.GetDefault(), size.GetMinimum(), size.GetMaximum());

            TextStyle.SetSize(normalisedSize);
        }

        internal void UpdateOptionals(DialogueStyle defaultStyle)
        {
            TextStyle.UpdateOptionals(defaultStyle.GetTextStyle());
        }

        private static float NormaliseRelative(float relativeValue, float defaultValue, float minValue, float maxValue)
        {
            float percentage = 1.0f + relativeValue;
            float rawValue = defaultValue * percentage;

            float clampedVolume = Mathf.Clamp(rawValue, minValue, maxValue);

            return clampedVolume;
        }
    }

    [Serializable]
    internal class TextStyle
    {
        [Tooltip("Afecta a la fuente del texto\nSi se deja vacío se usara la fuente por defecto")]
        [SerializeField]
        private TMP_FontAsset Font;

        [Tooltip("Afecta al color del texto")]
        [SerializeField]
        private Color Colour;

        [NonSerialized]
        private float Size;

        [NonSerialized]
        private float DelaySeconds;

        internal Color GetColour()
        {
            return Colour;
        }

        internal TMP_FontAsset GetFont()
        {
            return Font;
        }

        internal float GetSize()
        {
            return Size;
        }

        internal void SetSize(float size)
        {
            Size = size;
        }

        internal float GetDelaySeconds()
        {
            return DelaySeconds;
        }

        internal void SetDelaySeconds(float delaySeconds)
        {
            DelaySeconds = delaySeconds;
        }

        internal void UpdateOptionals(TextStyle defaultStyle)
        {
            if (Font == null)
            {
                Font = defaultStyle.Font;
            }
        }
    }
}