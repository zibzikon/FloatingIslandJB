using System.Collections;
using System.Threading.Tasks;
using Interfaces;
using UnityEngine;

namespace Units.Behaviours.Diethable
{
    public class TerrestrialEnemyAtackingBehaviour: IAtackable
    {
        private readonly IMovable _movingBehaviour;
        

        private bool _isAtacking;
        
        public bool AtackingStarted { get; private set; }
        
        private readonly EnemyStats _enemyStats;

        private bool _targetWasDied;

        public TerrestrialEnemyAtackingBehaviour(IMovable movingBehaviour, EnemyStats enemyStats)
        {
            _movingBehaviour = movingBehaviour;
            _enemyStats = enemyStats;
        }
        
        public void Atack(ITarget target)
        {
            AtackingStarted = true;
            _targetWasDied = false;
            StartAtack(target);
        }

        private async void StartAtack(ITarget target)
        {
            _targetWasDied = false;
           _movingBehaviour.MoveTo(target);
           
            while (!_isAtacking)
            {
                await Task.Delay(_enemyStats.AtackInterval * 1000);
                if (!_movingBehaviour.TargetWasReached) continue;
                _isAtacking = true;
            }
            
            StartDamaging(target);
        }

        private async void StartDamaging(IDamagable damagable)
        {
            damagable.Died.AddListener(OnDie);
            while (!_targetWasDied)
            {
                await Task.Delay(_enemyStats.AtackInterval * 1000);
                damagable?.Damage(_enemyStats.DamageStrength);
                Debug.Log("Target was damaged");
            }

            Debug.Log("reseted");
            _isAtacking = false;
            AtackingStarted = false;
        }

        private void OnDie()
        {
            _targetWasDied = true;
        }
    }
}