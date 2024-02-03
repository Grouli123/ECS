using Unity.Entities;
using UnityEngine;

public class MoveSystem : ComponentSystem
{
    private EntityQuery _quety;

    protected override void OnCreate()
    {
        _quety = GetEntityQuery(ComponentType.ReadOnly<Move>());
    }

    protected override void OnUpdate()
    {
        Entities.With(_quety).ForEach((Entity entity, Transform transform, Move move)=>
        {
            var p = transform.position;
            p.y += move.moveSpeed / 1000;
            transform.position = p;
        });
    }
}