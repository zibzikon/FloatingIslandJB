using Enums;
using Units.Behaviours;
using Units.Behaviours.Atacking;
using Units.Behaviours.Diethable;
using UnityEngine;


public class Garry : Enemy
{
    protected override EnemyStats EnemyStats { get; }
    
    protected override TargetType PreferredTargetType { get; } = TargetType.Tower;
        
    protected override IDiethable DieBehaviour { get; } = new TerrestrialEnemyDiethingBehaviour();

    protected override IAtackable AtackBehaviour { get; } = new ItemThrowerAtackingBehaviour();

    protected override IMovable MovingBehaviour { get; } = new TerrestrialEnemyMovingBehaviour();
    
    public override void OnUpdate()
    {
        
    }

    private Transform GetTarget()
    {
        return null;
    }
}
