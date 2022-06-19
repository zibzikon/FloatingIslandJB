using System;
using UnityEngine.Events;

namespace Units.Behaviours.Diethable
{
    public class TerrestrialEnemyDiethingBehaviour : IDiethable
    {
        public UnityEvent Died { get; } = new UnityEvent();

        public void Die()
        {
            
        }
    }
}