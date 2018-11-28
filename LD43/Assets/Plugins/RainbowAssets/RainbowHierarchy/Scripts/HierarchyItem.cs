using System;
using System.Security;
using UnityEngine;

namespace Borodar.RainbowHierarchy
{
    [Serializable]
    public class HierarchyItem
    {
        public KeyType Type;
        public string Name;
        public GameObject GameObject;
        
        public Texture2D Icon;
        public bool IsIconCustom;
        public bool IsIconRecursive;

        public Texture2D Background;
        public bool IsBackgroundCustom;
        public bool IsBackgroundRecursive;

        //---------------------------------------------------------------------
        // Ctors
        //---------------------------------------------------------------------

        public HierarchyItem(KeyType type, GameObject gameObject, string name)
        {
            Type = type;
            GameObject = gameObject;
            Name = name;
        }
        
        public HierarchyItem(HierarchyItem value)
        {
            Type = value.Type;
            Name = value.Name;
            
            GameObject = value.GameObject;
            
            Icon = value.Icon;
            IsIconCustom = value.IsIconCustom;
            IsIconRecursive = value.IsIconRecursive;
            
            Background = value.Background;
            IsBackgroundCustom =  value.IsBackgroundCustom;
            IsBackgroundRecursive = value.IsBackgroundRecursive;
        }

        //---------------------------------------------------------------------
        // Public
        //---------------------------------------------------------------------

        public void CopyFrom(HierarchyItem target)
        {
            Type = target.Type;
            Name = target.Name;
            
            GameObject = target.GameObject;
            
            Icon = target.Icon;
            IsIconCustom = target.IsIconCustom;
            IsIconRecursive = target.IsIconRecursive;
            
            Background = target.Background;
            IsBackgroundCustom =  target.IsBackgroundCustom;
            IsBackgroundRecursive = target.IsBackgroundRecursive;
        }
        
        public bool HasIcon()
        {
            return Icon != null;
        }

        public bool HasBackground()
        {
            return Background != null;
        }

        public bool HasAtLeastOneTexture()
        {
            return Icon != null || Background != null;
        }

        public bool HasRecursive()
        {
            return IsIconRecursive || IsBackgroundRecursive;
        }
        
        //---------------------------------------------------------------------
        // Nested
        //---------------------------------------------------------------------
        
        public enum KeyType
        {
            Object,
            Name
        }
    }
}