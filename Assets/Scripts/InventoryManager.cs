using System;
using System.Collections.Generic;
using UnityEngine;

namespace FOUOne.PotionCreator
{
    public class InventoryManager: MonoBehaviour
    {
        public static Action<Item> ItemAdded;
        
        private readonly List<Item> _items = new List<Item>();

        public void AddItem(Item item)
        {
            _items.Add(item);
            ItemAdded?.Invoke(item);
        }
    }
}