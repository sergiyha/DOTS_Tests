using Systems;
using Unity.Entities;

namespace Initialization
{
    [UpdateInGroup(typeof(SimulationSystemGroup), OrderFirst = true)]
    public partial class InitializationSystem : SystemBase
    {
        private World _world;

        protected override void OnCreate()
        {
            _world = World.DefaultGameObjectInjectionWorld;
            var ecb = _world.GetOrCreateSystem<EndInitializationEntityCommandBufferSystem>().CreateCommandBuffer();
            InitInputEntity(ecb);
            InitSystems();
        }

        private void InitInputEntity(EntityCommandBuffer ecb)
        {
            var entity = ecb.CreateEntity();
            ecb.SetName(entity, "inputs_entity");
            ecb.AddComponent<AxisInputComponent>(entity);
            ecb.AddComponent<MouseInputComponent>(entity);
        }

        private void InitSystems()
        {
            CreateSystem<SimulationSystemGroup, InputSystem>();
            CreateSystem<SimulationSystemGroup, MovementSystem>();
            CreateSystem<SimulationSystemGroup, CameraRotationSystem>();
        }

        public void CreateSystem<G, S>() where G : ComponentSystemGroup where S : SystemBase
        {
            var systemGroup = _world.GetOrCreateSystem<G>();
            systemGroup.AddSystemToUpdateList(_world.GetOrCreateSystem<S>());
        }

        protected override void OnUpdate()
        {
            // throw new NotImplementedException();
        }
    }
}