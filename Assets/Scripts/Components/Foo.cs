using Unity.Entities;

[GenerateAuthoringComponent]
public struct Foo : IComponentData
{
    public int ValueA;
    public float ValueB;
    public Entity PrefabC;
    public Entity PrefabD;
}

