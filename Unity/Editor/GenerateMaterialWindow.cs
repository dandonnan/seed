namespace Seed.Unity.Editor
{
    using System.Collections.Generic;
    using System.Linq;
    using UnityEditor;
    using UnityEngine;

    public class GenerateMaterialWindow : Editor
    {
        [MenuItem("Seed/Tools/Create Materials from Textures")]
        static void CreateMaterials()
        {
            try
            {
                AssetDatabase.StartAssetEditing();

                IEnumerable<Texture> textures = Selection.GetFiltered(typeof(Texture), SelectionMode.Assets).Cast<Texture>();

                foreach (Texture texture in textures)
                {
                    string path = AssetDatabase.GetAssetPath(texture);

                    string textureFolder = path.Substring(0, path.LastIndexOf("/"));

                    string newMaterialFolder = textureFolder + "/Materials";

                    path = path.Substring(0, path.LastIndexOf("."));
                    path = path.Substring(path.LastIndexOf("/"));

                    string newMaterialLocation = newMaterialFolder + path + ".mat";

                    if (AssetDatabase.IsValidFolder(newMaterialFolder) == false)
                    {
                        AssetDatabase.CreateFolder(textureFolder, "Materials");
                    }

                    if (AssetDatabase.LoadAssetAtPath(newMaterialLocation, typeof(Material)) != null)
                    {
                        Debug.LogWarning($"Did not create new Material '{newMaterialLocation}' as it already exists.");
                        continue;
                    }

                    Material material = new Material(Shader.Find("Standard"));
                    material.mainTexture = texture;

                    AssetDatabase.CreateAsset(material, newMaterialLocation);

                    Debug.Log($"Created new Material '{newMaterialLocation}'.");
                }
            }
            finally
            {
                AssetDatabase.StopAssetEditing();
                AssetDatabase.SaveAssets();
            }
        }
    }
}