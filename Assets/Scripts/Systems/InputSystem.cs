using Unity.Entities;
using UnityEngine;

namespace Systems
{
    [DisableAutoCreation]
    public partial class InputSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            float X_prev = 0;
            float Y_prev = 0;
            Entities.ForEach((Entity e, ref AxisInputComponent axisComponent) =>
            {
                var x = Input.GetAxis("Horizontal");
                var y = Input.GetAxis("Vertical");

                axisComponent.X = x;
                axisComponent.Y = y;
            }).WithoutBurst().Run();
        }
    }
}