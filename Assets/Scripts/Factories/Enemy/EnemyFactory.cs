using System;
using Enums;
using UnityEngine;

namespace Factories.Enemy
{
    [CreateAssetMenu(fileName = "EnemyFactory")]
    public class EnemyFactory : GameObjectFactory
    {
        [SerializeField] private EnemyView _garry;
        
        public global::Enemy Get(EnemyType enemyType, ITargetContainer targetContainer)
        {
            return enemyType switch
            {
                EnemyType.Garry => CreateEnemy(_garry, new Garry(), targetContainer),
                _ => throw new IndexOutOfRangeException()
            };
        }

        private global::Enemy CreateEnemy(EnemyView prefab, global::Enemy model, ITargetContainer targetContainer)
        {
            model.Initialize(targetContainer);
            var enemyViewInstance = CreateGameObjectInstance(prefab);
            enemyViewInstance.Initialize(model);
            return model;
        }
    }
}