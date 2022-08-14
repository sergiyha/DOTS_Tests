using Systems;
using Unity.Entities;
using UnityEngine;

namespace Initialization
{
    [UpdateInGroup(typeof(SimulationSystemGroup), OrderFirst = true)]
    public partial class InitializationSystem : SystemBase
    {
        protected override void OnCreate()
        {
            var world = World.DefaultGameObjectInjectionWorld;
            var ecb = world.GetOrCreateSystem<EndInitializationEntityCommandBufferSystem>().CreateCommandBuffer();
            InitInputEntity(ecb);
            InitSystems(world);
        }

        private void InitInputEntity(EntityCommandBuffer ecb)
        {
            var entity = ecb.CreateEntity();
            ecb.SetName(entity, "inputs_entity");
            ecb.AddComponent<AxisInputComponent>(entity);
        }

        private void InitSystems(World world)
        {
            CreateSystem<SimulationSystemGroup, InputSystem>(world);
            CreateSystem<SimulationSystemGroup, MovementSystem>(world);
        }

        public void CreateSystem<G, S>(World w) where G : ComponentSystemGroup where S : SystemBase
        {
            var systemGroup = w.GetOrCreateSystem<G>();
            systemGroup.AddSystemToUpdateList(w.GetOrCreateSystem<S>());
        }

        protected override void OnUpdate()
        {
            // throw new NotImplementedException();
        }
    }
}