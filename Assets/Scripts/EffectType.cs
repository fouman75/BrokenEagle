using UnityEngine;

namespace FOUOne.PotionCreator
{
    [CreateAssetMenu(fileName = "Effect", menuName = "PotionCreator/Create EffectType", order = 0)]
    public class EffectType : ScriptableObject
    {
        public ParticleSystem vfx;
    }
}