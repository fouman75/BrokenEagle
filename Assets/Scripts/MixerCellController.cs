using UnityEngine;
using UnityEngine.UI;

namespace FOUOne.PotionCreator
{
    public class MixerCellController: MonoBehaviour
    {
        [SerializeField] private Image icon;

        public void SetIcon(Sprite itemIcon)
        {
            icon.sprite = itemIcon;
        }
    }
}