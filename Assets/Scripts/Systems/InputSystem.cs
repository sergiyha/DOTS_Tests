using Unity.Entities;
using UnityEngine;

namespace Systems
{
    [DisableAutoCreation]
    public partial class InputSystem : SystemBase
    {
        private float prevAxisX = 0;
        private float prevAxisY = 0;

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

                //input interpolation
                prevAxisX = Mathf.Lerp(prevAxisX, x, Time.DeltaTime * 100);
                prevAxisY = Mathf.Lerp(prevAxisY, y, Time.DeltaTime * 100);
                axisComponent.X = prevAxisX;
                axisComponent.Y = prevAxisY;
            }).WithoutBurst().Run();
        }
    }
}