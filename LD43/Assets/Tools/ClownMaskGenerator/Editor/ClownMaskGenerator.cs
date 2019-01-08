using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace DogHouse.Core.Tools
{
    /// <summary>
    /// ClownMaskGenerator is an editor tool that
    /// takes serveral gray scale images and combines 
    /// them into a single clown mask. 
    /// </summary>
    public class ClownMaskGenerator : EditorWindow
    {
        #region Private Variables
        private static List<TextureColorPair> m_pairs;
        private static TextureColorPair m_newPair;
        private static Vector2 m_vertScrollPos;
        private static string m_path = "";
        #endregion

        #region Main Methods
        [MenuItem("Tools/Core/Graphic/Clown Mask Generator")]
        static void Init()
        {
            ClownMaskGenerator window = (ClownMaskGenerator)EditorWindow.GetWindow(typeof(ClownMaskGenerator), false, "Clown Mask Generator");
            window.Show();
        }

        private void OnGUI()
        {
            if (m_pairs == null) InitializeData();

            m_vertScrollPos = EditorGUILayout.BeginScrollView(m_vertScrollPos);

            RenderCommandButtons();

            GUILayout.BeginHorizontal();
            GUILayout.Label(m_path);
            if(GUILayout.Button("Set Path"))
            {
                m_path = GetOutputPath();
            }
            GUILayout.EndHorizontal();

            for (int i = 0; i < m_pairs.Count; i++)
            {
                m_pairs[i] = RenderTextureColorPair(m_pairs[i]);
            }

            m_newPair = RenderTextureColorPair(m_newPair);
            if (m_newPair.Texture != null)
            {
                TextureColorPair newPair = new TextureColorPair();
                newPair.Texture = m_newPair.Texture;
                newPair.Color = m_newPair.Color;
                m_pairs.Add(newPair);

                m_newPair.Texture = null;
                m_newPair.Color = default(Color);
            }

            EditorGUILayout.EndScrollView();
        }

        private void OnInspectorUpdate()
        {
            Repaint();
        }
        #endregion

        #region Utility Methods
        private void InitializeData()
        {
            m_pairs = new List<TextureColorPair>();
            m_newPair = new TextureColorPair();
        }

        private void RenderCommandButtons()
        {
            GUILayout.Space(15);
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Revert", EditorStyles.miniButtonLeft)) Revert();
            if (GUILayout.Button("Generate", EditorStyles.miniButtonRight)) Generate();
            EditorGUILayout.EndHorizontal();
            GUILayout.Space(15);
        }

        private TextureColorPair RenderTextureColorPair(TextureColorPair pair)
        {
            GUILayout.BeginHorizontal();
            pair.Texture = TextureField("Texture", pair.Texture);

            GUILayout.BeginVertical();
            GUILayout.Space(20);
            pair.Color = EditorGUILayout.ColorField(pair.Color, null);

            GUILayout.EndVertical();

            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            return pair;
        }

        private static Texture2D TextureField(string name, Texture2D texture)
        {
            GUILayout.BeginVertical();

            var style = new GUIStyle(GUI.skin.label);
            style.alignment = TextAnchor.UpperCenter;
            style.fixedWidth = 70;
            GUILayout.Label(name, style);
            var result = (Texture2D)EditorGUILayout.ObjectField(texture, typeof(Texture2D), false, GUILayout.Width(70), GUILayout.Height(70));
            GUILayout.EndVertical();

            return result;
        }

        private void Revert()
        {
            InitializeData();
        }

        private void Generate()
        {
            if (!ErrorCheck()) return;
            if (string.IsNullOrEmpty(m_path)) return;
            GenerateClownTexture();
        }
        #endregion

        #region Generation Methods
        private bool ErrorCheck()
        {
            return HasAtleastOneSlotWithTexture() && AllImagesSameSize();
        }

        private bool HasAtleastOneSlotWithTexture()
        {
            bool valid = GetNonEmptyPairs().Count > 0;
            if (!valid) Debug.LogError("Clown Mask Generator : No Textures Available.");
            return valid;
        }

        private bool AllImagesSameSize()
        {
            List<Texture2D> textures = GetTextures();
            bool sameSize = true;
            int width = textures[0].width;
            int height = textures[0].height;

            foreach (Texture2D texture in textures)
            {
                if (texture.width != width || texture.height != height)
                {
                    sameSize = false;
                }
            }

            if (!sameSize) Debug.LogError("Clown Mask Generator : Different Texture Sizes.");
            return sameSize;
        }

        private static List<TextureColorPair> GetNonEmptyPairs()
        {
            return m_pairs.Where(x => x.Texture != null).ToList();
        }

        private List<Texture2D> GetTextures()
        {
            List<TextureColorPair> pairs = GetNonEmptyPairs();
            List<Texture2D> textures = new List<Texture2D>();

            foreach (TextureColorPair pair in pairs)
                textures.Add(pair.Texture);
            return textures;
        }

        private List<Color> GetColors()
        {
            List<TextureColorPair> pairs = GetNonEmptyPairs();
            List<Color> colors = new List<Color>();
            foreach (TextureColorPair pair in pairs)
                colors.Add(pair.Color);
            return colors;
        }

        private static string GetOutputPath()
        {
            var path = EditorUtility.SaveFilePanel(
                "Save texture as PNG",
                "",
                "texture" + ".png",
                "png");
            
            return path;
        }

        private void GenerateClownTexture()
        {
            List<Texture2D> textures = GetTextures();

            Texture2D newTexture = new Texture2D(textures[0].width,
                                                 textures[0].height);

            Color[] newColorArray = newTexture.GetPixels();

            for (int i = 0; i < newColorArray.Length; i++)
            {
                newColorArray[i] = Color.black;
            }

            List<Color[]> colors = new List<Color[]>();
            foreach(Texture2D texture in textures)
            {
                colors.Add(texture.GetPixels());
            }

            List<Color> maskColors = GetColors();

            for (int curTexture = 0; curTexture < colors.Count; curTexture++)
            {
                for (int i = 0; i < newColorArray.Length; i++)
                {
                    if (newColorArray[i].grayscale > colors[curTexture][i].grayscale) continue;

                    newColorArray[i] = colors[curTexture][i] * maskColors[curTexture];
                }
            }

            newTexture.SetPixels(newColorArray);

            var pngData = newTexture.EncodeToPNG();
            if (pngData != null) File.WriteAllBytes(m_path, pngData);
            AssetDatabase.Refresh();
        }
        #endregion
    }

    public struct TextureColorPair
    {
        public Texture2D Texture;
        public Color Color;
    }
}
