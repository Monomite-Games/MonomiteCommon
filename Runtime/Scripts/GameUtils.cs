using System;
using System.Collections.Generic;
using System.Linq;

namespace Monomite.Common
{
    public class GameUtils
    {
        private GameUtils()
        {
            //Empty constructor to avoid utils class instances
        }

        public static T RandomElement<T>(ICollection<T> collection)
        {
            T randomElement;
            if (collection.Count() > 1)
            {
                Random random = new Random();
                int randomIndex = random.Next(0, collection.Count());
                randomElement = collection.ElementAt(randomIndex);
            }
            else
            {
                randomElement = collection.FirstOrDefault();
            }

            return randomElement;
        }

        public static UnityEngine.Color CopyColourWithAlpha(UnityEngine.Color color, float alpha)
        {
            return new UnityEngine.Color(color.r, color.g, color.b, alpha);
        }
    }
}
