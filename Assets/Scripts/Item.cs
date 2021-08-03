using UnityEngine;

namespace FOUOne.PotionCreator
{
    public abstract class Item : ScriptableObject
    {
        public string id; 
        public string description;
        public Sprite icon;
    }
}