using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace FOUOne.PotionCreator
{
    public class InventoryCellController : MonoBehaviour, IPointerClickHandler
    {
        public static Action<int> ItemClicked;
        
        [SerializeField] private Image cellIcon;

        public void SetIcon(Sprite icon)
        {
            cellIcon.sprite = icon;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            ItemClicked?.Invoke(transform.GetSiblingIndex());
        }
    }
}