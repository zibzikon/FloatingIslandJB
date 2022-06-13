using Enums;
using UnityEngine;

public interface ITarget
{
    public TargetType TargetType { get; }
    public Transform Transform { get; }
}
