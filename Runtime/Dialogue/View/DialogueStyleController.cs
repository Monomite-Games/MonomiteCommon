using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Monomite.Common.Dialogue.View
{
    [CreateAssetMenu(menuName = "Dialogue/Dialogue Style Controller", fileName = "Dialogue Style Controller")]
    internal class DialogueStyleController : ScriptableObject
    {
        [SerializeField]
        private DialogueViewData ViewData;

        [SerializeField]
        private DialogueStyle DefaultStyle;

        [SerializeField]
        private List<CharacterDialogueStyle> CharacterStyles;

        internal DialogueStyle GetStyle(string characterName)
        {
            DialogueStyle style = DefaultStyle;

            CharacterDialogueStyle characterStyle = CharacterStyles.FirstOrDefault(style => characterName.Equals(style.GetName()));
            if (characterStyle != null)
            {
                style = characterStyle.GetStyle();
            }

            style.NormaliseDelay(ViewData.GetTextDelay());
            style.NormaliseSize(ViewData.GetTextSize());
            style.UpdateOptionals(DefaultStyle);

            return style;
        }
    }
}
