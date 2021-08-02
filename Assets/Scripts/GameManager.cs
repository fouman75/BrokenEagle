using MoreMountains.Tools;
using UnityEngine;

namespace FOUOne.PotionCreator
{
    public class GameManager : MMSingleton<GameManager>
    {
        public void HandleIngredientClicked()
        {
            Debug.Log("Ingredient clicked");
        }
    }
}