using System;
using System.Collections.Generic;
using UnityEngine;

namespace FOUOne.PotionCreator
{
    [CreateAssetMenu(fileName = "potion", menuName = "PotionCreator/Create Potion", order = 0)]
    public class Potion : Item
    {
        public Color sideColor;
        public Color topColor;
        public List<Ingredient> recipe = new List<Ingredient>();
        public EffectType effect;

        public int Hash { get; private set; }

        private void Awake()
        {
            Hash = GetRecipeHash();
            Debug.Log($"{name} is awake with hash [{Hash}]");
        }

        private int GetRecipeHash()
        {
            recipe.Sort();
            return string.Join(",", recipe).GetHashCode();
        }
    }
}