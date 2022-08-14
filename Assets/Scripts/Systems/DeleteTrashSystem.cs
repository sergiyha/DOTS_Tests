using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

[DisableAutoCreation]
public class DeleteTrashSystem : GameObjectConversionSystem
{
    private ComponentTypes OldTransforms = new(new ComponentType[]
    {
        typeof(Translation), typeof(Rotation), typeof(NonUniformScale), typeof(Foo)
    });

    protected override void OnUpdate()
    {
        Entities.ForEach((Transform transform) =>
        {
            var srcEntity = GetPrimaryEntity(transform);
            DstEntityManager.RemoveComponent(srcEntity, OldTransforms);
        });
    }
}