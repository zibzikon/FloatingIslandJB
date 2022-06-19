
using System;
using Enums;
using Interfaces;
using UnityEngine;
using UnityEngine.Events;

public abstract class Enemy : Entity, IDamagable, IUpdatable, IPausable
{
    public bool IsPaused { get; private set; }

    public UnityEvent Died { get; }

    protected abstract EnemyStats EnemyStats { get; }
    
    protected override EntityStats Stats => EnemyStats;
    
    protected abstract TargetType PreferredTargetType { get; }
    
    public event Action Damaging;
    
    protected abstract IDiethable  DieBehaviour { get; set; }
    protected abstract IAtackable AtackBehaviour { get; set;}
    protected abstract IMovable MovingBehaviour { get; set;}
    
    protected ITargetContainer TargetContainer { get; private set; }
    
    public void Initialize(ITargetContainer targetContainer)
    {
        TargetContainer = targetContainer;
        InitializeBahaviours();
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

    protected abstract void InitializeBahaviours();

    public virtual void Die()
    {
        DieBehaviour.Die();
        Died?.Invoke();
    }

    public virtual void OnUpdate()
    {
        if (IsPaused) return;
        
        if (!AtackBehaviour.AtackingStarted)
        {
            AtackBehaviour.Atack(GetTarget());
        }
    }

    protected abstract ITarget GetTarget();

    public void Pause()
    {
        IsPaused = true;
    }

    public void UnPause()
    {
        IsPaused = false;
    }
}

