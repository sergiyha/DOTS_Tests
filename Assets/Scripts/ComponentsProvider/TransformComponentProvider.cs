using Unity.Entities;
using UnityEngine;

public class TransformComponentProvider : BaseComponentProvider
{
    public Transform Transform;

    public override void SetComponent(Entity e, EntityCommandBuffer ecb)
    {
        ecb.AddComponent(e, new TransformMonoReffComponent() { Transform = Transform });
    }
}