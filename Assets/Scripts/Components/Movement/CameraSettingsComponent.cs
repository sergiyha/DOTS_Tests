
    using Systems;
    using Unity.Entities;
    using UnityEngine;

    public struct CameraSettingsComponent : IComponentData
    {
        public bool Invert;
        public float RotationSpeedX;
        public float RotationSpeedY;
        public float ClampMaxAngle;
        public float ClampMinAngle;
        
    }
