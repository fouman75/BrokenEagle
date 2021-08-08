using System;
using System.Collections.Generic;
using MoreMountains.Tools;
using UnityEngine;

namespace FOUOne.PotionCreator
{
    public class GameManager : MMSingleton<GameManager>
    {
        [SerializeField] private InventoryManager inventoryManager;
        [SerializeField] private MixerManager mixerManager;
        [SerializeField] private List<Ingredient> ingredients;
        
        public InventoryManager Inventory => inventoryManager;
        public MixerManager Mixer => mixerManager;

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
    }
}