using System;
using UnityEngine;

namespace FOUOne.PotionCreator
{
    public abstract class Item : ScriptableObject, IComparable
    {
        public string id; 
        public string description;
        public Sprite icon;
        public int CompareTo(object obj)
        {
            return string.Compare(id, (obj as Item)?.id, StringComparison.Ordinal);
        }
    }
}