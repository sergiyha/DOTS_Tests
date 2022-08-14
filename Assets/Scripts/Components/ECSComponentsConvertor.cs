using Unity.Entities;
using UnityEngine;

public class ECSComponentsConvertor : MonoBehaviour
{
    public string Name;

    private void Awake()
    {
        InjectComponents();
    }

    private void InjectComponents()
    {
        var ecb = World.DefaultGameObjectInjectionWorld.GetOrCreateSystem<EndInitializationEntityCommandBufferSystem>().CreateCommandBuffer();
        var entity = ecb.CreateEntity();
        ecb.SetName(entity, Name);
        foreach (var binder in GetComponents<IGoComponentProvider>())
        {
            binder.SetComponent(entity, ecb);
            Destroy(binder as MonoBehaviour);
        }
    }
}