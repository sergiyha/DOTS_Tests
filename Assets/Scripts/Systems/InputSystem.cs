using Unity.Entities;
using UnityEngine;

namespace Systems
{
    [DisableAutoCreation]
    public partial class InputSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities.ForEach((Entity _, ref AxisInputComponent axisComponent, ref MouseInputComponent mouseInput) =>
            {
                var x = Input.GetAxis("Horizontal");
                var y = Input.GetAxis("Vertical");

                var xMouse = Input.GetAxis("Mouse X");
                var yMouse = Input.GetAxis("Mouse Y");

                mouseInput.X = xMouse;
                mouseInput.Y = yMouse;
                axisComponent.X = x;
                axisComponent.Y = y;
                
            }).WithoutBurst().Run();
        }
    }
}