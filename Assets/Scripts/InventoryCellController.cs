using UnityEngine;
using UnityEngine.UI;

namespace FOUOne.PotionCreator
{
    public class InventoryCellController : MonoBehaviour
    {
        [SerializeField] private Image cellIcon;

        public void SetIcon(Sprite icon)
        {
            cellIcon.sprite = icon;
        }
    }
}