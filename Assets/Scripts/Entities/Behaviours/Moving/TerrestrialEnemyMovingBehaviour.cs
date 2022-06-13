using UnityEngine;
using UnityEngine.AI;

namespace Units.Behaviours
{
    public class TerrestrialEnemyMovingBehaviour : IMovable
    {
        private NavMeshAgent _agent;

        private Vector3 GetMovingPosition(ITarget targettraTransform)
        {
           return Vector3.zero;
        }

        public void MoveTo(ITarget target)
        {
            _agent.SetDestination(GetMovingPosition(target));
        }
    }
}