using Borodar.RainbowHierarchy.Components;
using UnityEditor;
using UnityEngine;

namespace Borodar.RainbowHierarchy
{
    public static class RainbowHierarchyIconsMenu
    {
        private const string MENU_COLORIZE = "Colors/";
        private const string MENU_COMPONENTS = "Components/";
        private const string MENU_CUSTOM = "Custom";
        private const string MENU_NONE = "None";
        
        private const string MENU_COMPONENTS_GENERAL = MENU_COMPONENTS + "General/";
        private const string MENU_COMPONENTS_MESHES = MENU_COMPONENTS + "Meshes/";
        private const string MENU_COMPONENTS_EFFECTS = MENU_COMPONENTS + "Effects/";
        private const string MENU_COMPONENTS_PHYSICS = MENU_COMPONENTS + "Physics/";
        private const string MENU_COMPONENTS_PHYSICS_2D = MENU_COMPONENTS + "Physics 2D/";
        private const string MENU_COMPONENTS_NAVIGATION = MENU_COMPONENTS + "Navigation/";
        private const string MENU_COMPONENTS_AUDIO = MENU_COMPONENTS + "Audio/";
        private const string MENU_COMPONENTS_VIDEO = MENU_COMPONENTS + "Video/";
        private const string MENU_COMPONENTS_RENDERING = MENU_COMPONENTS + "Rendering/";
        private const string MENU_COMPONENTS_TILEMAP = MENU_COMPONENTS + "Tilemap/";
        private const string MENU_COMPONENTS_LAYOUT = MENU_COMPONENTS + "Layout/";
        private const string MENU_COMPONENTS_PLAYABLES = MENU_COMPONENTS + "Playables/";
        private const string MENU_COMPONENTS_AR = MENU_COMPONENTS + "AR/";
        private const string MENU_COMPONENTS_MISCELLANEOUS = MENU_COMPONENTS + "Miscellaneous/";
        private const string MENU_COMPONENTS_EVENT = MENU_COMPONENTS + "Event/";
        private const string MENU_COMPONENTS_NETWORK = MENU_COMPONENTS + "Network/";
        private const string MENU_COMPONENTS_XR = MENU_COMPONENTS + "XR/";
        private const string MENU_COMPONENTS_UI = MENU_COMPONENTS + "UI/";

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
        
        // Components
        private static readonly GUIContent COMPONENT_GAME_OBJECT = new GUIContent(MENU_COMPONENTS_GENERAL + "Game Object");
        private static readonly GUIContent COMPONENT_TRANSFORM = new GUIContent(MENU_COMPONENTS_GENERAL + "Transform");
        private static readonly GUIContent COMPONENT_DEFAULT_ASSET = new GUIContent(MENU_COMPONENTS_GENERAL + "Default Asset");
        private static readonly GUIContent COMPONENT_TEXT_ASSET = new GUIContent(MENU_COMPONENTS_GENERAL + "Text Asset");
        private static readonly GUIContent COMPONENT_CS_SCRIPT = new GUIContent(MENU_COMPONENTS_GENERAL + "Cs Script");
        private static readonly GUIContent COMPONENT_JS_SCRIPT = new GUIContent(MENU_COMPONENTS_GENERAL + "Js Script");
        private static readonly GUIContent COMPONENT_SHADER = new GUIContent(MENU_COMPONENTS_GENERAL + "Shader");
        private static readonly GUIContent COMPONENT_PREFAB = new GUIContent(MENU_COMPONENTS_GENERAL + "Prefab");
        private static readonly GUIContent COMPONENT_SCRIPTABLE_OBJECT = new GUIContent(MENU_COMPONENTS_GENERAL + "Scriptable Object");
        private static readonly GUIContent COMPONENT_SCENE_ASSET = new GUIContent(MENU_COMPONENTS_GENERAL + "Scene");
        // Meshes
        private static readonly GUIContent COMPONENT_MESH_FILTER = new GUIContent(MENU_COMPONENTS_MESHES + "Mesh Filter");
        private static readonly GUIContent COMPONENT_TEXT_MESH = new GUIContent(MENU_COMPONENTS_MESHES + "Text Mesh");
        private static readonly GUIContent COMPONENT_MESH_RENDERER = new GUIContent(MENU_COMPONENTS_MESHES + "Mesh Renderer");
        private static readonly GUIContent COMPONENT_SKIN_MESH_RENDERER = new GUIContent(MENU_COMPONENTS_MESHES + "Skinned Mesh Renderer");
        // Effects
        private static readonly GUIContent COMPONENT_PARTICLE_SYSTEM = new GUIContent(MENU_COMPONENTS_EFFECTS + "Particle System");
        private static readonly GUIContent COMPONENT_TRAIL_RENDERER = new GUIContent(MENU_COMPONENTS_EFFECTS + "Trail Renderer");
        private static readonly GUIContent COMPONENT_LINE_RENDERER = new GUIContent(MENU_COMPONENTS_EFFECTS + "Line Renderer");
        private static readonly GUIContent COMPONENT_LENS_FLARE = new GUIContent(MENU_COMPONENTS_EFFECTS + "Lens Flare");
        private static readonly GUIContent COMPONENT_PROJECTOR = new GUIContent(MENU_COMPONENTS_EFFECTS + "Projector");
        // Physics
        private static readonly GUIContent COMPONENT_RIGIDBODY = new GUIContent(MENU_COMPONENTS_PHYSICS + "Rigidbody");
        private static readonly GUIContent COMPONENT_CHARACTER_CONTROLLER = new GUIContent(MENU_COMPONENTS_PHYSICS + "Character Controller");
        private static readonly GUIContent COMPONENT_BOX_COLLIDER = new GUIContent(MENU_COMPONENTS_PHYSICS + "Box Collider");
        private static readonly GUIContent COMPONENT_SPHERE_COLLIDER = new GUIContent(MENU_COMPONENTS_PHYSICS + "Sphere Collider");
        private static readonly GUIContent COMPONENT_CAPSULE_COLLIDER = new GUIContent(MENU_COMPONENTS_PHYSICS + "Capsule Collider");
        private static readonly GUIContent COMPONENT_MESH_COLLIDER = new GUIContent(MENU_COMPONENTS_PHYSICS + "Mesh Collider");
        private static readonly GUIContent COMPONENT_WHEEL_COLLIDER = new GUIContent(MENU_COMPONENTS_PHYSICS + "Wheel Collider");
        private static readonly GUIContent COMPONENT_TERRAIN_COLLIDER = new GUIContent(MENU_COMPONENTS_PHYSICS + "Terrain Collider");
        private static readonly GUIContent COMPONENT_CLOTH = new GUIContent(MENU_COMPONENTS_PHYSICS + "Cloth");
        private static readonly GUIContent COMPONENT_HINGE_JOINT = new GUIContent(MENU_COMPONENTS_PHYSICS + "Hingle Joint");
        private static readonly GUIContent COMPONENT_FIXED_JOINT = new GUIContent(MENU_COMPONENTS_PHYSICS + "Fixed Joint");
        private static readonly GUIContent COMPONENT_SPRING_JOINT = new GUIContent(MENU_COMPONENTS_PHYSICS + "Spring Joint");
        private static readonly GUIContent COMPONENT_CHARACTER_JOINT = new GUIContent(MENU_COMPONENTS_PHYSICS + "Character Joint");
        private static readonly GUIContent COMPONENT_CONFIGURABLE_JOINT = new GUIContent(MENU_COMPONENTS_PHYSICS + "Configurable Joint");
        private static readonly GUIContent COMPONENT_CONSTANT_FORCE = new GUIContent(MENU_COMPONENTS_PHYSICS + "Constant Force");
        // Physics 2D
        private static readonly GUIContent COMPONENT_RIGIDBODY_2D = new GUIContent(MENU_COMPONENTS_PHYSICS_2D + "Rigidbody 2D");
        private static readonly GUIContent COMPONENT_BOXCOLLIDER_2D = new GUIContent(MENU_COMPONENTS_PHYSICS_2D + "Box Collider 2D");
        private static readonly GUIContent COMPONENT_CIRCLE_COLLIDER_2D = new GUIContent(MENU_COMPONENTS_PHYSICS_2D + "Circle Collider 2D");
        private static readonly GUIContent COMPONENT_EDGE_COLLIDER_2D = new GUIContent(MENU_COMPONENTS_PHYSICS_2D + "Edge Collider 2D");
        private static readonly GUIContent COMPONENT_POLYGON_COLLIDER_2D = new GUIContent(MENU_COMPONENTS_PHYSICS_2D + "Polygon Collider 2D");
        private static readonly GUIContent COMPONENT_CAPSULE_COLLIDER_2D = new GUIContent(MENU_COMPONENTS_PHYSICS_2D + "Capsule Collider 2D");
        private static readonly GUIContent COMPONENT_COMPOSITE_COLLIDER_2D = new GUIContent(MENU_COMPONENTS_PHYSICS_2D + "Composite Collider 2D");
        private static readonly GUIContent COMPONENT_DISTANCE_JOINT_2D = new GUIContent(MENU_COMPONENTS_PHYSICS_2D + "Distance Joint 2D");
        private static readonly GUIContent COMPONENT_FIXED_JOINT_2D = new GUIContent(MENU_COMPONENTS_PHYSICS_2D + "Fixed Joint 2D");
        private static readonly GUIContent COMPONENT_FRICTION_JOINT_2D = new GUIContent(MENU_COMPONENTS_PHYSICS_2D + "Friction Joint 2D");
        private static readonly GUIContent COMPONENT_HINGE_JOINT_2D = new GUIContent(MENU_COMPONENTS_PHYSICS_2D + "Hinge Joint 2D");
        private static readonly GUIContent COMPONENT_RELATIVE_JOINT_2D = new GUIContent(MENU_COMPONENTS_PHYSICS_2D + "Relative Joint 2D");
        private static readonly GUIContent COMPONENT_SLIDER_JOINT_2D = new GUIContent(MENU_COMPONENTS_PHYSICS_2D + "Slider Joint 2D");
        private static readonly GUIContent COMPONENT_SPRING_JOINT_2D = new GUIContent(MENU_COMPONENTS_PHYSICS_2D + "Spring Joint 2D");
        private static readonly GUIContent COMPONENT_TARGET_JOINT_2D = new GUIContent(MENU_COMPONENTS_PHYSICS_2D + "Target Joint 2D");
        private static readonly GUIContent COMPONENT_WHEEL_JOINT_2D = new GUIContent(MENU_COMPONENTS_PHYSICS_2D + "Wheel Joint 2D");
        private static readonly GUIContent COMPONENT_AREA_EFFECTOR_2D = new GUIContent(MENU_COMPONENTS_PHYSICS_2D + "Area Effector 2D");
        private static readonly GUIContent COMPONENT_BUOYANCY_EFFECTOR_2D = new GUIContent(MENU_COMPONENTS_PHYSICS_2D + "Buoyancy Effector 2D");
        private static readonly GUIContent COMPONENT_POINT_EFFECTOR_2D = new GUIContent(MENU_COMPONENTS_PHYSICS_2D + "Point Effector 2D");
        private static readonly GUIContent COMPONENT_PLATFORM_EFFECTOR_2D = new GUIContent(MENU_COMPONENTS_PHYSICS_2D + "Platform Effector 2D");
        private static readonly GUIContent COMPONENT_SURFACE_EFFECTOR_2D = new GUIContent(MENU_COMPONENTS_PHYSICS_2D + "Surface Effector 2D");
        private static readonly GUIContent COMPONENT_CONSTANT_FORCE_2D = new GUIContent(MENU_COMPONENTS_PHYSICS_2D + "Constant Force 2D");
        // Navigation
        private static readonly GUIContent COMPONENT_NAV_MESH_AGENT = new GUIContent(MENU_COMPONENTS_NAVIGATION + "Nav Mesh Agent");
        private static readonly GUIContent COMPONENT_OFF_MESH_LINK = new GUIContent(MENU_COMPONENTS_NAVIGATION + "Off Mesh Link");
        private static readonly GUIContent COMPONENT_NAV_MESH_OBSTACLE = new GUIContent(MENU_COMPONENTS_NAVIGATION + "Nav Mesh Obstacle");
        // Audio
        private static readonly GUIContent COMPONENT_AUDIO_LISTENER = new GUIContent(MENU_COMPONENTS_AUDIO + "Audio Listener");
        private static readonly GUIContent COMPONENT_AUDIO_SOURCE = new GUIContent(MENU_COMPONENTS_AUDIO + "Audio Source");
        private static readonly GUIContent COMPONENT_AUDIO_REVERB_ZONE = new GUIContent(MENU_COMPONENTS_AUDIO + "Audio Reverb Zone");
        private static readonly GUIContent COMPONENT_AUDIO_LOW_PASS_FILTER = new GUIContent(MENU_COMPONENTS_AUDIO + "Audio Low Pass Filter");
        private static readonly GUIContent COMPONENT_AUDIO_HIGH_PASS_FILTER = new GUIContent(MENU_COMPONENTS_AUDIO + "Audio High Pass Filter");
        private static readonly GUIContent COMPONENT_AUDIO_ECHO_FILTER = new GUIContent(MENU_COMPONENTS_AUDIO + "Audio Echo Filter");
        private static readonly GUIContent COMPONENT_AUDIO_DISTORTION_FILTER = new GUIContent(MENU_COMPONENTS_AUDIO + "Audio Distortion Filter");
        private static readonly GUIContent COMPONENT_AUDIO_REVERB_FILTER = new GUIContent(MENU_COMPONENTS_AUDIO + "Audio Reverb Filter");
        private static readonly GUIContent COMPONENT_AUDIO_CHORUS_FILTER = new GUIContent(MENU_COMPONENTS_AUDIO + "Audio Chorus Filter");
        // Video
        private static readonly GUIContent COMPONENT_VIDEO_PLAYER = new GUIContent(MENU_COMPONENTS_VIDEO + "Video Player");
        // Rendering
        private static readonly GUIContent COMPONENT_CAMERA = new GUIContent(MENU_COMPONENTS_RENDERING + "Camera");
        private static readonly GUIContent COMPONENT_SKYBOX = new GUIContent(MENU_COMPONENTS_RENDERING + "Skybox");
        private static readonly GUIContent COMPONENT_FLARE_LAYER = new GUIContent(MENU_COMPONENTS_RENDERING + "Flare Layer");
        private static readonly GUIContent COMPONENT_LIGHT = new GUIContent(MENU_COMPONENTS_RENDERING + "Light");
        private static readonly GUIContent COMPONENT_LIGHT_PROBE_GROUP = new GUIContent(MENU_COMPONENTS_RENDERING + "Light Probe Group");
        private static readonly GUIContent COMPONENT_LIGHT_PROBE_PROXY_VOLUME = new GUIContent(MENU_COMPONENTS_RENDERING + "Light Probe Proxy Volume");
        private static readonly GUIContent COMPONENT_REFLECTION_PROBE = new GUIContent(MENU_COMPONENTS_RENDERING + "Reflection Probe");
        private static readonly GUIContent COMPONENT_OCCLUSION_AREA = new GUIContent(MENU_COMPONENTS_RENDERING + "Occlusion Area");
        private static readonly GUIContent COMPONENT_OCCLUSION_PORTAL = new GUIContent(MENU_COMPONENTS_RENDERING + "Occlusion Portal");
        private static readonly GUIContent COMPONENT_LOD_GROUP = new GUIContent(MENU_COMPONENTS_RENDERING + "LOD Group");
        private static readonly GUIContent COMPONENT_SPRITE_RENDERER = new GUIContent(MENU_COMPONENTS_RENDERING + "Sprite Renderer");
        private static readonly GUIContent COMPONENT_SORTING_GROUP = new GUIContent(MENU_COMPONENTS_RENDERING + "Sorting Group");
        private static readonly GUIContent COMPONENT_CANVAS_RENDERER = new GUIContent(MENU_COMPONENTS_RENDERING + "Canvas Renderer");
        // Tilemap
        #if UNITY_2017_2_OR_NEWER
        private static readonly GUIContent COMPONENT_TILEMAP = new GUIContent(MENU_COMPONENTS_TILEMAP + "Tilemap");
        private static readonly GUIContent COMPONENT_TILEMAP_RENDERER = new GUIContent(MENU_COMPONENTS_TILEMAP + "Tilemap Renderer");
        private static readonly GUIContent COMPONENT_TILEMAP_COLLIDER_2D = new GUIContent(MENU_COMPONENTS_TILEMAP + "Tilemap Collider 2D");
        #endif
        // Layout
        private static readonly GUIContent COMPONENT_RECT_TRANSFORM = new GUIContent(MENU_COMPONENTS_LAYOUT + "Rect Transform");
        private static readonly GUIContent COMPONENT_CANVAS = new GUIContent(MENU_COMPONENTS_LAYOUT + "Canvas");
        private static readonly GUIContent COMPONENT_CANVAS_GROUP = new GUIContent(MENU_COMPONENTS_LAYOUT + "Canvas Group");
        private static readonly GUIContent COMPONENT_CANVAS_SCALER = new GUIContent(MENU_COMPONENTS_LAYOUT + "Canvas Scaler");
        private static readonly GUIContent COMPONENT_LAYOUT_ELEMENT = new GUIContent(MENU_COMPONENTS_LAYOUT + "Layout Element");
        private static readonly GUIContent COMPONENT_CONTENT_SIZE_FITTER = new GUIContent(MENU_COMPONENTS_LAYOUT + "Content Size Fitter");
        private static readonly GUIContent COMPONENT_ASPECT_RATIO_FITTER = new GUIContent(MENU_COMPONENTS_LAYOUT + "Aspect Ratio Fitter");
        private static readonly GUIContent COMPONENT_HORIZONTAL_LAYOUT_GROUP = new GUIContent(MENU_COMPONENTS_LAYOUT + "Horizontal Layout Group");
        private static readonly GUIContent COMPONENT_VERTICAL_LAYOUT_GROUP = new GUIContent(MENU_COMPONENTS_LAYOUT + "Vertical Layout Group");
        private static readonly GUIContent COMPONENT_GRID_LAYOUT_GROUP = new GUIContent(MENU_COMPONENTS_LAYOUT + "Grid Layout Group");
        // Playables
        private static readonly GUIContent COMPONENT_PLAYABLE_DIRECTOR = new GUIContent(MENU_COMPONENTS_PLAYABLES + "Playable Director");
        // AR
        #if UNITY_2017_2_OR_NEWER
        private static readonly GUIContent COMPONENT_WORLD_ANCHOR = new GUIContent(MENU_COMPONENTS_AR + "World Anchor");
        #endif
        // Miscellaneous
        private static readonly GUIContent COMPONENT_BILLBOARD_RENDERER = new GUIContent(MENU_COMPONENTS_MISCELLANEOUS + "Billboard Renderer");
        private static readonly GUIContent COMPONENT_TERRAIN = new GUIContent(MENU_COMPONENTS_MISCELLANEOUS + "Terrain");
        private static readonly GUIContent COMPONENT_ANIMATOR = new GUIContent(MENU_COMPONENTS_MISCELLANEOUS + "Animator");
        private static readonly GUIContent COMPONENT_ANIMATION = new GUIContent(MENU_COMPONENTS_MISCELLANEOUS + "Animation");
        #if UNITY_2017_2_OR_NEWER
        private static readonly GUIContent COMPONENT_GRID = new GUIContent(MENU_COMPONENTS_MISCELLANEOUS + "Grid");
        #endif
        private static readonly GUIContent COMPONENT_WINDZONE = new GUIContent(MENU_COMPONENTS_MISCELLANEOUS + "Wind Zone");
        private static readonly GUIContent COMPONENT_SPRITE_MASK = new GUIContent(MENU_COMPONENTS_MISCELLANEOUS + "Sprite Mask");
        // Event
        private static readonly GUIContent COMPONENT_EVENT_SYSTEM = new GUIContent(MENU_COMPONENTS_EVENT + "Event System");
        private static readonly GUIContent COMPONENT_HOLOLENS_INPUT_MODULE = new GUIContent(MENU_COMPONENTS_EVENT + "HoloLens Input Module");
        private static readonly GUIContent COMPONENT_EVENT_TRIGGER = new GUIContent(MENU_COMPONENTS_EVENT + "Event Trigger");
        private static readonly GUIContent COMPONENT_PHYSICS_2D_RAYCASTER = new GUIContent(MENU_COMPONENTS_EVENT + "Physics 2D Raycaster");
        private static readonly GUIContent COMPONENT_PHYSICS_RAYCASTER = new GUIContent(MENU_COMPONENTS_EVENT + "Physics Raycaster");
        private static readonly GUIContent COMPONENT_STANDALONE_INPUT_MODULE = new GUIContent(MENU_COMPONENTS_EVENT + "Standalone Input Module");
        private static readonly GUIContent COMPONENT_GRAPHIC_RAYCASTER = new GUIContent(MENU_COMPONENTS_EVENT + "Graphic Raycaster");
        // Network
        private static readonly GUIContent COMPONENT_NETWORK_ANIMATOR = new GUIContent(MENU_COMPONENTS_NETWORK + "Network Animator");
        private static readonly GUIContent COMPONENT_NETWORK_DISCOVERY = new GUIContent(MENU_COMPONENTS_NETWORK + "Network Discovery");
        private static readonly GUIContent COMPONENT_NETWORK_IDENTITY = new GUIContent(MENU_COMPONENTS_NETWORK + "Network Identity");
        private static readonly GUIContent COMPONENT_NETWORK_LOBBY_MANAGER = new GUIContent(MENU_COMPONENTS_NETWORK + "Network Lobby Manager");
        private static readonly GUIContent COMPONENT_NETWORK_MANAGER = new GUIContent(MENU_COMPONENTS_NETWORK + "Network Manager");
        private static readonly GUIContent COMPONENT_NETWORK_MANAGER_HUD = new GUIContent(MENU_COMPONENTS_NETWORK + "Network Manager HUD");
        private static readonly GUIContent COMPONENT_NETWORK_MIGRATION_MANAGER = new GUIContent(MENU_COMPONENTS_NETWORK + "Network Migration Manager");
        private static readonly GUIContent COMPONENT_NETWORK_PROXIMITY_CHECKER = new GUIContent(MENU_COMPONENTS_NETWORK + "Network Proximity Checker");
        private static readonly GUIContent COMPONENT_NETWORK_START_POSITION = new GUIContent(MENU_COMPONENTS_NETWORK + "Network Start Position");
        private static readonly GUIContent COMPONENT_NETWORK_TRANSFORM = new GUIContent(MENU_COMPONENTS_NETWORK + "Network Transform");
        private static readonly GUIContent COMPONENT_NETWORK_TRANSFORM_CHILD = new GUIContent(MENU_COMPONENTS_NETWORK + "Network Transform Child");
        private static readonly GUIContent COMPONENT_NETWORK_TRANSFORM_VISUALIZER = new GUIContent(MENU_COMPONENTS_NETWORK + "NetworkTransformVisualizer");
        // XR
        #if UNITY_2017_2_OR_NEWER
        private static readonly GUIContent COMPONENT_SPATIAL_MAPPING_COLLIDER = new GUIContent(MENU_COMPONENTS_XR + "Spatial Mapping Collider");
        private static readonly GUIContent COMPONENT_SPATIAL_MAPPING_RENDERER = new GUIContent(MENU_COMPONENTS_XR + "Spatial Mapping Renderer");
        #endif
        // UI
        private static readonly GUIContent COMPONENT_TEXT = new GUIContent(MENU_COMPONENTS_UI + "Text");
        private static readonly GUIContent COMPONENT_IMAGE = new GUIContent(MENU_COMPONENTS_UI + "Image");
        private static readonly GUIContent COMPONENT_RAW_IMAGE = new GUIContent(MENU_COMPONENTS_UI + "Raw Image");
        private static readonly GUIContent COMPONENT_MASK = new GUIContent(MENU_COMPONENTS_UI + "Mask");
        private static readonly GUIContent COMPONENT_BUTTON = new GUIContent(MENU_COMPONENTS_UI + "Button");
        private static readonly GUIContent COMPONENT_INPUT_FIELD = new GUIContent(MENU_COMPONENTS_UI + "Input Field");
        private static readonly GUIContent COMPONENT_TOGGLE = new GUIContent(MENU_COMPONENTS_UI + "Toggle");
        private static readonly GUIContent COMPONENT_TOGGLE_GROUP = new GUIContent(MENU_COMPONENTS_UI + "Toggle Group");
        private static readonly GUIContent COMPONENT_SLIDER = new GUIContent(MENU_COMPONENTS_UI + "Slider");
        private static readonly GUIContent COMPONENT_SCROLLBAR = new GUIContent(MENU_COMPONENTS_UI + "Scrollbar");
        private static readonly GUIContent COMPONENT_DROPDOWN = new GUIContent(MENU_COMPONENTS_UI + "Dropdown");
        private static readonly GUIContent COMPONENT_SCROLL_RECT = new GUIContent(MENU_COMPONENTS_UI + "ScrollRect");
        private static readonly GUIContent COMPONENT_SELECTABLE = new GUIContent(MENU_COMPONENTS_UI + "Selectable");
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
            
            // Components
            
            // General
            menu.AddItem(COMPONENT_GAME_OBJECT,       false, ComponentGameObjectCallback,       hierarchyItem);
            menu.AddItem(COMPONENT_TRANSFORM,         false, ComponentTransformCallback,        hierarchyItem);
            menu.AddItem(COMPONENT_PREFAB,            false, ComponentPrefabCallback,           hierarchyItem);
            menu.AddItem(COMPONENT_SCENE_ASSET,       false, ComponentUnityLogoCallback,        hierarchyItem);
            menu.AddItem(COMPONENT_CS_SCRIPT,         false, ComponentCsScriptCallback,         hierarchyItem);
            menu.AddItem(COMPONENT_JS_SCRIPT,         false, ComponentJsScriptCallback,         hierarchyItem);
            menu.AddItem(COMPONENT_SHADER,            false, ComponentShaderCallback,           hierarchyItem);
            menu.AddItem(COMPONENT_SCRIPTABLE_OBJECT, false, ComponentScriptableObjectCallback, hierarchyItem);
            menu.AddItem(COMPONENT_TEXT_ASSET,        false, ComponentTextAssetCallback,        hierarchyItem);
            menu.AddItem(COMPONENT_DEFAULT_ASSET,     false, ComponentDefaultAssetCallback,     hierarchyItem);            
            // Meshes
            menu.AddItem(COMPONENT_MESH_FILTER,         false, ComponentMeshFilterCallback,       hierarchyItem);
            menu.AddItem(COMPONENT_TEXT_MESH,           false, ComponentTextMeshCallback,         hierarchyItem);
            menu.AddItem(COMPONENT_MESH_RENDERER,       false, ComponentMeshRendererCallback,     hierarchyItem);
            menu.AddItem(COMPONENT_SKIN_MESH_RENDERER,  false, ComponentSkinMeshRendererCallback, hierarchyItem);
            // Effects
            menu.AddItem(COMPONENT_PARTICLE_SYSTEM,   false, ComponentParticleSystemCallback,     hierarchyItem);
            menu.AddItem(COMPONENT_TRAIL_RENDERER,    false, ComponentTrailRendererCallback,      hierarchyItem);
            menu.AddItem(COMPONENT_LINE_RENDERER,     false, ComponentLineRendererCallback,       hierarchyItem);
            menu.AddItem(COMPONENT_LENS_FLARE,        false, ComponentLensFlareCallback,          hierarchyItem);
            menu.AddItem(COMPONENT_PROJECTOR,         false, ComponentProjectorCallback,          hierarchyItem);
            // Physics
            menu.AddItem(COMPONENT_RIGIDBODY,             false, ComponentRigidbodyCallback,           hierarchyItem);
            menu.AddItem(COMPONENT_CHARACTER_CONTROLLER,  false, ComponentCharacterControllerCallback, hierarchyItem);
            menu.AddItem(COMPONENT_BOX_COLLIDER,          false, ComponentBoxColliderCallback,         hierarchyItem);
            menu.AddItem(COMPONENT_SPHERE_COLLIDER,       false, ComponentSphereColliderCallback,      hierarchyItem);
            menu.AddItem(COMPONENT_CAPSULE_COLLIDER,      false, ComponentCapsuleColliderCallback,     hierarchyItem);
            menu.AddItem(COMPONENT_MESH_COLLIDER,         false, ComponentMeshColliderCallback,        hierarchyItem);
            menu.AddItem(COMPONENT_WHEEL_COLLIDER,        false, ComponentWheelColliderCallback,       hierarchyItem);
            menu.AddItem(COMPONENT_TERRAIN_COLLIDER,      false, ComponentTerrainColliderCallback,     hierarchyItem);
            menu.AddItem(COMPONENT_CLOTH,                 false, ComponentClothCallback,               hierarchyItem);
            menu.AddItem(COMPONENT_HINGE_JOINT,           false, ComponentHingeJointCallback,          hierarchyItem);
            menu.AddItem(COMPONENT_FIXED_JOINT,           false, ComponentFixedJointCallback,          hierarchyItem);
            menu.AddItem(COMPONENT_SPRING_JOINT,          false, ComponentSpringJointCallback,         hierarchyItem);
            menu.AddItem(COMPONENT_CHARACTER_JOINT,       false, ComponentCharacterJointCallback,      hierarchyItem);
            menu.AddItem(COMPONENT_CONFIGURABLE_JOINT,    false, ComponentConfigurableJointCallback,   hierarchyItem);
            menu.AddItem(COMPONENT_CONSTANT_FORCE,        false, ComponentConstantForceCallback,       hierarchyItem);
            // Physics 2D
            menu.AddItem(COMPONENT_RIGIDBODY_2D,          false, ComponentRigidbody2DCallback,         hierarchyItem);
            menu.AddItem(COMPONENT_BOXCOLLIDER_2D,        false, ComponentBoxCollider2DCallback,       hierarchyItem);
            menu.AddItem(COMPONENT_CIRCLE_COLLIDER_2D,    false, ComponentCircleCollider2DCallback,    hierarchyItem);
            menu.AddItem(COMPONENT_EDGE_COLLIDER_2D,      false, ComponentEdgeCollider2DCallback,      hierarchyItem);
            menu.AddItem(COMPONENT_POLYGON_COLLIDER_2D,   false, ComponentPolygonCollider2DCallback,   hierarchyItem);
            menu.AddItem(COMPONENT_CAPSULE_COLLIDER_2D,   false, ComponentCapsuleCollider2DCallback,   hierarchyItem);
            menu.AddItem(COMPONENT_COMPOSITE_COLLIDER_2D, false, ComponentCompositeCollider2DCallback, hierarchyItem);
            menu.AddItem(COMPONENT_DISTANCE_JOINT_2D,     false, ComponentDistanceJoint2DCallback,     hierarchyItem);
            menu.AddItem(COMPONENT_FIXED_JOINT_2D,        false, ComponentFixedJoint2DCallback,        hierarchyItem);
            menu.AddItem(COMPONENT_FRICTION_JOINT_2D,     false, ComponentFrictionJoint2DCallback,     hierarchyItem);
            menu.AddItem(COMPONENT_HINGE_JOINT_2D,        false, ComponentHingeJoint2DCallback,        hierarchyItem);
            menu.AddItem(COMPONENT_RELATIVE_JOINT_2D,     false, ComponentRelativeJoint2DCallback,     hierarchyItem);
            menu.AddItem(COMPONENT_SLIDER_JOINT_2D,       false, ComponentSliderJoint2DCallback,       hierarchyItem);
            menu.AddItem(COMPONENT_SPRING_JOINT_2D,       false, ComponentSpringJoint2DCallback,       hierarchyItem);
            menu.AddItem(COMPONENT_TARGET_JOINT_2D,       false, ComponentTargetJoint2DCallback,       hierarchyItem);
            menu.AddItem(COMPONENT_WHEEL_JOINT_2D,        false, ComponentWheelJoint2DCallback,        hierarchyItem);
            menu.AddItem(COMPONENT_AREA_EFFECTOR_2D,      false, ComponentAreaEffector2DCallback,      hierarchyItem);
            menu.AddItem(COMPONENT_BUOYANCY_EFFECTOR_2D,  false, ComponentBuoyancyEffector2DCallback,  hierarchyItem);
            menu.AddItem(COMPONENT_POINT_EFFECTOR_2D,     false, ComponentPointEffector2DCallback,     hierarchyItem);
            menu.AddItem(COMPONENT_PLATFORM_EFFECTOR_2D,  false, ComponentPlatformEffector2DCallback,  hierarchyItem);
            menu.AddItem(COMPONENT_SURFACE_EFFECTOR_2D,   false, ComponentSurfaceEffector2DCallback,   hierarchyItem);
            menu.AddItem(COMPONENT_CONSTANT_FORCE_2D,     false, ComponentConstantForce2DCallback,     hierarchyItem);            
            // Navigation
            menu.AddItem(COMPONENT_NAV_MESH_AGENT,        false, ComponentNavMeshAgentCallback,        hierarchyItem);
            menu.AddItem(COMPONENT_OFF_MESH_LINK,         false, ComponentOffMeshLinkCallback,         hierarchyItem);
            menu.AddItem(COMPONENT_NAV_MESH_OBSTACLE,     false, ComponentNavMeshObstacleCallback,     hierarchyItem);
            // Audio
            menu.AddItem(COMPONENT_AUDIO_LISTENER,          false, ComponentAudioListenerCallback,         hierarchyItem);
            menu.AddItem(COMPONENT_AUDIO_SOURCE,            false, ComponentAudioSourceCallback,           hierarchyItem);
            menu.AddItem(COMPONENT_AUDIO_REVERB_ZONE,       false, ComponentAudioReverbZoneCallback,       hierarchyItem);
            menu.AddItem(COMPONENT_AUDIO_LOW_PASS_FILTER,   false, ComponentAudioLowPassFilterCallback,    hierarchyItem);
            menu.AddItem(COMPONENT_AUDIO_HIGH_PASS_FILTER,  false, ComponentAudioHighPassFilterCallback,   hierarchyItem);
            menu.AddItem(COMPONENT_AUDIO_ECHO_FILTER,       false, ComponentAudioEchoFilterCallback,       hierarchyItem);
            menu.AddItem(COMPONENT_AUDIO_DISTORTION_FILTER, false, ComponentAudioDistortionFilterCallback, hierarchyItem);
            menu.AddItem(COMPONENT_AUDIO_REVERB_FILTER,     false, ComponentAudioReverbFilterCallback,     hierarchyItem);
            menu.AddItem(COMPONENT_AUDIO_CHORUS_FILTER,     false, ComponentAudioChorusFilterCallback,     hierarchyItem);
            // Video
            menu.AddItem(COMPONENT_VIDEO_PLAYER,          false, ComponentVideoPlayerCallback,         hierarchyItem);
            // Rendering
            menu.AddItem(COMPONENT_CAMERA,                   false, ComponentCameraCallback,                hierarchyItem);
            menu.AddItem(COMPONENT_SKYBOX,                   false, ComponentSkyboxCallback,                hierarchyItem);
            menu.AddItem(COMPONENT_FLARE_LAYER,              false, ComponentFlareLayerCallback,            hierarchyItem);
            menu.AddItem(COMPONENT_LIGHT,                    false, ComponentLightCallback,                 hierarchyItem);
            menu.AddItem(COMPONENT_LIGHT_PROBE_GROUP,        false, ComponentLightProbeGroupCallback,       hierarchyItem);
            menu.AddItem(COMPONENT_LIGHT_PROBE_PROXY_VOLUME, false, ComponentLightProbeProxyVolumeCallback, hierarchyItem);
            menu.AddItem(COMPONENT_REFLECTION_PROBE,         false, ComponentReflectionProbeCallback,       hierarchyItem);
            menu.AddItem(COMPONENT_OCCLUSION_AREA,           false, ComponentOcclusionAreaCallback,         hierarchyItem);
            menu.AddItem(COMPONENT_OCCLUSION_PORTAL,         false, ComponentOcclusionPortalCallback,       hierarchyItem);
            menu.AddItem(COMPONENT_LOD_GROUP,                false, ComponentLodGroupCallback,              hierarchyItem);
            menu.AddItem(COMPONENT_SPRITE_RENDERER,          false, ComponentSpriteRendererCallback,        hierarchyItem);
            menu.AddItem(COMPONENT_SORTING_GROUP,            false, ComponentSortingGroupCallback,          hierarchyItem);
            menu.AddItem(COMPONENT_CANVAS_RENDERER,          false, ComponentCanvasRendererxCallback,       hierarchyItem);
            // Tilemap
            #if UNITY_2017_2_OR_NEWER
            menu.AddItem(COMPONENT_TILEMAP,              false, ComponentTilemapCallback,            hierarchyItem);
            menu.AddItem(COMPONENT_TILEMAP_RENDERER,     false, ComponentTilemapRendererCallback,    hierarchyItem);
            menu.AddItem(COMPONENT_TILEMAP_COLLIDER_2D,  false, ComponentTilemapCollider2DCallback,  hierarchyItem);
            #endif
            // Layout
            menu.AddItem(COMPONENT_RECT_TRANSFORM,          false, ComponentRectTransformCallback,         hierarchyItem);
            menu.AddItem(COMPONENT_CANVAS,                  false, ComponentCanvasCallback,                hierarchyItem);
            menu.AddItem(COMPONENT_CANVAS_GROUP,            false, ComponentCanvasGroupCallback,           hierarchyItem);
            menu.AddItem(COMPONENT_CANVAS_SCALER,           false, ComponentCanvasScalerCallback,          hierarchyItem);
            menu.AddItem(COMPONENT_LAYOUT_ELEMENT,          false, ComponentLayoutElementCallback,         hierarchyItem);
            menu.AddItem(COMPONENT_CONTENT_SIZE_FITTER,     false, ComponentContentSizeFitterCallback,     hierarchyItem);
            menu.AddItem(COMPONENT_ASPECT_RATIO_FITTER,     false, ComponentAspectRatioFitterCallback,     hierarchyItem);
            menu.AddItem(COMPONENT_HORIZONTAL_LAYOUT_GROUP, false, ComponentHorizontalLayoutGroupCallback, hierarchyItem);
            menu.AddItem(COMPONENT_VERTICAL_LAYOUT_GROUP,   false, ComponentVerticalLayoutGroupCallback,   hierarchyItem);
            menu.AddItem(COMPONENT_GRID_LAYOUT_GROUP,       false, ComponentGridLayoutGroupCallback,       hierarchyItem);
            // Playable
            menu.AddItem(COMPONENT_PLAYABLE_DIRECTOR,       false, ComponentPlayableDirectorCallback,  hierarchyItem);
            // AR
            #if UNITY_2017_2_OR_NEWER
            menu.AddItem(COMPONENT_WORLD_ANCHOR,       false, ComponentWorldAnchorCallback,  hierarchyItem);
            #endif
            // Miscellaneous
            menu.AddItem(COMPONENT_BILLBOARD_RENDERER, false, ComponentBillboardRendererCallback,  hierarchyItem);
            menu.AddItem(COMPONENT_TERRAIN,            false, ComponentTerrainCallback,            hierarchyItem);
            menu.AddItem(COMPONENT_ANIMATOR,           false, ComponentAnimatorCallback,           hierarchyItem);
            menu.AddItem(COMPONENT_ANIMATION,          false, ComponentAnimationCallback,          hierarchyItem);
            #if UNITY_2017_2_OR_NEWER
            menu.AddItem(COMPONENT_GRID,               false, ComponentGridCallback,               hierarchyItem);
            #endif
            menu.AddItem(COMPONENT_WINDZONE,           false, ComponentWindZoneCallback,           hierarchyItem);
            menu.AddItem(COMPONENT_SPRITE_MASK,        false, ComponentSpriteMaskCallback,         hierarchyItem);
            // Event
            menu.AddItem(COMPONENT_EVENT_SYSTEM,            false, ComponentEventSystemCallback,           hierarchyItem);
            menu.AddItem(COMPONENT_HOLOLENS_INPUT_MODULE,   false, ComponentHoloLensInputModuleCallback,   hierarchyItem);
            menu.AddItem(COMPONENT_EVENT_TRIGGER,           false, ComponentEventTriggerCallback,          hierarchyItem);
            menu.AddItem(COMPONENT_PHYSICS_2D_RAYCASTER,    false, ComponentPhysics2DRaycasterCallback,    hierarchyItem);
            menu.AddItem(COMPONENT_PHYSICS_RAYCASTER,       false, ComponentPhysicsRaycasterCallback,      hierarchyItem);
            menu.AddItem(COMPONENT_STANDALONE_INPUT_MODULE, false, ComponentStandaloneInputModuleCallback, hierarchyItem);
            menu.AddItem(COMPONENT_GRAPHIC_RAYCASTER,       false, ComponentGraphicRaycasterCallback,      hierarchyItem);            
            // Network
            menu.AddItem(COMPONENT_NETWORK_ANIMATOR,              false, ComponentNetworkAnimatorCallback,            hierarchyItem);
            menu.AddItem(COMPONENT_NETWORK_DISCOVERY,             false, ComponenNetworkDiscoveryCallback,            hierarchyItem);
            menu.AddItem(COMPONENT_NETWORK_IDENTITY,              false, ComponentNetworkIdentityCallback,            hierarchyItem);
            menu.AddItem(COMPONENT_NETWORK_LOBBY_MANAGER,         false, ComponentNetworkLobbyManagerCallback,        hierarchyItem);
            menu.AddItem(COMPONENT_NETWORK_MANAGER,               false, ComponentNetworkManagerCallback,             hierarchyItem);
            menu.AddItem(COMPONENT_NETWORK_MANAGER_HUD,           false, ComponentNetworkManagerHudCallback,          hierarchyItem);
            menu.AddItem(COMPONENT_NETWORK_MIGRATION_MANAGER,     false, ComponentNetworkMigrationManagerCallback,    hierarchyItem);
            menu.AddItem(COMPONENT_NETWORK_PROXIMITY_CHECKER,     false, ComponentNetworkProximityCheckerCallback,    hierarchyItem);
            menu.AddItem(COMPONENT_NETWORK_START_POSITION,        false, ComponentNetworkStartPositionCallback,       hierarchyItem);
            menu.AddItem(COMPONENT_NETWORK_TRANSFORM,             false, ComponentNetworkTransformCallback,           hierarchyItem);
            menu.AddItem(COMPONENT_NETWORK_TRANSFORM_CHILD,       false, ComponentNetworkTransformChildCallback,      hierarchyItem);
            menu.AddItem(COMPONENT_NETWORK_TRANSFORM_VISUALIZER,  false, ComponentNetworkTransformVisualizerCallback, hierarchyItem);
            // XR
            #if UNITY_2017_2_OR_NEWER
            menu.AddItem(COMPONENT_SPATIAL_MAPPING_COLLIDER, false, ComponentSpatialMappingColliderCallback, hierarchyItem);
            menu.AddItem(COMPONENT_SPATIAL_MAPPING_RENDERER, false, ComponenSpatialMappingRendererCallback,  hierarchyItem);
            #endif
            // UI
            menu.AddItem(COMPONENT_TEXT,         false, ComponentTextCallback,        hierarchyItem);
            menu.AddItem(COMPONENT_IMAGE,        false, ComponenImageCallback,        hierarchyItem);
            menu.AddItem(COMPONENT_RAW_IMAGE,    false, ComponenRawImageCallback,     hierarchyItem);
            menu.AddItem(COMPONENT_MASK,         false, ComponenMaskCallback,         hierarchyItem);
            menu.AddItem(COMPONENT_BUTTON,       false, ComponenButtonCallback,       hierarchyItem);
            menu.AddItem(COMPONENT_INPUT_FIELD,  false, ComponenInputFieldCallback,   hierarchyItem);
            menu.AddItem(COMPONENT_TOGGLE,       false, ComponenToggleCallback,       hierarchyItem);
            menu.AddItem(COMPONENT_TOGGLE_GROUP, false, ComponenToggleGroupCallback,  hierarchyItem);
            menu.AddItem(COMPONENT_SLIDER,       false, ComponenSliderCallback,       hierarchyItem);
            menu.AddItem(COMPONENT_SCROLLBAR,    false, ComponenScrollbarCallback,    hierarchyItem);
            menu.AddItem(COMPONENT_DROPDOWN,     false, ComponenDropdownCallback,     hierarchyItem);
            menu.AddItem(COMPONENT_SCROLL_RECT,  false, ComponenScrollRectCallback,   hierarchyItem);
            menu.AddItem(COMPONENT_SELECTABLE,   false, ComponenSelectableCallback,   hierarchyItem);

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

        // Components
        
        // General
                
        private static void ComponentGameObjectCallback(object item)
        { AssignComponent(ComponentType.GameObject, item as HierarchyItem); }
        
        private static void ComponentTransformCallback(object item)
        { AssignComponent(ComponentType.Transform, item as HierarchyItem); }
        
        private static void ComponentDefaultAssetCallback(object item)
        { AssignComponent(ComponentType.DefaultAsset, item as HierarchyItem); }
        
        private static void ComponentTextAssetCallback(object item)
        { AssignComponent(ComponentType.TextAsset, item as HierarchyItem); }
        
        private static void ComponentCsScriptCallback(object item)
        { AssignComponent(ComponentType.CsScript, item as HierarchyItem); }
        
        private static void ComponentJsScriptCallback(object item)
        { AssignComponent(ComponentType.JsScript, item as HierarchyItem); }
        
        private static void ComponentShaderCallback(object item)
        { AssignComponent(ComponentType.Shader, item as HierarchyItem); }
        
        private static void ComponentPrefabCallback(object item)
        { AssignComponent(ComponentType.Prefab, item as HierarchyItem); }
        
        private static void ComponentScriptableObjectCallback(object item)
        { AssignComponent(ComponentType.ScriptableObject, item as HierarchyItem); }
        
        private static void ComponentUnityLogoCallback(object item)
        { AssignComponent(ComponentType.SceneAsset, item as HierarchyItem); }
        
        // Meshes
        
        private static void ComponentMeshFilterCallback(object item)
        { AssignComponent(ComponentType.MeshFilter, item as HierarchyItem); }
        
        private static void ComponentTextMeshCallback(object item)
        { AssignComponent(ComponentType.TextMesh, item as HierarchyItem); }
        
        private static void ComponentMeshRendererCallback(object item)
        { AssignComponent(ComponentType.MeshRenderer, item as HierarchyItem); }
        
        private static void ComponentSkinMeshRendererCallback(object item)
        { AssignComponent(ComponentType.SkinnedMeshRenderer, item as HierarchyItem); }
        
        
        // Effects
        
        private static void ComponentParticleSystemCallback(object item)
        { AssignComponent(ComponentType.ParticleSystem, item as HierarchyItem); }
        
        private static void ComponentTrailRendererCallback(object item)
        { AssignComponent(ComponentType.TrailRenderer, item as HierarchyItem); }
        
        private static void ComponentLineRendererCallback(object item)
        { AssignComponent(ComponentType.LineRenderer, item as HierarchyItem); }
        
        private static void ComponentLensFlareCallback(object item)
        { AssignComponent(ComponentType.LensFlare, item as HierarchyItem); }
        
        private static void ComponentProjectorCallback(object item)
        { AssignComponent(ComponentType.Projector, item as HierarchyItem); }
        
        // Physics
        
        private static void ComponentRigidbodyCallback(object item)
        { AssignComponent(ComponentType.Rigidbody, item as HierarchyItem); }
        
        private static void ComponentCharacterControllerCallback(object item)
        { AssignComponent(ComponentType.CharacterController, item as HierarchyItem); }
        
        private static void ComponentBoxColliderCallback(object item)
        { AssignComponent(ComponentType.BoxCollider, item as HierarchyItem); }
        
        private static void ComponentSphereColliderCallback(object item)
        { AssignComponent(ComponentType.SphereCollider, item as HierarchyItem); }
        
        private static void ComponentCapsuleColliderCallback(object item)
        { AssignComponent(ComponentType.CapsuleCollider, item as HierarchyItem); }
        
        private static void ComponentMeshColliderCallback(object item)
        { AssignComponent(ComponentType.MeshCollider, item as HierarchyItem); }
        
        private static void ComponentWheelColliderCallback(object item)
        { AssignComponent(ComponentType.WheelCollider, item as HierarchyItem); }
        
        private static void ComponentTerrainColliderCallback(object item)
        { AssignComponent(ComponentType.TerrainCollider, item as HierarchyItem); }
        
        private static void ComponentClothCallback(object item)
        { AssignComponent(ComponentType.Cloth, item as HierarchyItem); }
        
        private static void ComponentHingeJointCallback(object item)
        { AssignComponent(ComponentType.HingeJoint, item as HierarchyItem); }
        
        private static void ComponentFixedJointCallback(object item)
        { AssignComponent(ComponentType.FixedJoint, item as HierarchyItem); }
        
        private static void ComponentSpringJointCallback(object item)
        { AssignComponent(ComponentType.SpringJoint, item as HierarchyItem); }
        
        private static void ComponentCharacterJointCallback(object item)
        { AssignComponent(ComponentType.CharacterJoint, item as HierarchyItem); }
        
        private static void ComponentConfigurableJointCallback(object item)
        { AssignComponent(ComponentType.ConfigurableJoint, item as HierarchyItem); }
        
        private static void ComponentConstantForceCallback(object item)
        { AssignComponent(ComponentType.ConstantForce, item as HierarchyItem); }
        
        // Physics 2D
        
        private static void ComponentRigidbody2DCallback(object item)
        { AssignComponent(ComponentType.Rigidbody2D, item as HierarchyItem); }
        
        private static void ComponentBoxCollider2DCallback(object item)
        { AssignComponent(ComponentType.BoxCollider2D, item as HierarchyItem); }
        
        private static void ComponentCircleCollider2DCallback(object item)
        { AssignComponent(ComponentType.CircleCollider2D, item as HierarchyItem); }
        
        private static void ComponentEdgeCollider2DCallback(object item)
        { AssignComponent(ComponentType.EdgeCollider2D, item as HierarchyItem); }
        
        private static void ComponentPolygonCollider2DCallback(object item)
        { AssignComponent(ComponentType.PolygonCollider2D, item as HierarchyItem); }
        
        private static void ComponentCapsuleCollider2DCallback(object item)
        { AssignComponent(ComponentType.CapsuleCollider2D, item as HierarchyItem); }
        
        private static void ComponentCompositeCollider2DCallback(object item)
        { AssignComponent(ComponentType.CompositeCollider2D, item as HierarchyItem); }
        
        private static void ComponentDistanceJoint2DCallback(object item)
        { AssignComponent(ComponentType.DistanceJoint2D, item as HierarchyItem); }
        
        private static void ComponentFixedJoint2DCallback(object item)
        { AssignComponent(ComponentType.FixedJoint2D, item as HierarchyItem); }
        
        private static void ComponentFrictionJoint2DCallback(object item)
        { AssignComponent(ComponentType.FrictionJoint2D, item as HierarchyItem); }
        
        private static void ComponentHingeJoint2DCallback(object item)
        { AssignComponent(ComponentType.HingeJoint2D, item as HierarchyItem); }
        
        private static void ComponentRelativeJoint2DCallback(object item)
        { AssignComponent(ComponentType.RelativeJoint2D, item as HierarchyItem); }
        
        private static void ComponentSliderJoint2DCallback(object item)
        { AssignComponent(ComponentType.SliderJoint2D, item as HierarchyItem); }
        
        private static void ComponentSpringJoint2DCallback(object item)
        { AssignComponent(ComponentType.SpringJoint, item as HierarchyItem); }
        
        private static void ComponentTargetJoint2DCallback(object item)
        { AssignComponent(ComponentType.TargetJoint2D, item as HierarchyItem); }
        
        private static void ComponentWheelJoint2DCallback(object item)
        { AssignComponent(ComponentType.WheelJoint2D, item as HierarchyItem); }
        
        private static void ComponentAreaEffector2DCallback(object item)
        { AssignComponent(ComponentType.AreaEffector2D, item as HierarchyItem); }
        
        private static void ComponentBuoyancyEffector2DCallback(object item)
        { AssignComponent(ComponentType.BuoyancyEffector2D, item as HierarchyItem); }
        
        private static void ComponentPointEffector2DCallback(object item)
        { AssignComponent(ComponentType.PointEffector2D, item as HierarchyItem); }
        
        private static void ComponentPlatformEffector2DCallback(object item)
        { AssignComponent(ComponentType.PlatformEffector2D, item as HierarchyItem); }
        
        private static void ComponentSurfaceEffector2DCallback(object item)
        { AssignComponent(ComponentType.SurfaceEffector2D, item as HierarchyItem); }
        
        private static void ComponentConstantForce2DCallback(object item)
        { AssignComponent(ComponentType.ConstantForce2D, item as HierarchyItem); }
        
        // Navigation
        
        private static void ComponentNavMeshAgentCallback(object item)
        { AssignComponent(ComponentType.NavMeshAgent, item as HierarchyItem); }
        
        private static void ComponentOffMeshLinkCallback(object item)
        { AssignComponent(ComponentType.OffMeshLink, item as HierarchyItem); }
        
        private static void ComponentNavMeshObstacleCallback(object item)
        { AssignComponent(ComponentType.NavMeshObstacle, item as HierarchyItem); }
        
        // Audio
        
        private static void ComponentAudioListenerCallback(object item)
        { AssignComponent(ComponentType.AudioListener, item as HierarchyItem); }
        
        private static void ComponentAudioSourceCallback(object item)
        { AssignComponent(ComponentType.AudioSource, item as HierarchyItem); }
        
        private static void ComponentAudioReverbZoneCallback(object item)
        { AssignComponent(ComponentType.AudioReverbZone, item as HierarchyItem); }
        
        private static void ComponentAudioLowPassFilterCallback(object item)
        { AssignComponent(ComponentType.AudioLowPassFilter, item as HierarchyItem); }
        
        private static void ComponentAudioHighPassFilterCallback(object item)
        { AssignComponent(ComponentType.AudioHighPassFilter, item as HierarchyItem); }
        
        private static void ComponentAudioEchoFilterCallback(object item)
        { AssignComponent(ComponentType.AudioEchoFilter, item as HierarchyItem); }
        
        private static void ComponentAudioDistortionFilterCallback(object item)
        { AssignComponent(ComponentType.AudioDistortionFilter, item as HierarchyItem); }
        
        private static void ComponentAudioReverbFilterCallback(object item)
        { AssignComponent(ComponentType.AudioReverbFilter, item as HierarchyItem); }
        
        private static void ComponentAudioChorusFilterCallback(object item)
        { AssignComponent(ComponentType.AudioChorusFilter, item as HierarchyItem); }
        
        // Video
        
        private static void ComponentVideoPlayerCallback(object item)
        { AssignComponent(ComponentType.VideoPlayer, item as HierarchyItem); }
        
        // Rendering
        
        private static void ComponentCameraCallback(object item)
        { AssignComponent(ComponentType.Camera, item as HierarchyItem); }
        
        private static void ComponentSkyboxCallback(object item)
        { AssignComponent(ComponentType.Skybox, item as HierarchyItem); }

        private static void ComponentFlareLayerCallback(object item)
        { AssignComponent(ComponentType.FlareLayer, item as HierarchyItem); }

         private static void ComponentLightCallback(object item)
        { AssignComponent(ComponentType.Light, item as HierarchyItem); }
        
        private static void ComponentLightProbeGroupCallback(object item)
        { AssignComponent(ComponentType.LightProbeGroup, item as HierarchyItem); }
        
        private static void ComponentLightProbeProxyVolumeCallback(object item)
        { AssignComponent(ComponentType.LightProbeProxyVolume, item as HierarchyItem); }
        
        private static void ComponentReflectionProbeCallback(object item)
        { AssignComponent(ComponentType.ReflectionProbe, item as HierarchyItem); }
        
        private static void ComponentOcclusionAreaCallback(object item)
        { AssignComponent(ComponentType.OcclusionArea, item as HierarchyItem); }
        
        private static void ComponentOcclusionPortalCallback(object item)
        { AssignComponent(ComponentType.OcclusionPortal, item as HierarchyItem); }
        
        private static void ComponentLodGroupCallback(object item)
        { AssignComponent(ComponentType.LodGroup, item as HierarchyItem); }
        
        private static void ComponentSpriteRendererCallback(object item)
        { AssignComponent(ComponentType.SpriteRenderer, item as HierarchyItem); }
        
        private static void ComponentSortingGroupCallback(object item)
        { AssignComponent(ComponentType.SortingGroup, item as HierarchyItem); }
        
        private static void ComponentCanvasRendererxCallback(object item)
        { AssignComponent(ComponentType.CanvasRenderer, item as HierarchyItem); }
        
        // Tilemap
        
        #if UNITY_2017_2_OR_NEWER
        private static void ComponentTilemapCallback(object item)
        { AssignComponent(ComponentType.Tilemap, item as HierarchyItem); }
        
        private static void ComponentTilemapRendererCallback(object item)
        { AssignComponent(ComponentType.TilemapRenderer, item as HierarchyItem); }
        
        private static void ComponentTilemapCollider2DCallback(object item)
        { AssignComponent(ComponentType.TilemapCollider2D, item as HierarchyItem); }
        #endif
        
        // Layout
        
        private static void ComponentRectTransformCallback(object item)
        { AssignComponent(ComponentType.RectTransform, item as HierarchyItem); }
        
        private static void ComponentCanvasCallback(object item)
        { AssignComponent(ComponentType.Canvas, item as HierarchyItem); }
        
        private static void ComponentCanvasGroupCallback(object item)
        { AssignComponent(ComponentType.CanvasGroup, item as HierarchyItem); }
        
        private static void ComponentCanvasScalerCallback(object item)
        { AssignComponent(ComponentType.CanvasScaler, item as HierarchyItem); }
        
        private static void ComponentLayoutElementCallback(object item)
        { AssignComponent(ComponentType.LayoutElement, item as HierarchyItem); }
        
        private static void ComponentContentSizeFitterCallback(object item)
        { AssignComponent(ComponentType.ContentSizeFitter, item as HierarchyItem); }
        
        private static void ComponentAspectRatioFitterCallback(object item)
        { AssignComponent(ComponentType.AspectRatioFitter, item as HierarchyItem); }
        
        private static void ComponentHorizontalLayoutGroupCallback(object item)
        { AssignComponent(ComponentType.HorizontalLayoutGroup, item as HierarchyItem); }
        
        private static void ComponentVerticalLayoutGroupCallback(object item)
        { AssignComponent(ComponentType.VerticalLayoutGroup, item as HierarchyItem); }
        
        private static void ComponentGridLayoutGroupCallback(object item)
        { AssignComponent(ComponentType.GridLayoutGroup, item as HierarchyItem); }
        
        // Playable
        
        private static void ComponentPlayableDirectorCallback(object item)
        { AssignComponent(ComponentType.PlayableDirector, item as HierarchyItem); }
        
        // AR
        
        #if UNITY_2017_2_OR_NEWER
        private static void ComponentWorldAnchorCallback(object item)
        { AssignComponent(ComponentType.WorldAnchor, item as HierarchyItem); }
        #endif
        
        // Miscellaneous
        
        private static void ComponentBillboardRendererCallback(object item)
        { AssignComponent(ComponentType.BillboardRenderer, item as HierarchyItem); }
        
        private static void ComponentTerrainCallback(object item)
        { AssignComponent(ComponentType.Terrain, item as HierarchyItem); }
        
        private static void ComponentAnimatorCallback(object item)
        { AssignComponent(ComponentType.Animator, item as HierarchyItem); }
        
        private static void ComponentAnimationCallback(object item)
        { AssignComponent(ComponentType.Animation, item as HierarchyItem); }
        
        #if UNITY_2017_2_OR_NEWER
        private static void ComponentGridCallback(object item)
        { AssignComponent(ComponentType.Grid, item as HierarchyItem); }
        #endif
        
        private static void ComponentWindZoneCallback(object item)
        { AssignComponent(ComponentType.WindZone, item as HierarchyItem); }
        
        private static void ComponentSpriteMaskCallback(object item)
        { AssignComponent(ComponentType.SpriteMask, item as HierarchyItem); }
        
        // Event
        
        private static void ComponentEventSystemCallback(object item)
        { AssignComponent(ComponentType.EventSystem, item as HierarchyItem); }
        
        private static void ComponentHoloLensInputModuleCallback(object item)
        { AssignComponent(ComponentType.HoloLensInputModule, item as HierarchyItem); }
        
        private static void ComponentEventTriggerCallback(object item)
        { AssignComponent(ComponentType.EventTrigger, item as HierarchyItem); }
        
        private static void ComponentPhysics2DRaycasterCallback(object item)
        { AssignComponent(ComponentType.Physics2DRaycaster, item as HierarchyItem); }
        
        private static void ComponentPhysicsRaycasterCallback(object item)
        { AssignComponent(ComponentType.PhysicsRaycaster, item as HierarchyItem); }
        
        private static void ComponentStandaloneInputModuleCallback(object item)
        { AssignComponent(ComponentType.StandaloneInputModule, item as HierarchyItem); }
        
        private static void ComponentGraphicRaycasterCallback(object item)
        { AssignComponent(ComponentType.GraphicRaycaster, item as HierarchyItem); }
        
        // Network
        
        private static void ComponentNetworkAnimatorCallback(object item)
        { AssignComponent(ComponentType.NetworkAnimator, item as HierarchyItem); }
        
        private static void ComponenNetworkDiscoveryCallback(object item)
        { AssignComponent(ComponentType.NetworkDiscovery, item as HierarchyItem); }
        
        private static void ComponentNetworkIdentityCallback(object item)
        { AssignComponent(ComponentType.NetworkIdentity, item as HierarchyItem); }
        
        private static void ComponentNetworkLobbyManagerCallback(object item)
        { AssignComponent(ComponentType.NetworkLobbyManager, item as HierarchyItem); }
        
        private static void ComponentNetworkManagerCallback(object item)
        { AssignComponent(ComponentType.NetworkManager, item as HierarchyItem); }
        
        private static void ComponentNetworkManagerHudCallback(object item)
        { AssignComponent(ComponentType.NetworkManagerHud, item as HierarchyItem); }
        
        private static void ComponentNetworkMigrationManagerCallback(object item)
        { AssignComponent(ComponentType.NetworkMigrationManager, item as HierarchyItem); }
        
        private static void ComponentNetworkProximityCheckerCallback(object item)
        { AssignComponent(ComponentType.NetworkProximityChecker, item as HierarchyItem); }
        
        private static void ComponentNetworkStartPositionCallback(object item)
        { AssignComponent(ComponentType.NetworkStartPosition, item as HierarchyItem); }
        
        private static void ComponentNetworkTransformCallback(object item)
        { AssignComponent(ComponentType.NetworkTransform, item as HierarchyItem); }
        
        private static void ComponentNetworkTransformChildCallback(object item)
        { AssignComponent(ComponentType.NetworkTransformChild, item as HierarchyItem); }
        
        private static void ComponentNetworkTransformVisualizerCallback(object item)
        { AssignComponent(ComponentType.NetworkTransformVisualizer, item as HierarchyItem); }
        
        // XR
        
        #if UNITY_2017_2_OR_NEWER
        private static void ComponentSpatialMappingColliderCallback(object item)
        { AssignComponent(ComponentType.SpatialMappingCollider, item as HierarchyItem); }
        
        private static void ComponenSpatialMappingRendererCallback(object item)
        { AssignComponent(ComponentType.SpatialMappingRenderer, item as HierarchyItem); }
        #endif
        
        // UI
        
        private static void ComponentTextCallback(object item)
        { AssignComponent(ComponentType.Text, item as HierarchyItem); }
        
        private static void ComponenImageCallback(object item)
        { AssignComponent(ComponentType.Image, item as HierarchyItem); }
        
        private static void ComponenRawImageCallback(object item)
        { AssignComponent(ComponentType.RawImage, item as HierarchyItem); }
        
        private static void ComponenMaskCallback(object item)
        { AssignComponent(ComponentType.Mask, item as HierarchyItem); }
        
        private static void ComponenButtonCallback(object item)
        { AssignComponent(ComponentType.Button, item as HierarchyItem); }
        
        private static void ComponenInputFieldCallback(object item)
        { AssignComponent(ComponentType.InputField, item as HierarchyItem); }
        
        private static void ComponenToggleCallback(object item)
        { AssignComponent(ComponentType.Toggle, item as HierarchyItem); }
        
        private static void ComponenToggleGroupCallback(object item)
        { AssignComponent(ComponentType.ToggleGroup, item as HierarchyItem); }
        
        private static void ComponenSliderCallback(object item)
        { AssignComponent(ComponentType.Slider, item as HierarchyItem); }
        
        private static void ComponenScrollbarCallback(object item)
        { AssignComponent(ComponentType.Scrollbar, item as HierarchyItem); }
        
        private static void ComponenDropdownCallback(object item)
        { AssignComponent(ComponentType.Dropdown, item as HierarchyItem); }
        
        private static void ComponenScrollRectCallback(object item)
        { AssignComponent(ComponentType.ScrollRect, item as HierarchyItem); }
        
        private static void ComponenSelectableCallback(object item)
        { AssignComponent(ComponentType.Selectable, item as HierarchyItem); }

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
            var colorIcon = HierarchyColorsStorage.Instance.GetIconByColor(color);
            hierarchyItem.Icon = colorIcon;
            hierarchyItem.IsIconCustom = false;
        }
        
        private static void AssignComponent(ComponentType name, HierarchyItem hierarchyItem)
        {
            var componentIcon = ComponentIconStorage.GetIconByName(name);
            hierarchyItem.Icon = componentIcon;
            hierarchyItem.IsIconCustom = false;
        }
        
        private static void SelectNone(HierarchyItem hierarchyItem)
        {
            hierarchyItem.Icon = null;
            hierarchyItem.IsIconCustom = false;
            hierarchyItem.IsIconRecursive = false;
        }

        private static void SelectCustom(HierarchyItem hierarchyItem)
        {
            hierarchyItem.IsIconCustom = true;
        }               
    }
}