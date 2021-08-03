using UnityEngine;
using UnityEngine.UI;

namespace FOUOne.PotionCreator
{
    [CreateAssetMenu(fileName = "Ingredient", menuName = "PotionCreator/Create Ingredient", order = 0)]
    public class Ingredient : Item
    {
        public Sprite icon;
    }
}