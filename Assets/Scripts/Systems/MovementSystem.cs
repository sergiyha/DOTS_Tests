using Unity.Entities;
using UnityEngine;

namespace Systems
{
    [DisableAutoCreation]
    public partial class MovementSystem : SystemBase
    {
        private Vector3 _cameraForward;
        private Vector3 _cameraRight;
        private Camera _mainCamera;

        protected override void OnUpdate()
        {
            CacheCamera();

            var axisData = GetSingleton<AxisInputComponent>();


            Entities.ForEach(
                (
                    CharacterControllerMonoRefComponent charRefComp,
                    in PlayerTagComponent playerTag,
                    in MovementSpeedComponent moveSpeedComponent
                ) =>
                {
                    var moveSpeed = moveSpeedComponent.Value;
                    var velocityX = axisData.X * moveSpeed * Time.DeltaTime;
                    var velocityY = axisData.Y * moveSpeed * Time.DeltaTime;
                    _cameraForward = new Vector3(_cameraForward.x, 0, _cameraForward.z).normalized;
                    _cameraRight = new Vector3(_cameraRight.x, 0, _cameraRight.z).normalized;

                    var moveVector = _cameraForward * velocityY + _cameraRight * velocityX;

                    charRefComp.Value.Move(moveVector);
                }).WithoutBurst().Run();
        }

        private void CacheCamera()
        {
            if (!_mainCamera)
            {
                Entities.ForEach((CameraMonoRefComponent camera) => { _mainCamera = camera.Value; }).WithoutBurst().Run();
                return;
            }

            var transform = _mainCamera.transform;
            _cameraForward = transform.forward;
            _cameraRight = transform.right;
        }
    }
}