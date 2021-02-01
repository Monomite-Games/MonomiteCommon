using UnityEngine;

namespace Monomite.Common
{
    public abstract class ExtendedPlayerPrefs : MonoBehaviour
    {
        private static readonly bool DefaultBoolValue = false;

        protected bool GetBoolPref(string prefKey)
        {
            int prefValue = PlayerPrefs.GetInt(prefKey, BoolToInt(DefaultBoolValue));
            return IntToBool(prefValue);
        }

        protected void SetBoolPref(string prefKey, bool value)
        {
            int prefValue = BoolToInt(value);
            PlayerPrefs.SetInt(prefKey, prefValue);
        }

        private bool IntToBool(int value)
        {
            return value >= 1;
        }

        private int BoolToInt(bool value)
        {
            return value ? 1 : 0;
        }
    }
}
