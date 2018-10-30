using System;
using Unity.Entities;
using Unity.Mathematics;

[Serializable]
public struct MoveSpeed : IComponentData
{
    public float3 Velocity;
}

[UnityEngine.DisallowMultipleComponent]
public class MoveSpeedSpeedComponent : ComponentDataWrapper<MoveSpeed>
{
}
