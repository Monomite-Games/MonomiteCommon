using ElRaccoone.Tweens.Core;
using Monomite.Common.MessageBus;
using Monomite.Common.Tween;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Monomite.Common.Dialogue.View
{
    public class DialogueLineController : MessageConsumer<DialogueEvent, DialogueState>
    {
        [SerializeField]
        private DialogueViewData ViewData;

        [SerializeField]
        private GameObject Panel;

        [SerializeField]
        private TextMeshProUGUI Name;

        [SerializeField]
        private TextMeshProUGUI Text;

        private WaitForSeconds TypewriterWait;
        private bool SpeedUp = false;

        private readonly WaitForSeconds NoWait = new WaitForSeconds(0.0f);

        private void Start()
        {
            DisablePanel();
            Panel.transform.localScale = Vector3.zero;
        }

        protected override void StateListener(DialogueState message)
        {
            if (message is DialogueNextLineRequestedButNotPrepared)
            {
                SpeedUpLine();
            }
        }

        private void SpeedUpLine()
        {
            SpeedUp = true;
        }

        private void EnablePanel()
        {
            Panel.SetActive(true);
        }

        private void DisablePanel()
        {
            Panel.SetActive(false);
        }

        internal void Clear(bool popOut = false)
        {
            Name.SetText(string.Empty);
            Text.SetText(string.Empty);

            if (popOut)
            {
                PanelPopOut();
            }
            else
            {
                DisablePanel();
            }
        }

        internal void SetText(string name, string text, TextStyle style)
        {
            EnablePanel();
            PanelPopIn();

            SpeedUp = false;
            SetStyle(style);
            Name.SetText(name);
            StartCoroutine(DoTypewriterShow(text));
        }

        private void PanelPopIn()
        {
            TweenExtension.ScaleObject(Panel, Vector3.one, ViewData.GetScaleTimeSeconds()).SetEase(EaseType.BackOut);
        }

        private void PanelPopOut()
        {
            TweenExtension.ScaleObject(Panel, Vector3.zero, ViewData.GetScaleTimeSeconds()).SetEase(EaseType.BackIn);
        }

        private void SetStyle(TextStyle style)
        {
            Text.font = style.GetFont();
            Text.fontSize = style.GetSize();
            Text.color = style.GetColour();

            TypewriterWait = new WaitForSeconds(style.GetDelaySeconds());
        }

        private IEnumerator DoTypewriterShow(string text)
        {
            Text.maxVisibleCharacters = 0;
            Text.SetText(text);
            Text.ForceMeshUpdate();
            int totalCharacters = Text.textInfo.characterCount;

            for (int index = 0; index < totalCharacters; index++)
            {
                Text.maxVisibleCharacters += 1;
                yield return SpeedUp ? NoWait : TypewriterWait;
            }

            if (!SpeedUp)
            {
                yield return new WaitForSeconds(ViewData.GetNextLineDelaySeconds());
            }

            EmitEvent(new PrepareForNextDialogueLine());
        }
    }
}