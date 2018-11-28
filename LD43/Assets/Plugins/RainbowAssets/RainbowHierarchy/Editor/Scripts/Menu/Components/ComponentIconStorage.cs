using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using UnityEngine.Playables;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.Video;
using EditorUtility = Borodar.RainbowHierarchy.RainbowHierarchyEditorUtility;

#if UNITY_2017_2_OR_NEWER
using UnityEngine.Tilemaps;
using UnityEngine.XR.WSA;
#endif


namespace Borodar.RainbowHierarchy.Components
{
    public static class ComponentIconStorage
    {
        public static Texture2D GetIconByName(ComponentType name)
        {
            switch (name)
            {
                case ComponentType.GameObject:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(GameObject)).image;
                case ComponentType.Transform:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(Transform)).image;
                case ComponentType.Prefab:
                    return (Texture2D) EditorGUIUtility.IconContent("PrefabNormal Icon").image;
                case ComponentType.SceneAsset:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(SceneAsset)).image;
                case ComponentType.CsScript:
                    return (Texture2D) EditorGUIUtility.IconContent("cs Script Icon").image;
                case ComponentType.JsScript:
                    return (Texture2D) EditorGUIUtility.IconContent("js Script Icon").image;
                case ComponentType.Shader:
                    return (Texture2D) EditorGUIUtility.IconContent("Shader Icon").image;                
                case ComponentType.ScriptableObject:
                    return (Texture2D) EditorGUIUtility.IconContent("ScriptableObject Icon").image;
                case ComponentType.DefaultAsset:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(DefaultAsset)).image;
                case ComponentType.TextAsset:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(TextAsset)).image;
                // Meshes
                case ComponentType.MeshFilter:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(MeshFilter)).image;
                case ComponentType.TextMesh:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(TextMesh)).image;
                case ComponentType.MeshRenderer:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(MeshRenderer)).image;
                case ComponentType.SkinnedMeshRenderer:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(SkinnedMeshRenderer)).image;
                // Effects
                case ComponentType.ParticleSystem:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(ParticleSystem)).image;
                case ComponentType.TrailRenderer:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(TrailRenderer)).image;
                case ComponentType.LineRenderer:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(LineRenderer)).image;
                case ComponentType.LensFlare:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(LensFlare)).image;
                case ComponentType.Projector:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(Projector)).image;
                // Physics
                case ComponentType.Rigidbody:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(Rigidbody)).image;
                case ComponentType.CharacterController:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(CharacterController)).image;
                case ComponentType.BoxCollider:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(BoxCollider)).image;
                case ComponentType.SphereCollider:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(SphereCollider)).image;
                case ComponentType.CapsuleCollider:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(CapsuleCollider)).image;
                case ComponentType.MeshCollider:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(MeshCollider)).image;
                case ComponentType.WheelCollider:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(WheelCollider)).image;
                case ComponentType.TerrainCollider:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(TerrainCollider)).image;
                case ComponentType.Cloth:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(Cloth)).image;
                case ComponentType.HingeJoint:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(HingeJoint)).image;
                case ComponentType.FixedJoint:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(FixedJoint)).image;
                case ComponentType.SpringJoint:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(SpringJoint)).image;
                case ComponentType.CharacterJoint:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(CharacterJoint)).image;
                case ComponentType.ConfigurableJoint:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(ConfigurableJoint)).image;
                case ComponentType.ConstantForce:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(ConstantForce)).image;
                // Physics 2D
                case ComponentType.Rigidbody2D:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(Rigidbody2D)).image;
                case ComponentType.BoxCollider2D:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(BoxCollider2D)).image;
                case ComponentType.CircleCollider2D:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(CircleCollider2D)).image;
                case ComponentType.EdgeCollider2D:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(EdgeCollider2D)).image;
                case ComponentType.PolygonCollider2D:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(PolygonCollider2D)).image;
                case ComponentType.CapsuleCollider2D:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(CapsuleCollider2D)).image;
                case ComponentType.CompositeCollider2D:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(CompositeCollider2D)).image;
                case ComponentType.DistanceJoint2D:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(DistanceJoint2D)).image;
                case ComponentType.FixedJoint2D:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(FixedJoint2D)).image;
                case ComponentType.FrictionJoint2D:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(FrictionJoint2D)).image;
                case ComponentType.HingeJoint2D:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(HingeJoint2D)).image;
                case ComponentType.RelativeJoint2D:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(RelativeJoint2D)).image;
                case ComponentType.SliderJoint2D:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(SliderJoint2D)).image;
                case ComponentType.SpringJoint2D:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(SpringJoint2D)).image;
                case ComponentType.TargetJoint2D:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(TargetJoint2D)).image;
                case ComponentType.WheelJoint2D:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(WheelJoint2D)).image;
                case ComponentType.AreaEffector2D:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(AreaEffector2D)).image;
                case ComponentType.BuoyancyEffector2D:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(BuoyancyEffector2D)).image;
                case ComponentType.PointEffector2D:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(PointEffector2D)).image;
                case ComponentType.PlatformEffector2D:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(PlatformEffector2D)).image;
                case ComponentType.SurfaceEffector2D:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(SurfaceEffector2D)).image;
                case ComponentType.ConstantForce2D:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(ConstantForce2D)).image;
                // Navigation
                case ComponentType.NavMeshAgent:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(NavMeshAgent)).image;
                case ComponentType.OffMeshLink:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(OffMeshLink)).image;
                case ComponentType.NavMeshObstacle:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(NavMeshObstacle)).image;
                // Audio
                case ComponentType.AudioListener:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(AudioListener)).image;
                case ComponentType.AudioSource:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(AudioSource)).image;
                case ComponentType.AudioReverbZone:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(AudioReverbZone)).image;
                case ComponentType.AudioLowPassFilter:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(AudioLowPassFilter)).image;
                case ComponentType.AudioHighPassFilter:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(AudioHighPassFilter)).image;
                case ComponentType.AudioEchoFilter:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(AudioEchoFilter)).image;
                case ComponentType.AudioDistortionFilter:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(AudioDistortionFilter)).image;
                case ComponentType.AudioReverbFilter:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(AudioReverbFilter)).image;
                case ComponentType.AudioChorusFilter:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(AudioChorusFilter)).image;
                // Video
                case ComponentType.VideoPlayer:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(VideoPlayer)).image;
                // Rendering
                case ComponentType.Camera:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(Camera)).image;
                case ComponentType.Skybox:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(Skybox)).image;
                case ComponentType.FlareLayer:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(FlareLayer)).image;
                case ComponentType.Light:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(Light)).image;
                case ComponentType.LightProbeGroup:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(LightProbeGroup)).image;
                case ComponentType.LightProbeProxyVolume:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(LightProbeProxyVolume)).image;
                case ComponentType.ReflectionProbe:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(ReflectionProbe)).image;
                case ComponentType.OcclusionArea:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(OcclusionArea)).image;
                case ComponentType.OcclusionPortal:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(OcclusionPortal)).image;
                case ComponentType.LodGroup:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(LODGroup)).image;
                case ComponentType.SpriteRenderer:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(SpriteRenderer)).image;
                case ComponentType.SortingGroup:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(SortingGroup)).image;
                case ComponentType.CanvasRenderer:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(CanvasRenderer)).image;
                // Tilemap
                #if UNITY_2017_2_OR_NEWER
                case ComponentType.Tilemap:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(Tilemap)).image;
                case ComponentType.TilemapRenderer:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(TilemapRenderer)).image;
                case ComponentType.TilemapCollider2D:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(TilemapCollider2D)).image;
                #endif
                // Layout
                case ComponentType.RectTransform:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(RectTransform)).image;
                case ComponentType.Canvas:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(Canvas)).image;
                case ComponentType.CanvasGroup:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(CanvasGroup)).image;
                case ComponentType.CanvasScaler:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(CanvasScaler)).image;
                case ComponentType.LayoutElement:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(LayoutElement)).image;
                case ComponentType.ContentSizeFitter:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(ContentSizeFitter)).image;
                case ComponentType.AspectRatioFitter:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(AspectRatioFitter)).image;
                case ComponentType.HorizontalLayoutGroup:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(HorizontalLayoutGroup)).image;
                case ComponentType.VerticalLayoutGroup:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(VerticalLayoutGroup)).image;
                case ComponentType.GridLayoutGroup:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(GridLayoutGroup)).image;
                // Playable
                case ComponentType.PlayableDirector:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(PlayableDirector)).image;
                // AR
                #if UNITY_2017_2_OR_NEWER
                case ComponentType.WorldAnchor:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(WorldAnchor)).image;
                #endif
                // Miscellaneous
                case ComponentType.BillboardRenderer:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(BillboardRenderer)).image;
                case ComponentType.Terrain:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(Terrain)).image;
                case ComponentType.Animator:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(Animator)).image;
                case ComponentType.Animation:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(Animation)).image;
                #if UNITY_2017_2_OR_NEWER
                case ComponentType.Grid:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(Grid)).image;
                #endif
                case ComponentType.WindZone:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(WindZone)).image;
                case ComponentType.SpriteMask:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(SpriteMask)).image;
                // Event
                case ComponentType.EventSystem:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(EventSystem)).image;
                //case ComponentType.HoloLensInputModule:
                    //return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(HoloLensInputModule)).image;
                case ComponentType.EventTrigger:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(EventTrigger)).image;
                case ComponentType.Physics2DRaycaster:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(Physics2DRaycaster)).image;
                case ComponentType.PhysicsRaycaster:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(PhysicsRaycaster)).image;
                case ComponentType.StandaloneInputModule:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(StandaloneInputModule)).image;
                case ComponentType.GraphicRaycaster:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(GraphicRaycaster)).image;
                // Network
                case ComponentType.NetworkAnimator:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(NetworkAnimator)).image;
                case ComponentType.NetworkDiscovery:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(NetworkDiscovery)).image;
                case ComponentType.NetworkIdentity:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(NetworkIdentity)).image;
                case ComponentType.NetworkLobbyManager:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(NetworkLobbyManager)).image;
                case ComponentType.NetworkManager:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(NetworkManager)).image;
                case ComponentType.NetworkManagerHud:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(NetworkManagerHUD)).image;
                case ComponentType.NetworkMigrationManager:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(NetworkMigrationManager)).image;
                case ComponentType.NetworkProximityChecker:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(NetworkProximityChecker)).image;
                case ComponentType.NetworkStartPosition:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(NetworkStartPosition)).image;
                case ComponentType.NetworkTransform:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(NetworkTransform)).image;
                case ComponentType.NetworkTransformChild:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(NetworkTransformChild)).image;
                case ComponentType.NetworkTransformVisualizer:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(NetworkTransformVisualizer)).image;
                // XR
                #if UNITY_2017_2_OR_NEWER
                //case ComponentType.SpatialMappingCollider:
                    //return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(SpatialMappingCollider)).image;
                //case ComponentType.SpatialMappingRenderer:
                    //return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(SpatialMappingRenderer)).image;
                #endif
                // UI
                case ComponentType.Text:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(Text)).image;
                case ComponentType.Image:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(Image)).image;
                case ComponentType.RawImage:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(RawImage)).image;
                case ComponentType.Mask:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(Mask)).image;
                case ComponentType.Button:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(Button)).image;
                case ComponentType.InputField:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(InputField)).image;
                case ComponentType.Toggle:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(Toggle)).image;
                case ComponentType.ToggleGroup:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(ToggleGroup)).image;
                case ComponentType.Slider:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(Slider)).image;
                case ComponentType.Scrollbar:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(Scrollbar)).image;
                case ComponentType.Dropdown:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(Dropdown)).image;
                case ComponentType.ScrollRect:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(ScrollRect)).image;
                case ComponentType.Selectable:
                    return (Texture2D) EditorGUIUtility.ObjectContent(null, typeof(Selectable)).image;
                default:
                    throw new ArgumentOutOfRangeException("name", name, null);
            }
        }
    }
}