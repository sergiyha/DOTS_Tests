using Unity.Entities;
using UnityEngine;


public class PlayerComponentProvider : BaseComponentProvider
{
    public float MovemenSpeed;
    public CharacterController CharacterController;

    public override void SetComponent(Entity e, EntityCommandBuffer ecb)
    {
        ecb.AddComponent(e, new PlayerTagComponent());
        ecb.AddComponent(e, new MovementComponent { movementSpeed = MovemenSpeed });
        ecb.AddComponent(e, new CharacterControllerMonoRefComponent { CharacterController = CharacterController });
    }
}