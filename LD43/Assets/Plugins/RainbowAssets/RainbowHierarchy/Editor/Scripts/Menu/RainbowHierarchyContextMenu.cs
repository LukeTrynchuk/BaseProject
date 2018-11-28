using System.Linq;
using Borodar.RainbowHierarchy.Components;
using UnityEditor;
using UnityEngine;

namespace Borodar.RainbowHierarchy
{
    public static class RainbowHierarchyContextMenu
    {

        private const long DELAY_TICKS = 5000000; // 0.5 second
        
        // Menus
        private const string MENU_BASE = "GameObject/Rainbow Hierarchy/";
        
        // Items
        private const string ITEM_CUSTOM = MENU_BASE + "Apply Custom";
        private const string ITEM_DEFAULT = MENU_BASE + "Revert to Default";
        
        // Sub-menus        
        private const string MENU_ICON = MENU_BASE + "Icon/";
        private const string MENU_BACKGROUND = MENU_BASE + "Background/";

        private const string MENU_COLOR = MENU_ICON + "Color/";
        private const string MENU_COMPONENT = MENU_ICON + "Component/";
        
        // Component sub-menus
        private const string MENU_COMPONENTS_GENERAL = MENU_COMPONENT + "General/";
        private const string MENU_COMPONENTS_MESHES = MENU_COMPONENT + "Meshes/";
        private const string MENU_COMPONENTS_EFFECTS = MENU_COMPONENT + "Effects/";
        private const string MENU_COMPONENTS_PHYSICS = MENU_COMPONENT + "Physics/";
        private const string MENU_COMPONENTS_PHYSICS_2D = MENU_COMPONENT + "Physics 2D/";
        private const string MENU_COMPONENTS_NAVIGATION = MENU_COMPONENT + "Navigation/";
        private const string MENU_COMPONENTS_AUDIO = MENU_COMPONENT + "Audio/";
        private const string MENU_COMPONENTS_VIDEO = MENU_COMPONENT + "Video/";
        private const string MENU_COMPONENTS_RENDERING = MENU_COMPONENT + "Rendering/";
        private const string MENU_COMPONENTS_TILEMAP = MENU_COMPONENT + "Tilemap/";
        private const string MENU_COMPONENTS_LAYOUT = MENU_COMPONENT + "Layout/";
        private const string MENU_COMPONENTS_PLAYABLES = MENU_COMPONENT + "Playables/";
        private const string MENU_COMPONENTS_AR = MENU_COMPONENT + "AR/";
        private const string MENU_COMPONENTS_MISCELLANEOUS = MENU_COMPONENT + "Miscellaneous/";
        private const string MENU_COMPONENTS_EVENT = MENU_COMPONENT + "Event/";
        private const string MENU_COMPONENTS_NETWORK = MENU_COMPONENT + "Network/";
        private const string MENU_COMPONENTS_XR = MENU_COMPONENT + "XR/";
        private const string MENU_COMPONENTS_UI = MENU_COMPONENT + "UI/";
        
        // Colors
        private const string COLOR_RED = MENU_COLOR + "Red";
        private const string COLOR_VERMILION = MENU_COLOR + "Vermilion";
        private const string COLOR_ORANGE = MENU_COLOR + "Orange";
        private const string COLOR_AMBER = MENU_COLOR + "Amber";
        private const string COLOR_YELLOW = MENU_COLOR + "Yellow";
        private const string COLOR_LIME = MENU_COLOR + "Lime";
        private const string COLOR_CHARTREUSE = MENU_COLOR + "Chartreuse";
        private const string COLOR_HARLEQUIN = MENU_COLOR + "Harlequin";
        private const string COLOR_GREEN = MENU_COLOR + "Green";
        private const string COLOR_EMERALD = MENU_COLOR + "Emerald";
        private const string COLOR_SPRING_GREEN = MENU_COLOR + "Spring-green";
        private const string COLOR_AQUAMARINE = MENU_COLOR + "Aquamarine";
        private const string COLOR_CYAN = MENU_COLOR + "Cyan";
        private const string COLOR_SKY_BLUE = MENU_COLOR + "Sky-blue";
        private const string COLOR_AZURE = MENU_COLOR + "Azure";
        private const string COLOR_CERULEAN = MENU_COLOR + "Cerulean";
        private const string COLOR_BLUE = MENU_COLOR + "Blue";
        private const string COLOR_INDIGO = MENU_COLOR + "Indigo";
        private const string COLOR_VIOLET = MENU_COLOR + "Violet";
        private const string COLOR_PURPLE = MENU_COLOR + "Purple";
        private const string COLOR_MAGENTA = MENU_COLOR + "Magenta";
        private const string COLOR_FUCHSIA = MENU_COLOR + "Fuchsia";
        private const string COLOR_ROSE = MENU_COLOR + "Rose";
        private const string COLOR_CRIMSON = MENU_COLOR + "Crimson";
        
        // Components 
        private const string COMPONENT_GAME_OBJECT = MENU_COMPONENTS_GENERAL + "Game Object";
        private const string COMPONENT_TRANSFORM = MENU_COMPONENTS_GENERAL + "Transform";
        private const string COMPONENT_DEFAULT_ASSET = MENU_COMPONENTS_GENERAL + "Default Asset";
        private const string COMPONENT_TEXT_ASSET = MENU_COMPONENTS_GENERAL + "Text Asset";
        private const string COMPONENT_CS_SCRIPT = MENU_COMPONENTS_GENERAL + "Cs Script";
        private const string COMPONENT_JS_SCRIPT = MENU_COMPONENTS_GENERAL + "Js Script";
        private const string COMPONENT_SHADER = MENU_COMPONENTS_GENERAL + "Shader";
        private const string COMPONENT_PREFAB = MENU_COMPONENTS_GENERAL + "Prefab";
        private const string COMPONENT_SCRIPTABLE_OBJECT = MENU_COMPONENTS_GENERAL + "Scriptable Object";
        private const string COMPONENT_SCENE_ASSET = MENU_COMPONENTS_GENERAL + "Scene";
        // Meshes
        private const string COMPONENT_MESH_FILTER = MENU_COMPONENTS_MESHES + "Mesh Filter";
        private const string COMPONENT_TEXT_MESH = MENU_COMPONENTS_MESHES + "Text Mesh";
        private const string COMPONENT_MESH_RENDERER = MENU_COMPONENTS_MESHES + "Mesh Renderer";
        private const string COMPONENT_SKIN_MESH_RENDERER = MENU_COMPONENTS_MESHES + "Skinned Mesh Renderer";
        // Effects
        private const string COMPONENT_PARTICLE_SYSTEM = MENU_COMPONENTS_EFFECTS + "Particle System";
        private const string COMPONENT_TRAIL_RENDERER = MENU_COMPONENTS_EFFECTS + "Trail Renderer";
        private const string COMPONENT_LINE_RENDERER = MENU_COMPONENTS_EFFECTS + "Line Renderer";
        private const string COMPONENT_LENS_FLARE = MENU_COMPONENTS_EFFECTS + "Lens Flare";
        private const string COMPONENT_PROJECTOR = MENU_COMPONENTS_EFFECTS + "Projector";
        // Physics
        private const string COMPONENT_RIGIDBODY = MENU_COMPONENTS_PHYSICS + "Rigidbody";
        private const string COMPONENT_CHARACTER_CONTROLLER = MENU_COMPONENTS_PHYSICS + "Character Controller";
        private const string COMPONENT_BOX_COLLIDER = MENU_COMPONENTS_PHYSICS + "Box Collider";
        private const string COMPONENT_SPHERE_COLLIDER = MENU_COMPONENTS_PHYSICS + "Sphere Collider";
        private const string COMPONENT_CAPSULE_COLLIDER = MENU_COMPONENTS_PHYSICS + "Capsule Collider";
        private const string COMPONENT_MESH_COLLIDER = MENU_COMPONENTS_PHYSICS + "Mesh Collider";
        private const string COMPONENT_WHEEL_COLLIDER = MENU_COMPONENTS_PHYSICS + "Wheel Collider";
        private const string COMPONENT_TERRAIN_COLLIDER = MENU_COMPONENTS_PHYSICS + "Terrain Collider";
        private const string COMPONENT_CLOTH = MENU_COMPONENTS_PHYSICS + "Cloth";
        private const string COMPONENT_HINGE_JOINT = MENU_COMPONENTS_PHYSICS + "Hingle Joint";
        private const string COMPONENT_FIXED_JOINT = MENU_COMPONENTS_PHYSICS + "Fixed Joint";
        private const string COMPONENT_SPRING_JOINT = MENU_COMPONENTS_PHYSICS + "Spring Joint";
        private const string COMPONENT_CHARACTER_JOINT = MENU_COMPONENTS_PHYSICS + "Character Joint";
        private const string COMPONENT_CONFIGURABLE_JOINT = MENU_COMPONENTS_PHYSICS + "Configurable Joint";
        private const string COMPONENT_CONSTANT_FORCE = MENU_COMPONENTS_PHYSICS + "Constant Force";
        // Physics 2D
        private const string COMPONENT_RIGIDBODY_2D = MENU_COMPONENTS_PHYSICS_2D + "Rigidbody 2D";
        private const string COMPONENT_BOXCOLLIDER_2D = MENU_COMPONENTS_PHYSICS_2D + "Box Collider 2D";
        private const string COMPONENT_CIRCLE_COLLIDER_2D = MENU_COMPONENTS_PHYSICS_2D + "Circle Collider 2D";
        private const string COMPONENT_EDGE_COLLIDER_2D = MENU_COMPONENTS_PHYSICS_2D + "Edge Collider 2D";
        private const string COMPONENT_POLYGON_COLLIDER_2D = MENU_COMPONENTS_PHYSICS_2D + "Polygon Collider 2D";
        private const string COMPONENT_CAPSULE_COLLIDER_2D = MENU_COMPONENTS_PHYSICS_2D + "Capsule Collider 2D";
        private const string COMPONENT_COMPOSITE_COLLIDER_2D = MENU_COMPONENTS_PHYSICS_2D + "Composite Collider 2D";
        private const string COMPONENT_DISTANCE_JOINT_2D = MENU_COMPONENTS_PHYSICS_2D + "Distance Joint 2D";
        private const string COMPONENT_FIXED_JOINT_2D = MENU_COMPONENTS_PHYSICS_2D + "Fixed Joint 2D";
        private const string COMPONENT_FRICTION_JOINT_2D = MENU_COMPONENTS_PHYSICS_2D + "Friction Joint 2D";
        private const string COMPONENT_HINGE_JOINT_2D = MENU_COMPONENTS_PHYSICS_2D + "Hinge Joint 2D";
        private const string COMPONENT_RELATIVE_JOINT_2D = MENU_COMPONENTS_PHYSICS_2D + "Relative Joint 2D";
        private const string COMPONENT_SLIDER_JOINT_2D = MENU_COMPONENTS_PHYSICS_2D + "Slider Joint 2D";
        private const string COMPONENT_SPRING_JOINT_2D = MENU_COMPONENTS_PHYSICS_2D + "Spring Joint 2D";
        private const string COMPONENT_TARGET_JOINT_2D = MENU_COMPONENTS_PHYSICS_2D + "Target Joint 2D";
        private const string COMPONENT_WHEEL_JOINT_2D = MENU_COMPONENTS_PHYSICS_2D + "Wheel Joint 2D";
        private const string COMPONENT_AREA_EFFECTOR_2D = MENU_COMPONENTS_PHYSICS_2D + "Area Effector 2D";
        private const string COMPONENT_BUOYANCY_EFFECTOR_2D = MENU_COMPONENTS_PHYSICS_2D + "Buoyancy Effector 2D";
        private const string COMPONENT_POINT_EFFECTOR_2D = MENU_COMPONENTS_PHYSICS_2D + "Point Effector 2D";
        private const string COMPONENT_PLATFORM_EFFECTOR_2D = MENU_COMPONENTS_PHYSICS_2D + "Platform Effector 2D";
        private const string COMPONENT_SURFACE_EFFECTOR_2D = MENU_COMPONENTS_PHYSICS_2D + "Surface Effector 2D";
        private const string COMPONENT_CONSTANT_FORCE_2D = MENU_COMPONENTS_PHYSICS_2D + "Constant Force 2D";
        // Navigation
        private const string COMPONENT_NAV_MESH_AGENT = MENU_COMPONENTS_NAVIGATION + "Nav Mesh Agent";
        private const string COMPONENT_OFF_MESH_LINK = MENU_COMPONENTS_NAVIGATION + "Off Mesh Link";
        private const string COMPONENT_NAV_MESH_OBSTACLE = MENU_COMPONENTS_NAVIGATION + "Nav Mesh Obstacle";
        // Audio
        private const string COMPONENT_AUDIO_LISTENER = MENU_COMPONENTS_AUDIO + "Audio Listener";
        private const string COMPONENT_AUDIO_SOURCE = MENU_COMPONENTS_AUDIO + "Audio Source";
        private const string COMPONENT_AUDIO_REVERB_ZONE = MENU_COMPONENTS_AUDIO + "Audio Reverb Zone";
        private const string COMPONENT_AUDIO_LOW_PASS_FILTER = MENU_COMPONENTS_AUDIO + "Audio Low Pass Filter";
        private const string COMPONENT_AUDIO_HIGH_PASS_FILTER = MENU_COMPONENTS_AUDIO + "Audio High Pass Filter";
        private const string COMPONENT_AUDIO_ECHO_FILTER = MENU_COMPONENTS_AUDIO + "Audio Echo Filter";
        private const string COMPONENT_AUDIO_DISTORTION_FILTER = MENU_COMPONENTS_AUDIO + "Audio Distortion Filter";
        private const string COMPONENT_AUDIO_REVERB_FILTER = MENU_COMPONENTS_AUDIO + "Audio Reverb Filter";
        private const string COMPONENT_AUDIO_CHORUS_FILTER = MENU_COMPONENTS_AUDIO + "Audio Chorus Filter";
        // Video
        private const string COMPONENT_VIDEO_PLAYER = MENU_COMPONENTS_VIDEO + "Video Player";
        // Rendering
        private const string COMPONENT_CAMERA = MENU_COMPONENTS_RENDERING + "Camera";
        private const string COMPONENT_SKYBOX = MENU_COMPONENTS_RENDERING + "Skybox";
        private const string COMPONENT_FLARE_LAYER = MENU_COMPONENTS_RENDERING + "Flare Layer";
        private const string COMPONENT_LIGHT = MENU_COMPONENTS_RENDERING + "Light";
        private const string COMPONENT_LIGHT_PROBE_GROUP = MENU_COMPONENTS_RENDERING + "Light Probe Group";
        private const string COMPONENT_LIGHT_PROBE_PROXY_VOLUME = MENU_COMPONENTS_RENDERING + "Light Probe Proxy Volume";
        private const string COMPONENT_REFLECTION_PROBE = MENU_COMPONENTS_RENDERING + "Reflection Probe";
        private const string COMPONENT_OCCLUSION_AREA = MENU_COMPONENTS_RENDERING + "Occlusion Area";
        private const string COMPONENT_OCCLUSION_PORTAL = MENU_COMPONENTS_RENDERING + "Occlusion Portal";
        private const string COMPONENT_LOD_GROUP = MENU_COMPONENTS_RENDERING + "LOD Group";
        private const string COMPONENT_SPRITE_RENDERER = MENU_COMPONENTS_RENDERING + "Sprite Renderer";
        private const string COMPONENT_SORTING_GROUP = MENU_COMPONENTS_RENDERING + "Sorting Group";
        private const string COMPONENT_CANVAS_RENDERER = MENU_COMPONENTS_RENDERING + "Canvas Renderer";
        // Tilemap
        private const string COMPONENT_TILEMAP = MENU_COMPONENTS_TILEMAP + "Tilemap";
        private const string COMPONENT_TILEMAP_RENDERER = MENU_COMPONENTS_TILEMAP + "Tilemap Renderer";
        private const string COMPONENT_TILEMAP_COLLIDER_2D = MENU_COMPONENTS_TILEMAP + "Tilemap Collider 2D";
        // Layout
        private const string COMPONENT_RECT_TRANSFORM = MENU_COMPONENTS_LAYOUT + "Rect Transform";
        private const string COMPONENT_CANVAS = MENU_COMPONENTS_LAYOUT + "Canvas";
        private const string COMPONENT_CANVAS_GROUP = MENU_COMPONENTS_LAYOUT + "Canvas Group";
        private const string COMPONENT_CANVAS_SCALER = MENU_COMPONENTS_LAYOUT + "Canvas Scaler";
        private const string COMPONENT_LAYOUT_ELEMENT = MENU_COMPONENTS_LAYOUT + "Layout Element";
        private const string COMPONENT_CONTENT_SIZE_FITTER = MENU_COMPONENTS_LAYOUT + "Content Size Fitter";
        private const string COMPONENT_ASPECT_RATIO_FITTER = MENU_COMPONENTS_LAYOUT + "Aspect Ratio Fitter";
        private const string COMPONENT_HORIZONTAL_LAYOUT_GROUP = MENU_COMPONENTS_LAYOUT + "Horizontal Layout Group";
        private const string COMPONENT_VERTICAL_LAYOUT_GROUP = MENU_COMPONENTS_LAYOUT + "Vertical Layout Group";
        private const string COMPONENT_GRID_LAYOUT_GROUP = MENU_COMPONENTS_LAYOUT + "Grid Layout Group";
        // Playables
        private const string COMPONENT_PLAYABLE_DIRECTOR = MENU_COMPONENTS_PLAYABLES + "Playable Director";
        // AR
        private const string COMPONENT_WORLD_ANCHOR = MENU_COMPONENTS_AR + "World Anchor";
        // Miscellaneous
        private const string COMPONENT_BILLBOARD_RENDERER = MENU_COMPONENTS_MISCELLANEOUS + "Billboard Renderer";
        private const string COMPONENT_TERRAIN = MENU_COMPONENTS_MISCELLANEOUS + "Terrain";
        private const string COMPONENT_ANIMATOR = MENU_COMPONENTS_MISCELLANEOUS + "Animator";
        private const string COMPONENT_ANIMATION = MENU_COMPONENTS_MISCELLANEOUS + "Animation";
        private const string COMPONENT_GRID = MENU_COMPONENTS_MISCELLANEOUS + "Grid";
        private const string COMPONENT_WINDZONE = MENU_COMPONENTS_MISCELLANEOUS + "Wind Zone";
        private const string COMPONENT_SPRITE_MASK = MENU_COMPONENTS_MISCELLANEOUS + "Sprite Mask";
        // Event
        private const string COMPONENT_EVENT_SYSTEM = MENU_COMPONENTS_EVENT + "Event System";
        private const string COMPONENT_HOLOLENS_INPUT_MODULE = MENU_COMPONENTS_EVENT + "HoloLens Input Module";
        private const string COMPONENT_EVENT_TRIGGER = MENU_COMPONENTS_EVENT + "Event Trigger";
        private const string COMPONENT_PHYSICS_2D_RAYCASTER = MENU_COMPONENTS_EVENT + "Physics 2D Raycaster";
        private const string COMPONENT_PHYSICS_RAYCASTER = MENU_COMPONENTS_EVENT + "Physics Raycaster";
        private const string COMPONENT_STANDALONE_INPUT_MODULE = MENU_COMPONENTS_EVENT + "Standalone Input Module";
        private const string COMPONENT_GRAPHIC_RAYCASTER = MENU_COMPONENTS_EVENT + "Graphic Raycaster";
        // Network
        private const string COMPONENT_NETWORK_ANIMATOR = MENU_COMPONENTS_NETWORK + "Network Animator";
        private const string COMPONENT_NETWORK_DISCOVERY = MENU_COMPONENTS_NETWORK + "Network Discovery";
        private const string COMPONENT_NETWORK_IDENTITY = MENU_COMPONENTS_NETWORK + "Network Identity";
        private const string COMPONENT_NETWORK_LOBBY_MANAGER = MENU_COMPONENTS_NETWORK + "Network Lobby Manager";
        private const string COMPONENT_NETWORK_MANAGER = MENU_COMPONENTS_NETWORK + "Network Manager";
        private const string COMPONENT_NETWORK_MANAGER_HUD = MENU_COMPONENTS_NETWORK + "Network Manager HUD";
        private const string COMPONENT_NETWORK_MIGRATION_MANAGER = MENU_COMPONENTS_NETWORK + "Network Migration Manager";
        private const string COMPONENT_NETWORK_PROXIMITY_CHECKER = MENU_COMPONENTS_NETWORK + "Network Proximity Checker";
        private const string COMPONENT_NETWORK_START_POSITION = MENU_COMPONENTS_NETWORK + "Network Start Position";
        private const string COMPONENT_NETWORK_TRANSFORM = MENU_COMPONENTS_NETWORK + "Network Transform";
        private const string COMPONENT_NETWORK_TRANSFORM_CHILD = MENU_COMPONENTS_NETWORK + "Network Transform Child";
        private const string COMPONENT_NETWORK_TRANSFORM_VISUALIZER = MENU_COMPONENTS_NETWORK + "NetworkTransformVisualizer";
        // XR
        private const string COMPONENT_SPATIAL_MAPPING_COLLIDER = MENU_COMPONENTS_XR + "Spatial Mapping Collider";
        private const string COMPONENT_SPATIAL_MAPPING_RENDERER = MENU_COMPONENTS_XR + "Spatial Mapping Renderer";
        // UI
        private const string COMPONENT_TEXT = MENU_COMPONENTS_UI + "Text";
        private const string COMPONENT_IMAGE = MENU_COMPONENTS_UI + "Image";
        private const string COMPONENT_RAW_IMAGE = MENU_COMPONENTS_UI + "Raw Image";
        private const string COMPONENT_MASK = MENU_COMPONENTS_UI + "Mask";
        private const string COMPONENT_BUTTON = MENU_COMPONENTS_UI + "Button";
        private const string COMPONENT_INPUT_FIELD = MENU_COMPONENTS_UI + "Input Field";
        private const string COMPONENT_TOGGLE = MENU_COMPONENTS_UI + "Toggle";
        private const string COMPONENT_TOGGLE_GROUP = MENU_COMPONENTS_UI + "Toggle Group";
        private const string COMPONENT_SLIDER = MENU_COMPONENTS_UI + "Slider";
        private const string COMPONENT_SCROLLBAR = MENU_COMPONENTS_UI + "Scrollbar";
        private const string COMPONENT_DROPDOWN = MENU_COMPONENTS_UI + "Dropdown";
        private const string COMPONENT_SCROLL_RECT = MENU_COMPONENTS_UI + "ScrollRect";
        private const string COMPONENT_SELECTABLE = MENU_COMPONENTS_UI + "Selectable";
        
        // Backgrounds
        private const string BACKGROUND_RED = MENU_BACKGROUND + "Red";
        private const string BACKGROUND_VERMILION = MENU_BACKGROUND + "Vermilion";
        private const string BACKGROUND_ORANGE = MENU_BACKGROUND + "Orange";
        private const string BACKGROUND_AMBER = MENU_BACKGROUND + "Amber";
        private const string BACKGROUND_YELLOW = MENU_BACKGROUND + "Yellow";
        private const string BACKGROUND_LIME = MENU_BACKGROUND + "Lime";
        private const string BACKGROUND_CHARTREUSE = MENU_BACKGROUND + "Chartreuse";
        private const string BACKGROUND_HARLEQUIN = MENU_BACKGROUND + "Harlequin";
        private const string BACKGROUND_GREEN = MENU_BACKGROUND + "Green";
        private const string BACKGROUND_EMERALD = MENU_BACKGROUND + "Emerald";
        private const string BACKGROUND_SPRING_GREEN = MENU_BACKGROUND + "Spring-green";
        private const string BACKGROUND_AQUAMARINE = MENU_BACKGROUND + "Aquamarine";
        private const string BACKGROUND_CYAN = MENU_BACKGROUND + "Cyan";
        private const string BACKGROUND_SKY_BLUE = MENU_BACKGROUND + "Sky-blue";
        private const string BACKGROUND_AZURE = MENU_BACKGROUND + "Azure";
        private const string BACKGROUND_CERULEAN = MENU_BACKGROUND + "Cerulean";
        private const string BACKGROUND_BLUE = MENU_BACKGROUND + "Blue";
        private const string BACKGROUND_INDIGO = MENU_BACKGROUND + "Indigo";
        private const string BACKGROUND_VIOLET = MENU_BACKGROUND + "Violet";
        private const string BACKGROUND_PURPLE = MENU_BACKGROUND + "Purple";
        private const string BACKGROUND_MAGENTA = MENU_BACKGROUND + "Magenta";
        private const string BACKGROUND_FUCHSIA = MENU_BACKGROUND + "Fuchsia";
        private const string BACKGROUND_ROSE = MENU_BACKGROUND + "Rose";
        private const string BACKGROUND_CRIMSON = MENU_BACKGROUND + "Crimson";
        
        // Items Priorites
        private const int PREFAB_PRIORITY = 11;
        private const int DEFAULT_PRIORITY = 12;
        
        // Last Execute Time
        private static long _lastExecuteTicks = -1;

        //---------------------------------------------------------------------
        // Menu Items
        //---------------------------------------------------------------------

        [MenuItem(ITEM_CUSTOM, false, DEFAULT_PRIORITY)]
        public static void ApplyCustomMenu()
        {
            ApplyCustom();
        }

        [MenuItem(ITEM_DEFAULT, false, DEFAULT_PRIORITY)]
        public static void RevertToDefaultMenu()
        {
            RevertToDefault();
        }
        
        
        // Colors

        [MenuItem(COLOR_RED, false, PREFAB_PRIORITY)]
        public static void IconRed()
        {
            ColorizeIcon(HierarchyColorName.Red);
        }

        [MenuItem(COLOR_VERMILION, false, PREFAB_PRIORITY)]
        public static void IconVermilion()
        {
            ColorizeIcon(HierarchyColorName.Vermilion);
        }
        
        [MenuItem(COLOR_ORANGE, false, PREFAB_PRIORITY)]
        public static void IconOrange()
        {
            ColorizeIcon(HierarchyColorName.Orange);
        }
        
        [MenuItem(COLOR_AMBER, false, PREFAB_PRIORITY)]
        public static void IconAmber()
        {
            ColorizeIcon(HierarchyColorName.Amber);
        }
        
        [MenuItem(COLOR_YELLOW, false, PREFAB_PRIORITY)]
        public static void IconYellow()
        {
            ColorizeIcon(HierarchyColorName.Yellow);
        }
        
        [MenuItem(COLOR_LIME, false, PREFAB_PRIORITY)]
        public static void IconLime()
        {
            ColorizeIcon(HierarchyColorName.Lime);
        }
        
        [MenuItem(COLOR_CHARTREUSE, false, PREFAB_PRIORITY)]
        public static void IconChartreuse()
        {
            ColorizeIcon(HierarchyColorName.Chartreuse);
        }
        
        [MenuItem(COLOR_HARLEQUIN, false, PREFAB_PRIORITY)]
        public static void IconHarlequin()
        {
            ColorizeIcon(HierarchyColorName.Harlequin);
        }
        
        [MenuItem(COLOR_GREEN, false, PREFAB_PRIORITY)]
        public static void IconGreen()
        {
            ColorizeIcon(HierarchyColorName.Green);
        }
        
        [MenuItem(COLOR_EMERALD, false, PREFAB_PRIORITY)]
        public static void IconEmerald()
        {
            ColorizeIcon(HierarchyColorName.Emerald);
        }
        
        [MenuItem(COLOR_SPRING_GREEN, false, PREFAB_PRIORITY)]
        public static void IconSpringGreen()
        {
            ColorizeIcon(HierarchyColorName.SpringGreen);
        }
        
        [MenuItem(COLOR_AQUAMARINE, false, PREFAB_PRIORITY)]
        public static void IconAquamarine()
        {
            ColorizeIcon(HierarchyColorName.Aquamarine);
        }
        
        [MenuItem(COLOR_CYAN, false, PREFAB_PRIORITY)]
        public static void IconCyan()
        {
            ColorizeIcon(HierarchyColorName.Cyan);
        }
        
        [MenuItem(COLOR_SKY_BLUE, false, PREFAB_PRIORITY)]
        public static void IconSkyBlue()
        {
            ColorizeIcon(HierarchyColorName.SkyBlue);
        }
        
        [MenuItem(COLOR_AZURE, false, PREFAB_PRIORITY)]
        public static void IconAzure()
        {
            ColorizeIcon(HierarchyColorName.Azure);
        }
        
        [MenuItem(COLOR_CERULEAN, false, PREFAB_PRIORITY)]
        public static void IconCerulean()
        {
            ColorizeIcon(HierarchyColorName.Cerulean);
        }
        
        [MenuItem(COLOR_BLUE, false, PREFAB_PRIORITY)]
        public static void IconBlue()
        {
            ColorizeIcon(HierarchyColorName.Blue);
        }
        
        [MenuItem(COLOR_INDIGO, false, PREFAB_PRIORITY)]
        public static void IconIndigo()
        {
            ColorizeIcon(HierarchyColorName.Indigo);
        }
        
        [MenuItem(COLOR_VIOLET, false, PREFAB_PRIORITY)]
        public static void IconViolet()
        {
            ColorizeIcon(HierarchyColorName.Violet);
        }
        
        [MenuItem(COLOR_PURPLE, false, PREFAB_PRIORITY)]
        public static void IconPurple()
        {
            ColorizeIcon(HierarchyColorName.Purple);
        }
        
        [MenuItem(COLOR_MAGENTA, false, PREFAB_PRIORITY)]
        public static void IconMagenta()
        {
            ColorizeIcon(HierarchyColorName.Magenta);
        }
        
        [MenuItem(COLOR_FUCHSIA, false, PREFAB_PRIORITY)]
        public static void IconFuchsia()
        {
            ColorizeIcon(HierarchyColorName.Fuchsia);
        }
        
        [MenuItem(COLOR_ROSE, false, PREFAB_PRIORITY)]
        public static void IconRose()
        {
            ColorizeIcon(HierarchyColorName.Rose);
        }
        
        [MenuItem(COLOR_CRIMSON, false, PREFAB_PRIORITY)]
        public static void IconCrimson()
        {
            ColorizeIcon(HierarchyColorName.Crimson);
        }
        
        // Components
        
        // General
        
        [MenuItem(COMPONENT_GAME_OBJECT, false, PREFAB_PRIORITY)]
        public static void ComponentGameObject()
        {
            AssignComponent(ComponentType.GameObject);
        }
        
        [MenuItem(COMPONENT_TRANSFORM, false, PREFAB_PRIORITY)]
        public static void ComponentTransform()
        {
            AssignComponent(ComponentType.Transform);
        }
        
        [MenuItem(COMPONENT_DEFAULT_ASSET, false, PREFAB_PRIORITY)]
        public static void ComponentDefaultAsset()
        {
            AssignComponent(ComponentType.DefaultAsset);
        }
        
        [MenuItem(COMPONENT_TEXT_ASSET, false, PREFAB_PRIORITY)]
        public static void ComponentTextAsset()
        {
            AssignComponent(ComponentType.TextAsset);
        }
        
        [MenuItem(COMPONENT_CS_SCRIPT, false, PREFAB_PRIORITY)]
        public static void ComponentCsScript()
        {
            AssignComponent(ComponentType.CsScript);
        }
        
        [MenuItem(COMPONENT_JS_SCRIPT, false, PREFAB_PRIORITY)]
        public static void ComponentJsScript()
        {
            AssignComponent(ComponentType.JsScript);
        }
        
        [MenuItem(COMPONENT_SHADER, false, PREFAB_PRIORITY)]
        public static void ComponentShader()
        {
            AssignComponent(ComponentType.Shader);
        }
        
        [MenuItem(COMPONENT_PREFAB, false, PREFAB_PRIORITY)]
        public static void ComponentPrefab()
        {
            AssignComponent(ComponentType.Prefab);
        }
        
        [MenuItem(COMPONENT_SCRIPTABLE_OBJECT, false, PREFAB_PRIORITY)]
        public static void ComponentScriptableObject()
        {
            AssignComponent(ComponentType.ScriptableObject);
        }
        
        [MenuItem(COMPONENT_SCENE_ASSET, false, PREFAB_PRIORITY)]
        public static void ComponentSceneAsset()
        {
            AssignComponent(ComponentType.SceneAsset);
        }
        
        // Meshes
        
        [MenuItem(COMPONENT_MESH_FILTER, false, PREFAB_PRIORITY)]
        public static void ComponentMeshFilter()
        {
            AssignComponent(ComponentType.MeshFilter);
        }
        
        [MenuItem(COMPONENT_TEXT_MESH, false, PREFAB_PRIORITY)]
        public static void ComponentTextMesh()
        {
            AssignComponent(ComponentType.TextMesh);
        }
        
        [MenuItem(COMPONENT_MESH_RENDERER, false, PREFAB_PRIORITY)]
        public static void ComponentMeshRenderer()
        {
            AssignComponent(ComponentType.MeshRenderer);
        }
        
        [MenuItem(COMPONENT_SKIN_MESH_RENDERER, false, PREFAB_PRIORITY)]
        public static void ComponentSkinnedMeshRenderer()
        {
            AssignComponent(ComponentType.SkinnedMeshRenderer);
        }
        
        // Effects
        
        [MenuItem(COMPONENT_PARTICLE_SYSTEM, false, PREFAB_PRIORITY)]
        public static void ComponentParticleSystem()
        {
            AssignComponent(ComponentType.ParticleSystem);
        }
        
        [MenuItem(COMPONENT_TRAIL_RENDERER, false, PREFAB_PRIORITY)]
        public static void ComponentTrailRenderer()
        {
            AssignComponent(ComponentType.TrailRenderer);
        }
        
        [MenuItem(COMPONENT_LINE_RENDERER, false, PREFAB_PRIORITY)]
        public static void ComponentLineRenderer()
        {
            AssignComponent(ComponentType.LineRenderer);
        }
        
        [MenuItem(COMPONENT_LENS_FLARE, false, PREFAB_PRIORITY)]
        public static void ComponentLensFlare()
        {
            AssignComponent(ComponentType.LensFlare);
        }
        
        [MenuItem(COMPONENT_PROJECTOR, false, PREFAB_PRIORITY)]
        public static void ComponentProjector()
        {
            AssignComponent(ComponentType.Projector);
        }
        
        // Phisics
        
        [MenuItem(COMPONENT_RIGIDBODY, false, PREFAB_PRIORITY)]
        public static void ComponentRigidbody()
        {
            AssignComponent(ComponentType.Rigidbody);
        }
        
        [MenuItem(COMPONENT_CHARACTER_CONTROLLER, false, PREFAB_PRIORITY)]
        public static void ComponentCharacterController()
        {
            AssignComponent(ComponentType.CharacterController);
        }
        
        [MenuItem(COMPONENT_BOX_COLLIDER, false, PREFAB_PRIORITY)]
        public static void ComponentBoxCollider()
        {
            AssignComponent(ComponentType.BoxCollider);
        }
        
        [MenuItem(COMPONENT_SPHERE_COLLIDER, false, PREFAB_PRIORITY)]
        public static void ComponentSphereCollider()
        {
            AssignComponent(ComponentType.SphereCollider);
        }
        
        [MenuItem(COMPONENT_CAPSULE_COLLIDER, false, PREFAB_PRIORITY)]
        public static void ComponentCapsuleCollider()
        {
            AssignComponent(ComponentType.CapsuleCollider);
        }
        
        [MenuItem(COMPONENT_MESH_COLLIDER, false, PREFAB_PRIORITY)]
        public static void ComponentMeshCollider()
        {
            AssignComponent(ComponentType.MeshCollider);
        }
        
        [MenuItem(COMPONENT_WHEEL_COLLIDER, false, PREFAB_PRIORITY)]
        public static void ComponentWheelCollider()
        {
            AssignComponent(ComponentType.WheelCollider);
        }
        
        [MenuItem(COMPONENT_TERRAIN_COLLIDER, false, PREFAB_PRIORITY)]
        public static void ComponentTerrainCollider()
        {
            AssignComponent(ComponentType.TerrainCollider);
        }
        
        [MenuItem(COMPONENT_CLOTH, false, PREFAB_PRIORITY)]
        public static void ComponentCloth()
        {
            AssignComponent(ComponentType.Cloth);
        }
        
        [MenuItem(COMPONENT_HINGE_JOINT, false, PREFAB_PRIORITY)]
        public static void ComponentHingeJoint()
        {
            AssignComponent(ComponentType.HingeJoint);
        }
        
        [MenuItem(COMPONENT_FIXED_JOINT, false, PREFAB_PRIORITY)]
        public static void ComponentFixedJoint()
        {
            AssignComponent(ComponentType.FixedJoint);
        }
        
        [MenuItem(COMPONENT_SPRING_JOINT, false, PREFAB_PRIORITY)]
        public static void ComponentSpringJoint()
        {
            AssignComponent(ComponentType.SpringJoint);
        }
        
        [MenuItem(COMPONENT_CHARACTER_JOINT, false, PREFAB_PRIORITY)]
        public static void ComponentCharacterJoint()
        {
            AssignComponent(ComponentType.CharacterJoint);
        }
        
        [MenuItem(COMPONENT_CONFIGURABLE_JOINT, false, PREFAB_PRIORITY)]
        public static void ComponentConfigurableJoint()
        {
            AssignComponent(ComponentType.ConfigurableJoint);
        }
        
        [MenuItem(COMPONENT_CONSTANT_FORCE, false, PREFAB_PRIORITY)]
        public static void ComponentConstantForce()
        {
            AssignComponent(ComponentType.ConstantForce);
        }
        
        // Phisics 2D
        
        [MenuItem(COMPONENT_RIGIDBODY_2D, false, PREFAB_PRIORITY)]
        public static void ComponentRigidbody2D()
        {
            AssignComponent(ComponentType.Rigidbody2D);
        }
        
        [MenuItem(COMPONENT_BOXCOLLIDER_2D, false, PREFAB_PRIORITY)]
        public static void ComponentBoxCollider2D()
        {
            AssignComponent(ComponentType.BoxCollider2D);
        }
        
        [MenuItem(COMPONENT_CIRCLE_COLLIDER_2D, false, PREFAB_PRIORITY)]
        public static void ComponentCircleCollider2D()
        {
            AssignComponent(ComponentType.CircleCollider2D);
        }
        
        [MenuItem(COMPONENT_EDGE_COLLIDER_2D, false, PREFAB_PRIORITY)]
        public static void ComponentEdgeCollider2D()
        {
            AssignComponent(ComponentType.EdgeCollider2D);
        }
        
        [MenuItem(COMPONENT_POLYGON_COLLIDER_2D, false, PREFAB_PRIORITY)]
        public static void ComponentPolygonCollider2D()
        {
            AssignComponent(ComponentType.PolygonCollider2D);
        }
        
        [MenuItem(COMPONENT_CAPSULE_COLLIDER_2D, false, PREFAB_PRIORITY)]
        public static void ComponentCapsuleCollider2D()
        {
            AssignComponent(ComponentType.CapsuleCollider2D);
        }
        
        [MenuItem(COMPONENT_COMPOSITE_COLLIDER_2D, false, PREFAB_PRIORITY)]
        public static void ComponentCompositeCollider2D()
        {
            AssignComponent(ComponentType.CompositeCollider2D);
        }
        
        [MenuItem(COMPONENT_DISTANCE_JOINT_2D, false, PREFAB_PRIORITY)]
        public static void ComponentDistanceJoint2D()
        {
            AssignComponent(ComponentType.DistanceJoint2D);
        }
        
        [MenuItem(COMPONENT_FIXED_JOINT_2D, false, PREFAB_PRIORITY)]
        public static void ComponentFixedJoint2D()
        {
            AssignComponent(ComponentType.FixedJoint2D);
        }
        
        [MenuItem(COMPONENT_FRICTION_JOINT_2D, false, PREFAB_PRIORITY)]
        public static void ComponentFrictionJoint2D()
        {
            AssignComponent(ComponentType.FrictionJoint2D);
        }
        
        [MenuItem(COMPONENT_HINGE_JOINT_2D, false, PREFAB_PRIORITY)]
        public static void ComponentHingeJoint2D()
        {
            AssignComponent(ComponentType.HingeJoint2D);
        }
        
        [MenuItem(COMPONENT_RELATIVE_JOINT_2D, false, PREFAB_PRIORITY)]
        public static void ComponentRelativeJoint2D()
        {
            AssignComponent(ComponentType.RelativeJoint2D);
        }
        
        [MenuItem(COMPONENT_SLIDER_JOINT_2D, false, PREFAB_PRIORITY)]
        public static void ComponentSliderJoint2D()
        {
            AssignComponent(ComponentType.SliderJoint2D);
        }
        
        [MenuItem(COMPONENT_SPRING_JOINT_2D, false, PREFAB_PRIORITY)]
        public static void ComponentSpringJoint2D()
        {
            AssignComponent(ComponentType.SpringJoint2D);
        }
        
        [MenuItem(COMPONENT_TARGET_JOINT_2D, false, PREFAB_PRIORITY)]
        public static void ComponentTargetJoint2D()
        {
            AssignComponent(ComponentType.TargetJoint2D);
        }
        
        [MenuItem(COMPONENT_WHEEL_JOINT_2D, false, PREFAB_PRIORITY)]
        public static void ComponentWheelJoint2D()
        {
            AssignComponent(ComponentType.WheelJoint2D);
        }
        
        [MenuItem(COMPONENT_AREA_EFFECTOR_2D, false, PREFAB_PRIORITY)]
        public static void ComponentAreaEffector2D()
        {
            AssignComponent(ComponentType.AreaEffector2D);
        }
        
        [MenuItem(COMPONENT_BUOYANCY_EFFECTOR_2D, false, PREFAB_PRIORITY)]
        public static void ComponentBuoyancyEffector2D()
        {
            AssignComponent(ComponentType.BuoyancyEffector2D);
        }
        
        [MenuItem(COMPONENT_POINT_EFFECTOR_2D, false, PREFAB_PRIORITY)]
        public static void ComponentPointEffector2D()
        {
            AssignComponent(ComponentType.PointEffector2D);
        }
        
        [MenuItem(COMPONENT_PLATFORM_EFFECTOR_2D, false, PREFAB_PRIORITY)]
        public static void ComponentPlatformEffector2D()
        {
            AssignComponent(ComponentType.PlatformEffector2D);
        }
        
        [MenuItem(COMPONENT_SURFACE_EFFECTOR_2D, false, PREFAB_PRIORITY)]
        public static void ComponentSurfaceEffector2D()
        {
            AssignComponent(ComponentType.SurfaceEffector2D);
        }
        
        [MenuItem(COMPONENT_CONSTANT_FORCE_2D, false, PREFAB_PRIORITY)]
        public static void ComponentConstantForce2D()
        {
            AssignComponent(ComponentType.ConstantForce2D);
        }
        
        // Navigation
        
        [MenuItem(COMPONENT_NAV_MESH_AGENT, false, PREFAB_PRIORITY)]
        public static void ComponentNavMeshAgent()
        {
            AssignComponent(ComponentType.NavMeshAgent);
        }
        
        [MenuItem(COMPONENT_OFF_MESH_LINK, false, PREFAB_PRIORITY)]
        public static void ComponentOffMeshLink()
        {
            AssignComponent(ComponentType.OffMeshLink);
        }
        
        [MenuItem(COMPONENT_NAV_MESH_OBSTACLE, false, PREFAB_PRIORITY)]
        public static void ComponentNavMeshObstacle()
        {
            AssignComponent(ComponentType.NavMeshObstacle);
        }
        
        // Audio
        
        [MenuItem(COMPONENT_AUDIO_LISTENER, false, PREFAB_PRIORITY)]
        public static void ComponentAudioListener()
        {
            AssignComponent(ComponentType.AudioListener);
        }
        
        [MenuItem(COMPONENT_AUDIO_SOURCE, false, PREFAB_PRIORITY)]
        public static void ComponentAudioSource()
        {
            AssignComponent(ComponentType.AudioSource);
        }
        
        [MenuItem(COMPONENT_AUDIO_REVERB_ZONE, false, PREFAB_PRIORITY)]
        public static void ComponentAudioReverbZone()
        {
            AssignComponent(ComponentType.AudioReverbZone);
        }
        
        [MenuItem(COMPONENT_AUDIO_LOW_PASS_FILTER, false, PREFAB_PRIORITY)]
        public static void ComponentAudioLowPassFilter()
        {
            AssignComponent(ComponentType.AudioLowPassFilter);
        }
        
        [MenuItem(COMPONENT_AUDIO_HIGH_PASS_FILTER, false, PREFAB_PRIORITY)]
        public static void ComponentAudioHighPassFilter()
        {
            AssignComponent(ComponentType.AudioHighPassFilter);
        }
        
        [MenuItem(COMPONENT_AUDIO_ECHO_FILTER, false, PREFAB_PRIORITY)]
        public static void ComponentAudioEchoFilter()
        {
            AssignComponent(ComponentType.AudioEchoFilter);
        }
        
        [MenuItem(COMPONENT_AUDIO_DISTORTION_FILTER, false, PREFAB_PRIORITY)]
        public static void ComponentAudioDistortionFilter()
        {
            AssignComponent(ComponentType.AudioDistortionFilter);
        }
        
        [MenuItem(COMPONENT_AUDIO_REVERB_FILTER, false, PREFAB_PRIORITY)]
        public static void ComponentAudioReverbFilter()
        {
            AssignComponent(ComponentType.AudioReverbFilter);
        }
        
        [MenuItem(COMPONENT_AUDIO_CHORUS_FILTER, false, PREFAB_PRIORITY)]
        public static void ComponentAudioChorusFilter()
        {
            AssignComponent(ComponentType.AudioChorusFilter);
        }
        
        // Video

        [MenuItem(COMPONENT_VIDEO_PLAYER, false, PREFAB_PRIORITY)]
        public static void ComponentVideoPlayer()
        {
            AssignComponent(ComponentType.VideoPlayer);
        }
        
        // Rendering

        [MenuItem(COMPONENT_CAMERA, false, PREFAB_PRIORITY)]
        public static void ComponentCamera()
        {
            AssignComponent(ComponentType.Camera);
        }
        
        [MenuItem(COMPONENT_SKYBOX, false, PREFAB_PRIORITY)]
        public static void ComponentSkybox()
        {
            AssignComponent(ComponentType.Skybox);
        }
        
        [MenuItem(COMPONENT_FLARE_LAYER, false, PREFAB_PRIORITY)]
        public static void ComponentFlareLayer()
        {
            AssignComponent(ComponentType.FlareLayer);
        }
        
        [MenuItem(COMPONENT_LIGHT, false, PREFAB_PRIORITY)]
        public static void ComponentLight()
        {
            AssignComponent(ComponentType.Light);
        }
        
        [MenuItem(COMPONENT_LIGHT_PROBE_GROUP, false, PREFAB_PRIORITY)]
        public static void ComponentLightProbeGroup()
        {
            AssignComponent(ComponentType.LightProbeGroup);
        }
        
        [MenuItem(COMPONENT_LIGHT_PROBE_PROXY_VOLUME, false, PREFAB_PRIORITY)]
        public static void ComponentLightProbeProxyVolume()
        {
            AssignComponent(ComponentType.LightProbeProxyVolume);
        }
        
        [MenuItem(COMPONENT_REFLECTION_PROBE, false, PREFAB_PRIORITY)]
        public static void ComponentReflectionProbe()
        {
            AssignComponent(ComponentType.ReflectionProbe);
        }
        
        [MenuItem(COMPONENT_OCCLUSION_AREA, false, PREFAB_PRIORITY)]
        public static void ComponentOcclusionArea()
        {
            AssignComponent(ComponentType.OcclusionArea);
        }
        
        [MenuItem(COMPONENT_OCCLUSION_PORTAL, false, PREFAB_PRIORITY)]
        public static void ComponentOcclusionPortal()
        {
            AssignComponent(ComponentType.OcclusionPortal);
        }
        
        [MenuItem(COMPONENT_LOD_GROUP, false, PREFAB_PRIORITY)]
        public static void ComponentLodGroup()
        {
            AssignComponent(ComponentType.LodGroup);
        }
        
        [MenuItem(COMPONENT_SPRITE_RENDERER, false, PREFAB_PRIORITY)]
        public static void ComponentSpriteRenderer()
        {
            AssignComponent(ComponentType.SpriteRenderer);
        }
        
        [MenuItem(COMPONENT_SORTING_GROUP, false, PREFAB_PRIORITY)]
        public static void ComponentSortingGroup()
        {
            AssignComponent(ComponentType.SortingGroup);
        }
        
        
        [MenuItem(COMPONENT_CANVAS_RENDERER, false, PREFAB_PRIORITY)]
        public static void ComponentCanvasRenderer()
        {
            AssignComponent(ComponentType.CanvasRenderer);
        }
        
        // Tilemap

        #if UNITY_2017_2_OR_NEWER
        [MenuItem(COMPONENT_TILEMAP, false, PREFAB_PRIORITY)]
        public static void ComponentTilemap()
        {
            AssignComponent(ComponentType.Tilemap);
        }
        
        [MenuItem(COMPONENT_TILEMAP_RENDERER, false, PREFAB_PRIORITY)]
        public static void ComponentTilemapRenderer()
        {
            AssignComponent(ComponentType.TilemapRenderer);
        }
        
        [MenuItem(COMPONENT_TILEMAP_COLLIDER_2D, false, PREFAB_PRIORITY)]
        public static void ComponentTilemapCollider2D()
        {
            AssignComponent(ComponentType.TilemapCollider2D);
        }
        #endif
        
        // Layout

        [MenuItem(COMPONENT_RECT_TRANSFORM, false, PREFAB_PRIORITY)]
        public static void ComponentRectTransform()
        {
            AssignComponent(ComponentType.RectTransform);
        }
        
        [MenuItem(COMPONENT_CANVAS, false, PREFAB_PRIORITY)]
        public static void ComponentCanvas()
        {
            AssignComponent(ComponentType.Canvas);
        }
        
        [MenuItem(COMPONENT_CANVAS_GROUP, false, PREFAB_PRIORITY)]
        public static void ComponentCanvasGroup()
        {
            AssignComponent(ComponentType.CanvasGroup);
        }
        
        [MenuItem(COMPONENT_CANVAS_SCALER, false, PREFAB_PRIORITY)]
        public static void ComponentCanvasScaler()
        {
            AssignComponent(ComponentType.CanvasScaler);
        }
        
        [MenuItem(COMPONENT_LAYOUT_ELEMENT, false, PREFAB_PRIORITY)]
        public static void ComponentLayoutElement()
        {
            AssignComponent(ComponentType.LayoutElement);
        }
        
        [MenuItem(COMPONENT_CONTENT_SIZE_FITTER, false, PREFAB_PRIORITY)]
        public static void ComponentContentSizeFitter()
        {
            AssignComponent(ComponentType.ContentSizeFitter);
        }
        
        [MenuItem(COMPONENT_ASPECT_RATIO_FITTER, false, PREFAB_PRIORITY)]
        public static void ComponentAspectRatioFitter()
        {
            AssignComponent(ComponentType.AspectRatioFitter);
        }
        
        [MenuItem(COMPONENT_HORIZONTAL_LAYOUT_GROUP, false, PREFAB_PRIORITY)]
        public static void ComponentHorizontalLayoutGroup()
        {
            AssignComponent(ComponentType.HorizontalLayoutGroup);
        }
        
        [MenuItem(COMPONENT_VERTICAL_LAYOUT_GROUP, false, PREFAB_PRIORITY)]
        public static void ComponentVerticalLayoutGroup()
        {
            AssignComponent(ComponentType.VerticalLayoutGroup);
        }
        
        [MenuItem(COMPONENT_GRID_LAYOUT_GROUP, false, PREFAB_PRIORITY)]
        public static void ComponentGridLayoutGroup()
        {
            AssignComponent(ComponentType.GridLayoutGroup);
        }
        
        // Playable

        [MenuItem(COMPONENT_PLAYABLE_DIRECTOR, false, PREFAB_PRIORITY)]
        public static void ComponentPlayableDirector()
        {
            AssignComponent(ComponentType.PlayableDirector);
        }
        
        // AR

        #if UNITY_2017_2_OR_NEWER
        [MenuItem(COMPONENT_WORLD_ANCHOR, false, PREFAB_PRIORITY)]
        public static void ComponentWorldAnchor()
        {
            AssignComponent(ComponentType.WorldAnchor);
        }
        #endif
                
        // Miscellaneous

        [MenuItem(COMPONENT_BILLBOARD_RENDERER, false, PREFAB_PRIORITY)]
        public static void ComponentBillboardRenderer()
        {
            AssignComponent(ComponentType.BillboardRenderer);
        }
        
        [MenuItem(COMPONENT_TERRAIN, false, PREFAB_PRIORITY)]
        public static void ComponentTerrain()
        {
            AssignComponent(ComponentType.Terrain);
        }
        
        [MenuItem(COMPONENT_ANIMATOR, false, PREFAB_PRIORITY)]
        public static void ComponentAnimator()
        {
            AssignComponent(ComponentType.Animator);
        }
        
        [MenuItem(COMPONENT_ANIMATION, false, PREFAB_PRIORITY)]
        public static void ComponentAnimation()
        {
            AssignComponent(ComponentType.Animation);
        }
        
        #if UNITY_2017_2_OR_NEWER
        [MenuItem(COMPONENT_GRID, false, PREFAB_PRIORITY)]
        public static void ComponentGrid()
        {
            AssignComponent(ComponentType.Grid);
        }
        #endif
        
        [MenuItem(COMPONENT_WINDZONE, false, PREFAB_PRIORITY)]
        public static void ComponentWindZone()
        {
            AssignComponent(ComponentType.WindZone);
        }
        
        [MenuItem(COMPONENT_SPRITE_MASK, false, PREFAB_PRIORITY)]
        public static void ComponentSpriteMask()
        {
            AssignComponent(ComponentType.SpriteMask);
        }
        
        // Event

        [MenuItem(COMPONENT_EVENT_SYSTEM, false, PREFAB_PRIORITY)]
        public static void ComponentEventSystem()
        {
            AssignComponent(ComponentType.EventSystem);
        }
        
        [MenuItem(COMPONENT_HOLOLENS_INPUT_MODULE, false, PREFAB_PRIORITY)]
        public static void ComponentHoloLensInputModule()
        {
            AssignComponent(ComponentType.HoloLensInputModule);
        }
        
        [MenuItem(COMPONENT_EVENT_TRIGGER, false, PREFAB_PRIORITY)]
        public static void ComponentEventTrigger()
        {
            AssignComponent(ComponentType.EventTrigger);
        }
        
        [MenuItem(COMPONENT_PHYSICS_2D_RAYCASTER, false, PREFAB_PRIORITY)]
        public static void ComponentPhysics2DRaycaster()
        {
            AssignComponent(ComponentType.Physics2DRaycaster);
        }
        
        [MenuItem(COMPONENT_PHYSICS_RAYCASTER, false, PREFAB_PRIORITY)]
        public static void ComponentPhysicsRaycaster()
        {
            AssignComponent(ComponentType.PhysicsRaycaster);
        }
        
        [MenuItem(COMPONENT_STANDALONE_INPUT_MODULE, false, PREFAB_PRIORITY)]
        public static void ComponentStandaloneInputModule()
        {
            AssignComponent(ComponentType.StandaloneInputModule);
        }
        
        [MenuItem(COMPONENT_GRAPHIC_RAYCASTER, false, PREFAB_PRIORITY)]
        public static void ComponentGraphicRaycaster()
        {
            AssignComponent(ComponentType.GraphicRaycaster);
        }
        
        // Network

        [MenuItem(COMPONENT_NETWORK_ANIMATOR, false, PREFAB_PRIORITY)]
        public static void ComponentNetworkAnimator()
        {
            AssignComponent(ComponentType.NetworkAnimator);
        }
        
        [MenuItem(COMPONENT_NETWORK_DISCOVERY, false, PREFAB_PRIORITY)]
        public static void ComponentNetworkDiscovery()
        {
            AssignComponent(ComponentType.NetworkDiscovery);
        }
        
        [MenuItem(COMPONENT_NETWORK_IDENTITY, false, PREFAB_PRIORITY)]
        public static void ComponentNetworkIdentity()
        {
            AssignComponent(ComponentType.NetworkIdentity);
        }
        
        [MenuItem(COMPONENT_NETWORK_LOBBY_MANAGER, false, PREFAB_PRIORITY)]
        public static void ComponentNetworkLobbyManager()
        {
            AssignComponent(ComponentType.NetworkLobbyManager);
        }
        
        [MenuItem(COMPONENT_NETWORK_MANAGER, false, PREFAB_PRIORITY)]
        public static void ComponentNetworkManager()
        {
            AssignComponent(ComponentType.NetworkManager);
        }
        
        [MenuItem(COMPONENT_NETWORK_MANAGER_HUD, false, PREFAB_PRIORITY)]
        public static void ComponentNetworkManagerHud()
        {
            AssignComponent(ComponentType.NetworkManagerHud);
        }
        
        [MenuItem(COMPONENT_NETWORK_MIGRATION_MANAGER, false, PREFAB_PRIORITY)]
        public static void ComponentNetworkMigrationManager()
        {
            AssignComponent(ComponentType.NetworkMigrationManager);
        }
        
        [MenuItem(COMPONENT_NETWORK_PROXIMITY_CHECKER, false, PREFAB_PRIORITY)]
        public static void ComponentNetworkProximityChecker()
        {
            AssignComponent(ComponentType.NetworkProximityChecker);
        }
        
        [MenuItem(COMPONENT_NETWORK_START_POSITION, false, PREFAB_PRIORITY)]
        public static void ComponentNetworkStartPosition()
        {
            AssignComponent(ComponentType.NetworkStartPosition);
        }
        
        [MenuItem(COMPONENT_NETWORK_TRANSFORM, false, PREFAB_PRIORITY)]
        public static void ComponentNetworkTransform()
        {
            AssignComponent(ComponentType.NetworkTransform);
        }
        
        [MenuItem(COMPONENT_NETWORK_TRANSFORM_CHILD, false, PREFAB_PRIORITY)]
        public static void ComponentNetworkTransformChild()
        {
            AssignComponent(ComponentType.NetworkTransformChild);
        }
        
        [MenuItem(COMPONENT_NETWORK_TRANSFORM_VISUALIZER, false, PREFAB_PRIORITY)]
        public static void ComponentNetworkTransformVisualizer()
        {
            AssignComponent(ComponentType.NetworkTransformVisualizer);
        }
        
        // XR

        #if UNITY_2017_2_OR_NEWER
        [MenuItem(COMPONENT_SPATIAL_MAPPING_COLLIDER, false, PREFAB_PRIORITY)]
        public static void ComponentSpatialMappingCollider()
        {
            AssignComponent(ComponentType.SpatialMappingCollider);
        }
        
        [MenuItem(COMPONENT_SPATIAL_MAPPING_RENDERER, false, PREFAB_PRIORITY)]
        public static void ComponentSpatialMappingRenderer()
        {
            AssignComponent(ComponentType.SpatialMappingRenderer);
        }
        #endif
        
        // UI

        [MenuItem(COMPONENT_TEXT, false, PREFAB_PRIORITY)]
        public static void ComponentText()
        {
            AssignComponent(ComponentType.Text);
        }
        
        [MenuItem(COMPONENT_IMAGE, false, PREFAB_PRIORITY)]
        public static void ComponentImage()
        {
            AssignComponent(ComponentType.Image);
        }
        
        [MenuItem(COMPONENT_RAW_IMAGE, false, PREFAB_PRIORITY)]
        public static void ComponentRawImage()
        {
            AssignComponent(ComponentType.RawImage);
        }
        
        [MenuItem(COMPONENT_MASK, false, PREFAB_PRIORITY)]
        public static void ComponentMask()
        {
            AssignComponent(ComponentType.Mask);
        }
        
        [MenuItem(COMPONENT_BUTTON, false, PREFAB_PRIORITY)]
        public static void ComponentButton()
        {
            AssignComponent(ComponentType.Button);
        }
        
        [MenuItem(COMPONENT_INPUT_FIELD, false, PREFAB_PRIORITY)]
        public static void ComponentInputField()
        {
            AssignComponent(ComponentType.InputField);
        }
        
        [MenuItem(COMPONENT_TOGGLE, false, PREFAB_PRIORITY)]
        public static void ComponentToggle()
        {
            AssignComponent(ComponentType.Toggle);
        }
        
        [MenuItem(COMPONENT_TOGGLE_GROUP, false, PREFAB_PRIORITY)]
        public static void ComponentToggleGroup()
        {
            AssignComponent(ComponentType.ToggleGroup);
        }
        
        [MenuItem(COMPONENT_SLIDER, false, PREFAB_PRIORITY)]
        public static void ComponentSlider()
        {
            AssignComponent(ComponentType.Slider);
        }
        
        [MenuItem(COMPONENT_SCROLLBAR, false, PREFAB_PRIORITY)]
        public static void ComponentScrollbar()
        {
            AssignComponent(ComponentType.Scrollbar);
        }
        
        [MenuItem(COMPONENT_DROPDOWN, false, PREFAB_PRIORITY)]
        public static void ComponentDropdown()
        {
            AssignComponent(ComponentType.Dropdown);
        }
        
        [MenuItem(COMPONENT_SCROLL_RECT, false, PREFAB_PRIORITY)]
        public static void ComponentScrollRect()
        {
            AssignComponent(ComponentType.ScrollRect);
        }
        
        [MenuItem(COMPONENT_SELECTABLE, false, PREFAB_PRIORITY)]
        public static void ComponentSelectable()
        {
            AssignComponent(ComponentType.Selectable);
        }
        
        // Backgrounds

        [MenuItem(BACKGROUND_RED, false, PREFAB_PRIORITY)]
        public static void BackgroundRed()
        {
            ColorizeBackground(HierarchyColorName.Red);
        }

        [MenuItem(BACKGROUND_VERMILION, false, PREFAB_PRIORITY)]
        public static void BackgroundVermilion()
        {
            ColorizeBackground(HierarchyColorName.Vermilion);
        }
        
        [MenuItem(BACKGROUND_ORANGE, false, PREFAB_PRIORITY)]
        public static void BackgroundOrange()
        {
            ColorizeBackground(HierarchyColorName.Orange);
        }
        
        [MenuItem(BACKGROUND_AMBER, false, PREFAB_PRIORITY)]
        public static void BackgroundAmber()
        {
            ColorizeBackground(HierarchyColorName.Amber);
        }
        
        [MenuItem(BACKGROUND_YELLOW, false, PREFAB_PRIORITY)]
        public static void BackgroundYellow()
        {
            ColorizeBackground(HierarchyColorName.Yellow);
        }
        
        [MenuItem(BACKGROUND_LIME, false, PREFAB_PRIORITY)]
        public static void BackgroundLime()
        {
            ColorizeBackground(HierarchyColorName.Lime);
        }
        
        [MenuItem(BACKGROUND_CHARTREUSE, false, PREFAB_PRIORITY)]
        public static void BackgroundChartreuse()
        {
            ColorizeBackground(HierarchyColorName.Chartreuse);
        }
        
        [MenuItem(BACKGROUND_HARLEQUIN, false, PREFAB_PRIORITY)]
        public static void BackgroundHarlequin()
        {
            ColorizeBackground(HierarchyColorName.Harlequin);
        }
        
        [MenuItem(BACKGROUND_GREEN, false, PREFAB_PRIORITY)]
        public static void BackgroundGreen()
        {
            ColorizeBackground(HierarchyColorName.Green);
        }
        
        [MenuItem(BACKGROUND_EMERALD, false, PREFAB_PRIORITY)]
        public static void BackgroundEmerald()
        {
            ColorizeBackground(HierarchyColorName.Emerald);
        }
        
        [MenuItem(BACKGROUND_SPRING_GREEN, false, PREFAB_PRIORITY)]
        public static void BackgroundSpringGreen()
        {
            ColorizeBackground(HierarchyColorName.SpringGreen);
        }
        
        [MenuItem(BACKGROUND_AQUAMARINE, false, PREFAB_PRIORITY)]
        public static void BackgroundAquamarine()
        {
            ColorizeBackground(HierarchyColorName.Aquamarine);
        }
        
        [MenuItem(BACKGROUND_CYAN, false, PREFAB_PRIORITY)]
        public static void BackgroundCyan()
        {
            ColorizeBackground(HierarchyColorName.Cyan);
        }
        
        [MenuItem(BACKGROUND_SKY_BLUE, false, PREFAB_PRIORITY)]
        public static void BackgroundSkyBlue()
        {
            ColorizeBackground(HierarchyColorName.SkyBlue);
        }
        
        [MenuItem(BACKGROUND_AZURE, false, PREFAB_PRIORITY)]
        public static void BackgroundAzure()
        {
            ColorizeBackground(HierarchyColorName.Azure);
        }
        
        [MenuItem(BACKGROUND_CERULEAN, false, PREFAB_PRIORITY)]
        public static void BackgroundCerulean()
        {
            ColorizeBackground(HierarchyColorName.Cerulean);
        }
        
        [MenuItem(BACKGROUND_BLUE, false, PREFAB_PRIORITY)]
        public static void BackgroundBlue()
        {
            ColorizeBackground(HierarchyColorName.Blue);
        }
        
        [MenuItem(BACKGROUND_INDIGO, false, PREFAB_PRIORITY)]
        public static void BackgroundIndigo()
        {
            ColorizeBackground(HierarchyColorName.Indigo);
        }
        
        [MenuItem(BACKGROUND_VIOLET, false, PREFAB_PRIORITY)]
        public static void BackgroundViolet()
        {
            ColorizeBackground(HierarchyColorName.Violet);
        }
        
        [MenuItem(BACKGROUND_PURPLE, false, PREFAB_PRIORITY)]
        public static void BackgroundPurple()
        {
            ColorizeBackground(HierarchyColorName.Purple);
        }
        
        [MenuItem(BACKGROUND_MAGENTA, false, PREFAB_PRIORITY)]
        public static void BackgroundMagenta()
        {
            ColorizeBackground(HierarchyColorName.Magenta);
        }
        
        [MenuItem(BACKGROUND_FUCHSIA, false, PREFAB_PRIORITY)]
        public static void BackgroundFuchsia()
        {
            ColorizeBackground(HierarchyColorName.Fuchsia);
        }
        
        [MenuItem(BACKGROUND_ROSE, false, PREFAB_PRIORITY)]
        public static void BackgroundRose()
        {
            ColorizeBackground(HierarchyColorName.Rose);
        }
        
        [MenuItem(BACKGROUND_CRIMSON, false, PREFAB_PRIORITY)]
        public static void BackgroundCrimson()
        {
            ColorizeBackground(HierarchyColorName.Crimson);
        }
        
        //---------------------------------------------------------------------
        // Helpers
        //---------------------------------------------------------------------
        
        private static void ColorizeIcon(HierarchyColorName color)
        {
            var icon = HierarchyColorsStorage.Instance.GetIconByColor(color);
            ChangeSelectedObjectsTexture(icon);
        }

        private static void AssignComponent(ComponentType name)
        {
            var componentIcon = ComponentIconStorage.GetIconByName(name);
            ChangeSelectedObjectsTexture(componentIcon);
        }
        
        private static void ColorizeBackground(HierarchyColorName color)
        {
            var icon = HierarchyColorsStorage.Instance.GetBackgroundByColor(color);
            ChangeSelectedObjectsTexture(icon, true);
        }

        private static void ChangeSelectedObjectsTexture(Texture2D icon, bool isBackground = false)
        {    
            if (Selection.gameObjects.Length == 0 || !IsLastExecuteDelayPassed()) return;

            var selectionGameObjects = Selection.gameObjects;
            var currentScene = selectionGameObjects[0].scene;
            var sceneConf = RainbowHierarchySceneConf.GetConfByScene(currentScene, true);
            foreach (var gameObject in selectionGameObjects)
            {
                var hierarchyItem = sceneConf.GetItem(gameObject) ?? new HierarchyItem(HierarchyItem.KeyType.Object, gameObject, null);
                Undo.RecordObject(sceneConf, "Scene Config Changes");
                if (isBackground)
                {
                    hierarchyItem.Background = icon;
                }
                else
                {
                    hierarchyItem.Icon = icon;
                    hierarchyItem.IsIconCustom = false;
                }
                sceneConf.UpdateItem(gameObject, hierarchyItem);
            }

            UpdateLastExecuteTicks();
        }
        
        private static void ApplyCustom()
        {
            if (Selection.gameObjects.Length == 0 || !IsLastExecuteDelayPassed()) return;

            var window = RainbowHierarchyPopup.GetDraggableWindow();
            var position = RainbowHierarchyEditorUtility.GetHierarchyWindow().position.position + new Vector2(10f, 30f);
            var gameObjects = Selection.gameObjects.ToList();
            window.ShowWithParams(position, gameObjects, 0);
            
            UpdateLastExecuteTicks();
        }

        private static void RevertToDefault()
        {
            if (Selection.gameObjects.Length == 0 || !IsLastExecuteDelayPassed()) return;

            var selectionGameObjects = Selection.gameObjects;
            var currentScene = selectionGameObjects[0].scene;
            var sceneConf = RainbowHierarchySceneConf.GetConfByScene(currentScene);
            if (sceneConf == null || sceneConf.HierarchyItems.Count == 0) return;
            
            foreach (var gameObject in selectionGameObjects)
            {
                var hierarchyItem = sceneConf.GetItem(gameObject);
                if (hierarchyItem == null) continue;
                Undo.RecordObject(sceneConf, "Scene Config Changes");
                sceneConf.RemoveAll(gameObject, hierarchyItem.Type);
            }
            
            UpdateLastExecuteTicks();
        }

        // Prevent to execute callbacks many times when several gameObjects selected
        private static bool IsLastExecuteDelayPassed()
        {
            if (_lastExecuteTicks == -1)
            {
                _lastExecuteTicks = System.DateTime.Now.Ticks;
                return true;
            }
            var delay = System.DateTime.Now.Ticks - _lastExecuteTicks;
            UpdateLastExecuteTicks();
            return delay > DELAY_TICKS;
        }

        private static void UpdateLastExecuteTicks()
        {
            _lastExecuteTicks = System.DateTime.Now.Ticks;
        }
    }
}