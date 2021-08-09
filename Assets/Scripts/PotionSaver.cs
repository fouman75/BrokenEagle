using System.IO;
using UnityEngine;

namespace FOUOne.PotionCreator
{
    public class PotionSaver : MonoBehaviour
    {
        public RenderTexture potionTexture;    
        // Use this for initialization
        public void SaveTexture () {
            byte[] bytes = ToTexture2D(potionTexture).EncodeToPNG();
            var imgPath = Path.Combine(Application.persistentDataPath, "potion.png");
            Debug.Log($"Potion saved to: {imgPath}");
            File.WriteAllBytes(imgPath, bytes);
        }

        private static Texture2D ToTexture2D(RenderTexture rTex)
        {
            Texture2D tex = new Texture2D(512, 512, TextureFormat.RGB24, false);
            RenderTexture.active = rTex;
            tex.ReadPixels(new Rect(0, 0, rTex.width, rTex.height), 0, 0);
            tex.Apply();
            Destroy(tex);//prevents memory leak
            return tex;
        }
        
        void OnGUI()
        {
            if (GUI.Button(new Rect(Screen.width - 200 - 10, Screen.height - 50 - 10, 200, 50), "Save Potion"))
                SaveTexture();
        }
    }
}