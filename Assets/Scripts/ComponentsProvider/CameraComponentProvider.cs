using Unity.Entities;
using UnityEngine;

public class CameraComponentProvider : BaseComponentProvider
{
    public Camera Camera;

    public override void SetComponent(Entity e, EntityCommandBuffer ecb)
    {
        ecb.AddComponent(e, new CameraMonoRefComponent { Value = Camera });
    }
}