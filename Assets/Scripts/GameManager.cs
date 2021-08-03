using System;
using System.Collections.Generic;
using MoreMountains.Tools;
using UnityEngine;

namespace FOUOne.PotionCreator
{
    public class GameManager : MMSingleton<GameManager>
    {
        [SerializeField] private InventoryManager inventoryManager;
        [SerializeField] private List<Ingredient> ingredients;
        
        public InventoryManager Inventory => inventoryManager;

        private void Start()
        {
            InitInventoryFromIngredients();
        }

        private void InitInventoryFromIngredients()
        {
            foreach (var ingredient in ingredients)
            {
                inventoryManager.AddItem(ingredient);
            }
        }

        public void HandleIngredientClicked()
        {
            Debug.Log("Ingredient clicked");
        }
    }
}