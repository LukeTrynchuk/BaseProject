using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Silverback.SilverShades.Tools
{
    /// <summary>
    /// Texture2DArrayCreatorWindow will create the window
    /// and interface for the tool that will be used to 
    /// generate Texture2DArrays.
    /// </summary>
    public class Texture2DArrayCreatorWindow : EditorWindow
    {
        private string m_imagePath;
        private string m_outputPath;
        private string m_outputName;
        private bool m_normal;
        private bool m_mipmap;

        [MenuItem("Tools/Texture 2D Array Generator")]
        static void Init()
        {
            Texture2DArrayCreatorWindow window = (Texture2DArrayCreatorWindow)EditorWindow.GetWindow(typeof(Texture2DArrayCreatorWindow), false, "Texture 2D Array Generator");
            window.Show();

        }

        private void OnGUI()
        {
            


            GUILayout.Space(15f);

            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            GUILayout.Label("Texture 2D Array Generator", EditorStyles.boldLabel);
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();

            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

            GUILayout.BeginHorizontal();

            if(m_imagePath == null)
            {
                GUILayout.Label("Image Path   : ");
            }
            else
            {
                GUILayout.Label("Image Path   : " + "Assets" + m_imagePath.Replace(Application.dataPath, ""));
            }

            GUILayout.FlexibleSpace();
            if(GUILayout.Button("Choose Path", GUILayout.Width(80)))
            {
                SetPath(out m_imagePath);
            }
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();

            if(m_outputPath == null)
            {
                GUILayout.Label("Output Path : ");   
            }
            else
            {
                GUILayout.Label("Output Path : " + "Assets" + m_outputPath.Replace(Application.dataPath, ""));
            }


            GUILayout.FlexibleSpace();
            if (GUILayout.Button("Choose Path", GUILayout.Width(80)))
            {
                SetPath(out m_outputPath);
            }
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Output Name (no extension) :");
            m_outputName = GUILayout.TextField(m_outputName);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            m_normal = GUILayout.Toggle(m_normal, "Normal Data");
            m_mipmap = GUILayout.Toggle(m_mipmap, "Generate Mip Maps");
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            if(GUILayout.Button("Generate Array", GUILayout.Width(250), GUILayout.Height(35)))
            {
                GenerateButtonPressed();
            }

            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
        }

        private void SetPath(out string Path)
        {
            Path = EditorUtility.OpenFolderPanel("Choose Image Folder", "", "");
        }

        private void GenerateButtonPressed()
        {
            if(!Directory.Exists(m_imagePath) || !Directory.Exists(m_outputPath) || m_outputName.Equals(""))
            {
                EditorUtility.DisplayDialog("Error", "Path does not exist", "Ok");
                return;
            }

            GenerateArray();
        }

        private void GenerateArray()
        {
            List<Texture2D> textures = GetAllFilesAtPath<Texture2D>(m_imagePath);

            if(textures.Count == 0)
            {
                EditorUtility.DisplayDialog("Error", "No Textures Found", "Ok");
                return;
            }

            if(!ValidateTextureSizes(textures))
            {
                EditorUtility.DisplayDialog("Error", "Textures are different sizes", "Ok");
                return;
            }

            if(!ValidateTextureFormat(textures))
            {
                EditorUtility.DisplayDialog("Error", "Textures are different formats", "Ok");


                return;
            }

            CreateArray(textures);

        }

        private void CreateArray(List<Texture2D> textures)
        {
            Texture2DArray texture2DArray = new Texture2DArray(
                textures[0].width,
                textures[0].height,
                textures.Count,
                textures[0].format,
                m_mipmap,
                m_normal);

            texture2DArray.filterMode = FilterMode.Bilinear;
            texture2DArray.wrapMode = TextureWrapMode.Repeat;

            for (int i = 0; i < textures.Count; i++)
            {
                texture2DArray.SetPixels(textures[i].GetPixels(0), i, 0);   
            }

            texture2DArray.Apply();

            string  arrayPaht = "Assets" + m_outputPath.Replace(Application.dataPath, "") + "/" + m_outputName + ".asset";

            AssetDatabase.CreateAsset(texture2DArray, arrayPaht);
        }

        private bool ValidateTextureFormat(List<Texture2D> textures)
        {
            TextureFormat format = textures[0].format;

            foreach(Texture2D texture in textures)
            {
                if (texture.format != format) return false;
            }

            return true;
        }

        private bool ValidateTextureSizes(List<Texture2D> textures)
        {
            int width = textures[0].width;
            int height = textures[0].height;

            foreach(Texture2D texture in textures)
            {
                if(texture.width != width || texture.height != height)
                {
                    return false;
                }
            }

            return true;
        }

        private List<T> GetAllFilesAtPath<T>(string path) where T : class
        {
            List<T> returnList = new List<T>();
            string newPath = path.Replace(Application.dataPath, "") + "/";
            string[] FilePaths = Directory.GetFiles(path + "/");

            foreach (string filePath in FilePaths)
            {
                if (Path.GetExtension(filePath).Equals(".meta")) continue;

                try
                {
                    string file = "Assets" + filePath.Replace(Application.dataPath, "");
                    var obj = AssetDatabase.LoadAssetAtPath(file, typeof(T));
                    returnList.Add(obj as T);

                }
                catch (Exception e)
                {
                    continue;
                }
            }

            for (int i = returnList.Count - 1; i >= 0; i--)
            {
                if (returnList[i] == null) returnList.RemoveAt(i);
            }

            return returnList;
        }

    }
}
