using ElRaccoone.Tweens;
using ElRaccoone.Tweens.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Monomite.Common.Tween
{
    public static class TweenExtension
    {
        public static Tween<float> AlphaText(TextMeshProUGUI textMeshPro, float to, float time)
        {
            return AlphaGraphic(textMeshPro, to, time);
        }

        public static Tween<float> AlphaGraphic(Graphic graphic, float to, float time)
        {
            return graphic.TweenGraphicAlpha(to, time);
        }

        public static Tween<Vector3> ScaleObject(GameObject gameObject, Vector3 to, float time)
        {
            return gameObject.TweenLocalScale(to, time);
        }

        public static Tween<Vector2> MoveRectPosition(RectTransform rectTransfrom, Vector2 to, float time)
        {
            return rectTransfrom.TweenAnchoredPosition(to, time);
        }
    }
}
