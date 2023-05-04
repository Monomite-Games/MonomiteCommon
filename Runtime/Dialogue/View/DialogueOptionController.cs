using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Monomite.Common.Dialogue.View
{
    public class DialogueOptionController : MonoBehaviour
    {
        [SerializeField]
        private Button Button;

        [SerializeField]
        private TextMeshProUGUI ButtonText;

        internal void SetButton(int id, string text, TextStyle style, Action<int> clickAction)
        {
            ButtonText.text = text;
            SetStyle(style);
            Button.onClick.AddListener(() => clickAction(id));
        }

        internal void Disable()
        {
            Button.interactable = false;
        }

        private void SetStyle(TextStyle style)
        {
            ButtonText.font = style.GetFont();
            ButtonText.fontSize = style.GetSize();
            ButtonText.color = style.GetColour();
        }
    }
}
