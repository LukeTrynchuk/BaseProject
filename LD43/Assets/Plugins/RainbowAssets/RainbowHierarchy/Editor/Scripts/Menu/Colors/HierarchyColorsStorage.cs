using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using UnityEngine;
using EditorUtility = Borodar.RainbowHierarchy.RainbowHierarchyEditorUtility;

namespace Borodar.RainbowHierarchy
{
    public class HierarchyColorsStorage : ScriptableObject
    {
        private const string RELATIVE_PATH = "Editor/Data/HierarchyColorsStorage.asset";

        public List<HierarchyColor> ColorHierarchyIcons;
        
        //---------------------------------------------------------------------
        // Instance
        //---------------------------------------------------------------------

        private static HierarchyColorsStorage _instance;
        
        [SuppressMessage("ReSharper", "ConvertIfStatementToNullCoalescingExpression")]
        public static HierarchyColorsStorage Instance
        {
            get
            {
                if (_instance == null)
                    _instance = EditorUtility.LoadFromAsset<HierarchyColorsStorage>(RELATIVE_PATH);

                return _instance;
            }
        }

        public Texture2D GetIconByColor(HierarchyColorName color)
        {
            var hierarchyColor = ColorHierarchyIcons.Single(x => x.Color == color);
            return hierarchyColor.Icon;
        }
        
        public Texture2D GetBackgroundByColor(HierarchyColorName color)
        {
            var hierarchyColor = ColorHierarchyIcons.Single(x => x.Color == color);
            return hierarchyColor.Background;
        }
    }
}