using Unity.Entities;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AssetAsyncOperationHandleComponent : IComponentData
{
    public AsyncOperationHandle<GameObject> handle;
}