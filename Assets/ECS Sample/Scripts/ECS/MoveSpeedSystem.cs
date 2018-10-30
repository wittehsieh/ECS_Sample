using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class MoveSpeedSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        var job = new MoveSpeedJob
        {
            targetPos = GameManager.GM.Target.position,
            acceleratAmount = GameManager.GM.AcceleratAmount,
            velocityAmount = GameManager.GM.VelocityAmount,
            deltaTime = Time.deltaTime
        };
        job.Schedule(this).Complete();
    }

    [BurstCompile]
    private struct MoveSpeedJob : IJobProcessComponentData<Position, MoveSpeed>
    {
        public float3 targetPos;
        public float acceleratAmount;
        public float velocityAmount;
        public float deltaTime;

        public void Execute(ref Position pos, ref MoveSpeed moveSpeed)
        {
            pos.Value = pos.Value + moveSpeed.Velocity * deltaTime;
            moveSpeed.Velocity = math.normalize(moveSpeed.Velocity + acceleratAmount * deltaTime * math.normalize(targetPos - pos.Value)) * velocityAmount;
        }
    }
}
