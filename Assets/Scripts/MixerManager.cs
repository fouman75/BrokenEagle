using System;
using System.Collections.Generic;
using UnityEngine;

namespace FOUOne.PotionCreator
{
    public class MixerManager : MonoBehaviour
    {
        public static Action<List<int>> ItemChanged; 
        
        [SerializeField] private int maxItems = 3;
        
        private readonly List<int> _items = new List<int>();

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
            _items.Add(index);
            ItemChanged?.Invoke(_items);
        }
    }
}