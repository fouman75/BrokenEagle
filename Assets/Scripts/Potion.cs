using System;
using System.Collections.Generic;
using UnityEngine;

namespace FOUOne.PotionCreator
{
    [CreateAssetMenu(fileName = "potion", menuName = "PotionCreator/Create Potion", order = 0)]
    public class Potion : Item
    {
        public GameObject potionPrefab;
        public Color sideColor;
        public Color topColor;
        public List<Ingredient> recipe = new List<Ingredient>();
        public EffectType effect;

        public int Hash { get; private set; }

        private void Awake()
        {
            Debug.Log($"{name} is awake");
            Hash = GetRecipeHash();
        }

        private int GetRecipeHash()
        {
            recipe.Sort();
            return string.Join(",", recipe).GetHashCode();
        }
    }
}