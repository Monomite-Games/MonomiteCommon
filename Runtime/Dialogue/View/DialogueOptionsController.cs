using Monomite.Common.MessageBus;
using System.Collections.Generic;
using UnityEngine;

namespace Monomite.Common.Dialogue.View
{
    public class DialogueOptionsController : EventEmitter<DialogueEvent, DialogueState>
    {
        [SerializeField]
        private GameObject Panel;

        [SerializeField]
        private GameObject ButtonsHolder;

        [SerializeField]
        private GameObject ButtonPrefab;

        private IList<DialogueOptionController> Buttons;

        private void Start()
        {
            DisablePanel();
            transform.localScale = new Vector3(0.0f, 0.0f, 0.0f);
        }

        private void EnablePanel()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Panel.SetActive(true);
        }

        private void DisablePanel()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Panel.SetActive(false);
        }

        private void DisableButtons()
        {
            foreach (DialogueOptionController optionButton in Buttons)
            {
                optionButton.Disable();
            }
        }

        internal void Clear()
        {
            foreach (Transform child in ButtonsHolder.transform)
            {
                Destroy(child.gameObject);
            }
            DisablePanel();
        }

        internal void StartOptions()
        {
            EnablePanel();
            Buttons = new List<DialogueOptionController>();
        }

        internal void AddOption(int id, string text, TextStyle style)
        {
            GameObject buttonObject = Instantiate(ButtonPrefab, ButtonsHolder.transform);

            DialogueOptionController buttonChoice = buttonObject.GetComponent<DialogueOptionController>();
            buttonChoice.SetButton(id, text, style, SelectOption);

            Buttons.Add(buttonChoice);
        }

        private void SelectOption(int id)
        {
            DisableButtons();
            EmitEvent(new SelectDialogueOption(id));
        }
    }
}