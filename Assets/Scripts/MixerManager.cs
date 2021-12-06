using System;
using System.Collections.Generic;
using UnityEngine;

namespace FOUOne.PotionCreator
{
    public class MixerManager : MonoBehaviour
    {
        public static Action<List<Item>> ItemChanged; 
        public int MixIngredients()
        {
            var recipeHash = Potion.GetRecipeHash(_items);
            _items.Clear();
            ItemChanged.Invoke(_items);

            return recipeHash;
        }
        
        [SerializeField] private int maxItems = 3;
        [SerializeField] private CauldronController cauldron;
        
        private readonly List<Item> _items = new List<Item>();

        private void OnEnable()
        {
            InventoryCellController.ItemClicked += HandleItemClicked;
        }

        private void OnDisable()
        {
            InventoryCellController.ItemClicked -= HandleItemClicked;
        }

        private void HandleItemClicked(int index)
        {
            if (_items.Count >= maxItems) return;
            
            Debug.Log($"Adding item {index} to mix");
            _items.Add(GameManager.Instance.Inventory.GetItem(index));
            ItemChanged?.Invoke(_items);

            if (_items.Count == maxItems)
            {
                cauldron.SetReady();
            }
        }
    }
}