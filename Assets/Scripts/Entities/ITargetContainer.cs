using Enums;
using UnityEngine;

public interface ITargetContainer
{
    public ITarget GetClosestTarget(Vector3 startPosition, TargetType preferredTargetType);
}
