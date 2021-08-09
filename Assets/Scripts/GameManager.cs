using System;
using System.Collections.Generic;
using System.Linq;
using MoreMountains.Tools;
using UnityEngine;

namespace FOUOne.PotionCreator
{
    public class GameManager : MMSingleton<GameManager>
    {
        [SerializeField] private InventoryManager inventoryManager;
        [SerializeField] private MixerManager mixerManager;
        [SerializeField] private List<Ingredient> ingredients;
        [SerializeField] private List<PotionController> potions;
        [SerializeField] private Transform potionContainer;
        
        public InventoryManager Inventory => inventoryManager;
        public MixerManager Mixer => mixerManager;

        private GameObject _currentPotion;

        public void ShowPotion()
        {
            if (_currentPotion != null) _currentPotion.SetActive(true);   
        }
        
        public bool CreatePotion()
        {
            if (_currentPotion != null)
            {
                _currentPotion.transform.SetParent(null);
                Destroy(_currentPotion);
                _currentPotion = null;
            }
            
            potionContainer.transform.rotation = Quaternion.identity;

            var recipeHash = Mixer.MixIngredients();
            var potion = potions.Find(p => p.Potion.Hash == recipeHash);
            if (potion == null)
            {
                Debug.Log("Creating dud potion");
                return false;
            }

            Debug.Log($"Creating {potion.name}");
            _currentPotion = Instantiate(potion.gameObject, potionContainer);
            _currentPotion.SetActive(false);
            
            return true;
        }
        
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