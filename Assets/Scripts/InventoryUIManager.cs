using UnityEngine;

namespace FOUOne.PotionCreator
{
    public class InventoryUIManager : MonoBehaviour
    {
        [SerializeField] private Transform inventoryContainer;
        [SerializeField] private GameObject inventoryCell;

        private void OnEnable()
        {
            InventoryManager.ItemAdded += ItemAdded;
        }

        private void OnDisable()
        {
            InventoryManager.ItemAdded -= ItemAdded;
        }

        private void ItemAdded(Item item)
        {
            Debug.Log($"AddItem received by UI: {item.name}");
            var cell = Instantiate(inventoryCell, inventoryContainer);
            cell.name = item.name;
            cell.GetComponent<InventoryCellController>().SetIcon(item.icon);
        }
    }
}