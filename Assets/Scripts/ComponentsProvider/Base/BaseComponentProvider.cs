using Unity.Entities;
using UnityEngine;

public abstract class BaseComponentProvider : MonoBehaviour, IGoComponentProvider
{
    protected EntityCommandBuffer GetECB() => World.DefaultGameObjectInjectionWorld.GetOrCreateSystem<EndInitializationEntityCommandBufferSystem>().CreateCommandBuffer();

    public abstract void SetComponent(Entity e,EntityCommandBuffer ecb);

}
