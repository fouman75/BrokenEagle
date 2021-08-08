using System.Collections.Generic;
using UnityEngine;

namespace FOUOne.PotionCreator
{
    public class MixerUIManager : MonoBehaviour
    {
        [SerializeField] private List<MixerCellController> itemCells;

        private void OnEnable()
        {
            MixerManager.ItemChanged += HandleItemChanged;
        }

        private void OnDisable()
        {
            MixerManager.ItemChanged -= HandleItemChanged;
        }

        private void HandleItemChanged(List<int> items)
        {
            Debug.Log("Mixer Manager Item Changed");
            for (var i = 0; i < itemCells.Count; i++)
            {
                Sprite icon = null;
                if (i < items.Count)
                {
                    icon = GameManager.Instance.Inventory.GetItem(items[i]).icon;
                }
                itemCells[i].SetIcon(icon);
            }
        }
    }
}