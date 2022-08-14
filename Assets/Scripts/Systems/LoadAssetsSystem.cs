using Unity.Entities;
using UnityEngine;

namespace Systems
{
    [DisableAutoCreation]
    public partial class LoadAssetsSystem : SystemBase
    {
        private EndInitializationEntityCommandBufferSystem eiecb;

        protected override void OnCreate()
        {
            eiecb = World.DefaultGameObjectInjectionWorld.GetOrCreateSystem<EndInitializationEntityCommandBufferSystem>();
        }

        protected override void OnUpdate()
        {
            Entities. /*WithNone<AssetAsyncOperationHandleComponent>().*/ForEach((Entity e, LoadPrefabComponent s) =>
            {
                Debug.LogError(EntityManager.GetChunk(e).GetOrderVersion());
                Debug.LogError(EntityManager.Version);

                //var handler = Addressables.LoadAssetAsync<GameObject>(s.assetPath);
                //eiecb.CreateCommandBuffer().AddComponent(e, new AssetAsyncOperationHandleComponent { handle = handler });
                //Debug.LogError(s.assetPath);
            }).WithoutBurst().Run();

            Entities.ForEach((Entity e, AssetAsyncOperationHandleComponent handler) =>
            {
                if (handler.handle.IsDone)
                {
                    Object.Instantiate(handler.handle.Result);
                    eiecb.CreateCommandBuffer().DestroyEntity(e);
                }
                else
                {
                    Debug.LogError("Loading...");
                }
            }).WithoutBurst().Run();
        }
    }
}