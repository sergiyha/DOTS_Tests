using Sirenix.OdinInspector;
using Unity.Entities;
using UnityEngine;


public class PlayerComponentProvider : BaseComponentProvider
{
    [FoldoutGroup("CameraSettings")] public float RotationSpeedX_camera;
    [FoldoutGroup("CameraSettings")] public float RotationSpeedY_camera;
    [FoldoutGroup("CameraSettings")] public float ClampMaxAngle_camera;
    [FoldoutGroup("CameraSettings")] public float ClampMinAngle_camera;
    [FoldoutGroup("CameraSettings")] public bool Invert_camera;

    public float MovemenSpeed;

    public CharacterController CharacterController;

    // public Camera Camera;
    public Transform CameraFollower;

    public override void SetComponent(Entity e, EntityCommandBuffer ecb)
    {
        ecb.AddComponent(e, new PlayerTagComponent());
        ecb.AddComponent(e, new MovementSpeedComponent { Value = MovemenSpeed });
        ecb.AddComponent(e, new CharacterControllerMonoRefComponent { Value = CharacterController });
        ecb.AddComponent(e, new CameraMonoRefComponent() { Value = Camera.main });
        ecb.AddComponent(e, new CameraFollowerComponent() { Value = CameraFollower });
        ecb.AddComponent(e, new CameraSettingsComponent()
        {
            Invert = Invert_camera,
            ClampMaxAngle  = ClampMaxAngle_camera,
            ClampMinAngle  = ClampMinAngle_camera,
            RotationSpeedX = RotationSpeedX_camera,
            RotationSpeedY = RotationSpeedY_camera
        });
    }
}