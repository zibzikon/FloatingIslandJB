using System;
using System.Collections.Generic;
using UnityEngine;
public static class DirectionExtentions
{
    public static IEnumerable<Direction> GetDirectionEnumerable()
    {
        return new[] { Direction.Right, Direction.Left, Direction.Foward, Direction.Back, Direction.Up, Direction.Down };
    }
    public static Vector3 ToVector3( this Direction direction)
    {
        switch (direction)
        {
            case Direction.Zero:
                throw new NullReferenceException("Direction cannot be zero");

            case Direction.Right: return Vector3.right;
            case Direction.Left: return Vector3.left;
            case Direction.Foward: return Vector3.forward;
            case Direction.Back: return Vector3.back;
            case Direction.Up: return Vector3.up;
            default: return Vector3.down;
        }
    }
}

