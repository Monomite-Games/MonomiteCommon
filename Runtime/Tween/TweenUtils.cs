using ElRaccoone.Tweens.Core;

namespace Monomite.Common.Tween
{
    public static class TweenUtils
    {
        public static void SafeCancel<T>(Tween<T> tween)
        {
            if (tween != null)
            {
                tween.Cancel();
            }
        }
    }
}
