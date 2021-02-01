using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Monomite.Common
{
    public class FadeInOut : MonoBehaviour
    {
        [SerializeField]
        private Image FadeImage;

        [SerializeField]
        private Color FadeColour;

        [SerializeField]
        private float InitialDelay = 0.5f;

        [SerializeField]
        private float FadeDelay = 1.0f;

        private WaitForSeconds InitialWait;
        private WaitForSeconds FadeWait;

        private void Awake()
        {
            InitialWait = new WaitForSeconds(InitialDelay);
            FadeWait = new WaitForSeconds(FadeDelay);
        }

        public void StartFade()
        {
            StartCoroutine(DoFadeIn());
        }

        private IEnumerator DoFadeIn()
        {
            yield return InitialWait;

            FadeImage.gameObject.SetActive(true);

            FadeImage.color = GameUtils.CopyColourWithAlpha(FadeColour, 0.0f);
            while (FadeImage.color.a < 1.0f)
            {
                FadeImage.color = GameUtils.CopyColourWithAlpha(FadeColour, FadeImage.color.a + (Time.deltaTime / 1f));
                yield return null;
            }

            StartCoroutine(DoFadeOut());
        }

        private IEnumerator DoFadeOut()
        {
            yield return FadeWait;

            FadeImage.color = GameUtils.CopyColourWithAlpha(FadeColour, 1.0f);
            while (FadeImage.color.a > 0.0f)
            {
                FadeImage.color = GameUtils.CopyColourWithAlpha(FadeColour, FadeImage.color.a - (Time.deltaTime / 1f));
                yield return null;
            }

            FadeImage.gameObject.SetActive(false);
        }
    }
}
