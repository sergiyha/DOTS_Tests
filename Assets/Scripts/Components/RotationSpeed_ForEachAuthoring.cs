using Unity.Entities;
using UnityEngine;

//[GenerateAuthoringComponent]
public struct RotationSpeed_ForEach : IComponentData
{
    public float RadiansPerSecond;
}

public class RotationSpeed_ForEachAuthoring : MonoBehaviour, IConvertGameObjectToEntity
{
    public float RadiansPerSecond;
    public void Convert(
        Entity entity,
        EntityManager dstManager,
        GameObjectConversionSystem conversionSystem)
    {
        RotationSpeed_ForEach e = new RotationSpeed_ForEach
        {
            RadiansPerSecond = this.RadiansPerSecond
        };
        dstManager.AddComponentData(entity, e);
    }
}