using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System;

namespace Silverback.SilverShades.Tools
{
    /// <summary>
    /// The Texture Combiner is a tool that
    /// is built to combine up to 4 textures
    /// together. 
    /// </summary>
    public class TextureCombiner : EditorWindow
    {
        #region Private Variables
        private static Texture2D[] m_textures;
        private static bool[,] m_channelMatrix;
        private static Texture2D m_finalTexture;
        #endregion

        #region Main Methods
        [MenuItem("Tools/Texture Combiner")]
        static void Init()
        {
            TextureCombiner window = (TextureCombiner)EditorWindow.GetWindow(typeof(TextureCombiner), false, "Texture Combiner");
            window.Show();
        }

        private void OnGUI()
        {
            if (m_textures == null || m_channelMatrix == null) InitalizeData();
            RenderCommandButtons();

            for (int i = 0; i < 4; i++)
            {
                RenderTextureSlot(i);
                GUILayout.Space(10);
            }

            //RenderFinalImage();
        }

        #endregion

        #region Utility Methods
        private static void RenderFinalImage()
        {
            if (m_finalTexture == null) return;

            //Texture2D preview = AssetPreview.GetAssetPreview(m_finalTexture);

            //Rect rect = GUILayoutUtility.GetRect(200, 200);
            //Material material = new Material(Shader.Find("Unlit/Texture"));
            //EditorGUI.DrawPreviewTexture(rect, m_finalTexture, material, ScaleMode.ScaleToFit);
            //GUILayout.Label(preview);

            GUILayout.Label(m_finalTexture);
        }

        private static bool RenderChannelButton(bool value, Color channelColor)
        {
            var oldColor = GUI.backgroundColor;
            GUI.backgroundColor = channelColor;
            value = EditorGUILayout.Toggle("", value, EditorStyles.miniButton, GUILayout.Width(30));
            GUI.backgroundColor = oldColor;
            return value;
        }

        private static void RenderCommandButtons()
        {
            GUILayout.Space(15);
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Revert", EditorStyles.miniButtonLeft)) Revert();
            if (GUILayout.Button("Generate", EditorStyles.miniButtonRight)) Generate();
            EditorGUILayout.EndHorizontal();
            GUILayout.Space(15);
        }

        private static void RenderTextureSlot(int index)
        {
            GUILayout.BeginHorizontal();

            GUILayout.Space(15);
            m_textures[index] = TextureField("Texture " + index.ToString(), m_textures[index]);
            GUILayout.Space(5);
            Color c;

            if(m_textures[index] != null)
            {
                GUILayout.BeginVertical();
                GUILayout.Space(20);
                c = (m_channelMatrix[index, 0]) ? Color.red : Color.black;
                m_channelMatrix[index, 0] = !RenderChannelButton(!m_channelMatrix[index, 0], c);
                GUILayout.EndVertical();

                GUILayout.BeginVertical();
                GUILayout.Space(20);
                c = (m_channelMatrix[index, 1]) ? Color.green : Color.black;
                m_channelMatrix[index, 1] = !RenderChannelButton(!m_channelMatrix[index, 1], c);
                GUILayout.EndVertical();

                GUILayout.BeginVertical();
                GUILayout.Space(20);
                c = (m_channelMatrix[index, 2]) ? Color.blue : Color.black;
                m_channelMatrix[index, 2] = !RenderChannelButton(!m_channelMatrix[index, 2], c);
                GUILayout.EndVertical();

                GUILayout.BeginVertical();
                GUILayout.Space(20);
                c = (m_channelMatrix[index, 3]) ? Color.white : Color.black;
                m_channelMatrix[index, 3] = !RenderChannelButton(!m_channelMatrix[index, 3], c);
                GUILayout.EndVertical();
            }

            GUILayout.Space(5);
            GUILayout.FlexibleSpace();

            GUILayout.EndHorizontal();
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

        private static void InitalizeData()
        {
            m_textures = new Texture2D[4];
            m_channelMatrix = new bool[4, 4];

            for (int i = 0; i < 4; i++) m_textures[i] = null;
        }

        private static void Revert()
        {
            InitalizeData();
        }

        private static void Generate()
        {
            if (!ErrorCheck()) return;
            string path = GetOutputPath();
            if (string.IsNullOrEmpty(path)) return;
            GenerateTexture(path);
        }
        #endregion

        #region Generation Methods
        private static bool ErrorCheck()
        {
            return AtleastOneChannel() && AtleastOneTextureCheck() && AllImagesSameSize() &&
                NoDuplicateChannels() && ChannelsHaveTextures();
        }

        private static bool AtleastOneTextureCheck()
        {
            bool atleastOneTexture = false;
            for (int i = 0; i < 4; i++)
            {
                if (m_textures[i] != null) atleastOneTexture = true;
            }

            if (!atleastOneTexture) Debug.LogError("Texture Combiner : No Textures Selected.");

            return atleastOneTexture;
        }

        private static bool AtleastOneChannel()
        {
            bool result = false;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    result |= m_channelMatrix[i, j];
                }
            }

            if (!result) Debug.LogError("Texture Combiner : No Channel Selected.");
            return result;
        }

        private static bool AllImagesSameSize()
        {
            List<Texture2D> textures = new List<Texture2D>();
            for (int i = 0; i < 4; i++)
            {
                if (m_textures[i] != null) textures.Add(m_textures[i]);
            }

            bool sameSize = true;
            int width = textures[0].width;
            int height = textures[0].height;

            foreach(Texture2D texture in textures)
            {
                if(texture.width != width || texture.height != height)
                {
                    sameSize = false;
                }
            }

            if (!sameSize) Debug.LogError("Texture Combiner : Different Texture Sizes.");
            return sameSize;
        }

        private static bool NoDuplicateChannels()
        {
            for (int i = 0; i < 4; i++)
            {
                bool res = m_channelMatrix[0, i];

                for (int j = 1; j < 4; j++)
                {
                    if (res && m_channelMatrix[j, i])
                    {
                        Debug.LogError("Texture Combiner : Duplicate Channels");
                        return false;
                    }
                    res |= m_channelMatrix[j, i];
                }
            }
            return true;
        }

        private static bool ChannelsHaveTextures()
        {
            for (int i = 0; i < 4; i++)
            {
                if(m_channelMatrix[i,0] || m_channelMatrix[i,1] || m_channelMatrix[i,2] || 
                  m_channelMatrix[i, 3])
                {
                    if(m_textures[i] == null)
                    {
                        Debug.LogError("Texture Combiner : Texture missing for channel.");
                        return false;
                    }
                }
            }
            return true;
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

        private static void GenerateTexture(string path)
        {
            List<Texture2D> textures = new List<Texture2D>();
            for (int i = 0; i < 4; i++)
            {
                if (m_textures[i] != null) textures.Add(m_textures[i]);
            }

            m_finalTexture = new Texture2D(textures[0].width, textures[0].height);
            Texture2D redTexture = (GetChannelIndex(0) > -1) ? m_textures[GetChannelIndex(0)] : null;
            Texture2D greenTexture = (GetChannelIndex(1) > -1) ? m_textures[GetChannelIndex(1)] : null;
            Texture2D blueTexture = (GetChannelIndex(2) > -1) ? m_textures[GetChannelIndex(2)] : null;
            Texture2D alphaTexture = (GetChannelIndex(3) > -1) ? m_textures[GetChannelIndex(3)] : null;
            Color color = new Color();

            for (int i = 0; i < m_finalTexture.width; i++)
            {
                for (int j = 0; j < m_finalTexture.height; j++)
                {
                    color.r = (redTexture == null)      ? 0f : redTexture.GetPixel(i, j).r;
                    color.g = (greenTexture == null)    ? 0f : greenTexture.GetPixel(i, j).g;
                    color.b = (blueTexture == null)     ? 0f : blueTexture.GetPixel(i, j).b;
                    color.a = (alphaTexture == null)    ? 0f : alphaTexture.GetPixel(i, j).a;
                    m_finalTexture.SetPixel(i, j, color);
                }
            }

            var pngData = m_finalTexture.EncodeToPNG();
            if (pngData != null) File.WriteAllBytes(path, pngData);

            AssetDatabase.Refresh();
        }

        private static int GetChannelIndex(int row)
        {
            if (m_channelMatrix[0, row]) return 0;
            if (m_channelMatrix[1, row]) return 1;
            if (m_channelMatrix[2, row]) return 2;
            if (m_channelMatrix[3, row]) return 3;

            return -1;
        }
        #endregion
    }
}
