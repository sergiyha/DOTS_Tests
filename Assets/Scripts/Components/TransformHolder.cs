using Unity.Entities;

public interface IGoComponentProvider
{
    void SetComponent(Entity e, EntityCommandBuffer ecb);
}