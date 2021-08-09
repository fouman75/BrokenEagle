using System;
using System.Collections.Generic;
using UnityEngine;

namespace FOUOne.PotionCreator
{
    [CreateAssetMenu(fileName = "potion", menuName = "PotionCreator/Create Potion", order = 0)]
    public class Potion : Item, IComparable
    {
        public Color sideColor;
        public Color topColor;
        public List<Item> recipe = new List<Item>();
        public EffectType effect;

        public int Hash { get; private set; }
        
        public static int GetRecipeHash(List<Item> items)
        {
            items.Sort();
            return string.Join(",", items).GetHashCode();
        }

        private void Awake()
        {
            Hash = GetRecipeHash(recipe);
            Debug.Log($"{name} is awake with hash [{Hash}]");
        }
    }
}