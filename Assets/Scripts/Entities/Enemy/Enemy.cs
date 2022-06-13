
using System;
using Enums;
using UnityEngine;
public abstract class Enemy : Entity, IDamagable, IAtackable, IMovable, IDiethable, IUpdatable
{
    protected Vector3 Position;
    
    protected abstract EnemyStats EnemyStats { get; }
    
    protected override EntityStats Stats => EnemyStats;
    
    protected abstract TargetType PreferredTargetType { get; }
    
    public event Action Moving;
    
    public event Action Atacking;
    
    public event Action Dieing;

    public event Action Damaging;
    
    protected abstract IDiethable  DieBehaviour { get; }
    protected abstract IAtackable AtackBehaviour { get; }
    protected abstract IMovable MovingBehaviour { get; }
    
    protected ITargetContainer TargetContainer { get; private set; }
    
    public void Initialize(ITargetContainer targetContainer)
    {
        TargetContainer = targetContainer;
    }

    public virtual void Damage(int count)
    {
        EnemyStats.Health -= count;
        Damaging?.Invoke();
        if (EnemyStats.Health <= 0)
        {
            Die();
        }
    }

    public virtual void Atack(IDamagable damagable)
    {
        AtackBehaviour.Atack(damagable);
        Atacking?.Invoke();
    }
    
    public virtual void MoveTo(ITarget target)
    {
        MovingBehaviour.MoveTo(target);
        Moving?.Invoke();
    }

    public virtual void Die()
    {
        DieBehaviour.Die();
        Dieing?.Invoke();
    }

    public abstract void OnUpdate();

}

