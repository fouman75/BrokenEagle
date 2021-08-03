using System;
using UnityEngine;

namespace FOUOne.PotionCreator
{
    public class PotionController : MonoBehaviour, IApplicable
    {
        [SerializeField] private Potion potionData;
        [SerializeField] private GameObject liquid;
        private static readonly int SideColor = Shader.PropertyToID("_SideColor");
        private static readonly int TopColor = Shader.PropertyToID("_TopColor");

        private void Start()
        {
            var mat = liquid.GetComponent<Renderer>().material;
            mat.SetColor(SideColor, potionData.sideColor);
            mat.SetColor(TopColor, potionData.topColor);
        }

        public void Apply(GameObject actor)
        {
            throw new NotImplementedException();
        }
    }
}