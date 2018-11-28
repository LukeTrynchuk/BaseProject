using UnityEditor;
using UnityEngine;

namespace Borodar.RainbowHierarchy
{
    public static class RainbowHierarchyBackgroundsMenu
    {
        private const string MENU_COLORIZE = "Colors/";
        private const string MENU_CUSTOM = "Custom";
        private const string MENU_NONE = "None";
        
        // Colors
        private static readonly GUIContent COLOR_RED = new GUIContent(MENU_COLORIZE + "Red");
        private static readonly GUIContent COLOR_VERMILION = new GUIContent(MENU_COLORIZE + "Vermilion");
        private static readonly GUIContent COLOR_ORANGE = new GUIContent(MENU_COLORIZE + "Orange");
        private static readonly GUIContent COLOR_AMBER = new GUIContent(MENU_COLORIZE + "Amber");
        private static readonly GUIContent COLOR_YELLOW = new GUIContent(MENU_COLORIZE + "Yellow");
        private static readonly GUIContent COLOR_LIME = new GUIContent(MENU_COLORIZE + "Lime");
        private static readonly GUIContent COLOR_CHARTREUSE = new GUIContent(MENU_COLORIZE + "Chartreuse");
        private static readonly GUIContent COLOR_HARLEQUIN = new GUIContent(MENU_COLORIZE + "Harlequin");
        private static readonly GUIContent COLOR_GREEN = new GUIContent(MENU_COLORIZE + "Green");
        private static readonly GUIContent COLOR_EMERALD = new GUIContent(MENU_COLORIZE + "Emerald");
        private static readonly GUIContent COLOR_SPRING_GREEN = new GUIContent(MENU_COLORIZE + "Spring-green");
        private static readonly GUIContent COLOR_AQUAMARINE = new GUIContent(MENU_COLORIZE + "Aquamarine");
        private static readonly GUIContent COLOR_CYAN = new GUIContent(MENU_COLORIZE + "Cyan");
        private static readonly GUIContent COLOR_SKY_BLUE = new GUIContent(MENU_COLORIZE + "Sky-blue");
        private static readonly GUIContent COLOR_AZURE = new GUIContent(MENU_COLORIZE + "Azure");
        private static readonly GUIContent COLOR_CERULEAN = new GUIContent(MENU_COLORIZE + "Cerulean");
        private static readonly GUIContent COLOR_BLUE = new GUIContent(MENU_COLORIZE + "Blue");
        private static readonly GUIContent COLOR_INDIGO = new GUIContent(MENU_COLORIZE + "Indigo");
        private static readonly GUIContent COLOR_VIOLET = new GUIContent(MENU_COLORIZE + "Violet");
        private static readonly GUIContent COLOR_PURPLE = new GUIContent(MENU_COLORIZE + "Purple");
        private static readonly GUIContent COLOR_MAGENTA = new GUIContent(MENU_COLORIZE + "Magenta");
        private static readonly GUIContent COLOR_FUCHSIA = new GUIContent(MENU_COLORIZE + "Fuchsia");
        private static readonly GUIContent COLOR_ROSE = new GUIContent(MENU_COLORIZE + "Rose");
        private static readonly GUIContent COLOR_CRIMSON = new GUIContent(MENU_COLORIZE + "Crimson");
        // Custom
        private static readonly GUIContent SELECT_CUSTOM = new GUIContent(MENU_CUSTOM);        
        // None
        private static readonly GUIContent SELECT_NONE = new GUIContent(MENU_NONE);

        //---------------------------------------------------------------------
        // Public
        //---------------------------------------------------------------------

        public static void ShowDropDown(Rect position, HierarchyItem hierarchyItem)
        {
            var menu = new GenericMenu();

            // Colors
            menu.AddItem(COLOR_RED,           false, RedCallback,          hierarchyItem);
            menu.AddItem(COLOR_VERMILION,     false, VermilionCallback,    hierarchyItem);
            menu.AddItem(COLOR_ORANGE,        false, OrangeCallback,       hierarchyItem);
            menu.AddItem(COLOR_AMBER,         false, AmberCallback,        hierarchyItem);
            menu.AddItem(COLOR_YELLOW,        false, YellowCallback,       hierarchyItem);
            menu.AddItem(COLOR_LIME,          false, LimeCallback,         hierarchyItem);
            menu.AddItem(COLOR_CHARTREUSE,    false, ChartreuseCallback,   hierarchyItem);
            menu.AddItem(COLOR_HARLEQUIN,     false, HarlequinCallback,    hierarchyItem);
            menu.AddSeparator(MENU_COLORIZE);
            menu.AddItem(COLOR_GREEN,         false, GreenCallback,        hierarchyItem);
            menu.AddItem(COLOR_EMERALD,       false, EmeraldCallback,      hierarchyItem);
            menu.AddItem(COLOR_SPRING_GREEN,  false, SpringGreenCallback,  hierarchyItem);
            menu.AddItem(COLOR_AQUAMARINE,    false, AquamarineCallback,   hierarchyItem);
            menu.AddItem(COLOR_CYAN,          false, CyanCallback,         hierarchyItem);
            menu.AddItem(COLOR_SKY_BLUE,      false, SkyBlueCallback,      hierarchyItem);
            menu.AddItem(COLOR_AZURE,         false, AzureCallback,        hierarchyItem);
            menu.AddItem(COLOR_CERULEAN,      false, CeruleanCallback,     hierarchyItem);
            menu.AddSeparator(MENU_COLORIZE);
            menu.AddItem(COLOR_BLUE,          false, BlueCallback,         hierarchyItem);
            menu.AddItem(COLOR_INDIGO,        false, IndigoCallback,       hierarchyItem);
            menu.AddItem(COLOR_VIOLET,        false, VioletCallback,       hierarchyItem);
            menu.AddItem(COLOR_PURPLE,        false, PurpleCallback,       hierarchyItem);
            menu.AddItem(COLOR_MAGENTA,       false, MagentaCallback,      hierarchyItem);
            menu.AddItem(COLOR_FUCHSIA,       false, FuchsiaCallback,      hierarchyItem);
            menu.AddItem(COLOR_ROSE,          false, RoseCallback,         hierarchyItem);
            menu.AddItem(COLOR_CRIMSON,       false, CrimsonCallback,      hierarchyItem);

            // Separator
            menu.AddSeparator(string.Empty);
            // Custom
            menu.AddItem(SELECT_CUSTOM,  false, SelectCustomCallback, hierarchyItem);            
            // None
            menu.AddItem(SELECT_NONE,  false, SelectNoneCallback, hierarchyItem);
            
            menu.DropDown(position);
        }
        
        //---------------------------------------------------------------------
        // Callbacks
        //---------------------------------------------------------------------
        
        // Colors

        private static void RedCallback(object item)
        { Colorize(HierarchyColorName.Red, item as HierarchyItem); }

        private static void VermilionCallback(object item)
        { Colorize(HierarchyColorName.Vermilion, item as HierarchyItem); }

        private static void OrangeCallback(object item)
        { Colorize(HierarchyColorName.Orange, item as HierarchyItem); }

        private static void AmberCallback(object item)
        { Colorize(HierarchyColorName.Amber, item as HierarchyItem); }

        private static void YellowCallback(object item)
        { Colorize(HierarchyColorName.Yellow, item as HierarchyItem); }

        private static void LimeCallback(object item)
        { Colorize(HierarchyColorName.Lime, item as HierarchyItem); }

        private static void ChartreuseCallback(object item)
        { Colorize(HierarchyColorName.Chartreuse, item as HierarchyItem); }

        private static void HarlequinCallback(object item)
        { Colorize(HierarchyColorName.Harlequin, item as HierarchyItem); }

        private static void GreenCallback(object item)
        { Colorize(HierarchyColorName.Green, item as HierarchyItem); }

        private static void EmeraldCallback(object item)
        { Colorize(HierarchyColorName.Emerald, item as HierarchyItem); }

        private static void SpringGreenCallback(object item)
        { Colorize(HierarchyColorName.SpringGreen, item as HierarchyItem); }

        private static void AquamarineCallback(object item)
        { Colorize(HierarchyColorName.Aquamarine, item as HierarchyItem); }

        private static void CyanCallback(object item)
        { Colorize(HierarchyColorName.Cyan, item as HierarchyItem); }

        private static void SkyBlueCallback(object item)
        { Colorize(HierarchyColorName.SkyBlue, item as HierarchyItem); }

        private static void AzureCallback(object item)
        { Colorize(HierarchyColorName.Azure, item as HierarchyItem); }

        private static void CeruleanCallback(object item)
        { Colorize(HierarchyColorName.Cerulean, item as HierarchyItem); }

        private static void BlueCallback(object item)
        { Colorize(HierarchyColorName.Blue, item as HierarchyItem); }

        private static void IndigoCallback(object item)
        { Colorize(HierarchyColorName.Indigo, item as HierarchyItem); }

        private static void VioletCallback(object item)
        { Colorize(HierarchyColorName.Violet, item as HierarchyItem); }

        private static void PurpleCallback(object item)
        { Colorize(HierarchyColorName.Purple, item as HierarchyItem); }

        private static void MagentaCallback(object item)
        { Colorize(HierarchyColorName.Magenta, item as HierarchyItem); }

        private static void FuchsiaCallback(object item)
        { Colorize(HierarchyColorName.Fuchsia, item as HierarchyItem); }

        private static void RoseCallback(object item)
        { Colorize(HierarchyColorName.Rose, item as HierarchyItem); }

        private static void CrimsonCallback(object item)
        { Colorize(HierarchyColorName.Crimson, item as HierarchyItem); }
        
        // Custom
        private static void SelectCustomCallback(object item)
        { SelectCustom(item as HierarchyItem); }
        
        // None
        private static void SelectNoneCallback(object item) 
        { SelectNone(item as HierarchyItem); }
        
        //---------------------------------------------------------------------
        // Helpers
        //---------------------------------------------------------------------
        
        private static void Colorize(HierarchyColorName color, HierarchyItem hierarchyItem)
        {
            var colorIcon = HierarchyColorsStorage.Instance.GetBackgroundByColor(color);
            hierarchyItem.Background = colorIcon;
            hierarchyItem.IsBackgroundCustom = false;
        }
        
        private static void SelectNone(HierarchyItem hierarchyItem)
        {
            hierarchyItem.Background = null;
            hierarchyItem.IsBackgroundCustom = false;
            hierarchyItem.IsBackgroundRecursive = false;
        }
        
        private static void SelectCustom(HierarchyItem hierarchyItem)
        {
            hierarchyItem.Background = null;
            hierarchyItem.IsBackgroundCustom = true;
        }
    }
}