using Unity.Entities;
using UnityEngine;

namespace Systems
{
    [DisableAutoCreation]
    public partial class MovementSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            var axisData = GetSingleton<AxisInputComponent>();
            Entities.ForEach((CharacterControllerMonoRefComponent charRefComp, in PlayerTagComponent playerTag, in MovementComponent moveSpeedComponent) =>
            {
                var moveSpeed = moveSpeedComponent.movementSpeed;
                var moveVector = new Vector3
                (
                    axisData.X * moveSpeed * Time.DeltaTime,
                    0f,
                    axisData.Y * moveSpeed * Time.DeltaTime
                );
                charRefComp.CharacterController.Move(moveVector);
            }).WithoutBurst().Run();
        }
    }
}