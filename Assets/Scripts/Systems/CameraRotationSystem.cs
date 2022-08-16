using Unity.Entities;
using UnityEngine;

[DisableAutoCreation]
public partial class CameraRotationSystem : SystemBase
{
    private float _previousXCameraRotation;

    protected override void OnUpdate()
    {
        Entities.ForEach((Entity e, CameraFollowerComponent cameraFollower, in PlayerTagComponent playerTagComponent, in CameraSettingsComponent cameraSettings) =>
        {
            var mouseInputComponent = GetSingleton<MouseInputComponent>();
            var transform = cameraFollower.Value;
            var rotation = transform.rotation.eulerAngles;
            var xRotation = rotation.x + mouseInputComponent.Y * Time.DeltaTime * cameraSettings.RotationSpeedX * Invert(cameraSettings.Invert);

            if (xRotation > cameraSettings.ClampMinAngle && xRotation < cameraSettings.ClampMaxAngle)
            {
                if (_previousXCameraRotation >= cameraSettings.ClampMaxAngle)
                {
                    Debug.LogError("one");
                    // Debug.LogError($"{xRotation}--{cameraSettings.ClampMinAngle}--{cameraSettings.ClampMaxAngle}");
                    xRotation = cameraSettings.ClampMaxAngle;
                }


                if (_previousXCameraRotation <= cameraSettings.ClampMinAngle)
                {
                    Debug.LogError("two");
                    xRotation = cameraSettings.ClampMinAngle;
                }
            }


            //if (!(xRotation > cameraSettings.ClampMaxAngle))
            //{
            //    xRotation = cameraSettings.ClampMaxAngle;
            //}


            transform.rotation = Quaternion.Euler
            (
                xRotation,
                rotation.y + mouseInputComponent.X * Time.DeltaTime * cameraSettings.RotationSpeedY * Invert(!cameraSettings.Invert),
                rotation.z
            );
            _previousXCameraRotation = xRotation;
        }).WithoutBurst().Run();
    }

    private float Invert(bool invert) => invert ? -1 : 1;
}