using Sirenix.OdinInspector;
using Unity.Entities;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    private EndInitializationEntityCommandBufferSystem _cbs;

    private EntityManager _em() => World.DefaultGameObjectInjectionWorld.EntityManager;

    [Button]
    private void SpawnEntity()
    {
        var cb = _cbs.CreateCommandBuffer();
        var entity = _em().CreateEntity();
        cb.AddComponent(entity, new LoadPrefabComponent() { assetPath = "BasicPrefab" });
    }

    private void Awake()
    {
        _cbs = World.DefaultGameObjectInjectionWorld.GetOrCreateSystem<EndInitializationEntityCommandBufferSystem>();
    }
}