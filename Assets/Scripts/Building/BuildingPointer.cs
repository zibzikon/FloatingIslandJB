using System;
using System.Collections.Generic;
using UnityEngine;
public class BuildingPointer : MonoBehaviour
{
    public Direction Direction { get; private set; }
    
    [SerializeField]
    private CollisionObject _collisionObject;
    public CollisionObject CollisionObject
    {
        get
        {
            if (_collisionObject.Parent != null && _collisionObject.Parent != this) throw new InvalidOperationException("Collision parent dont equals true parent object");
            return _collisionObject;
        }
    }

    public void Initialize(Direction direction)
    {
        Direction = direction;
    }
}
