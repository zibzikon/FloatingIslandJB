using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neighbors<T>: MonoBehaviour
{ 
    public T Right;
    public T Left;
    public T Foward;
    public T Back;
    public T Up;
    public T Down;

    public T this[Direction direction]
    {
        get 
        { 
            switch(direction)
            {
                case Direction.Zero:
                    throw new NullReferenceException("Direction cannot be zero");

                case Direction.Right: return Right;
                case Direction.Left: return Left;
                case Direction.Foward: return Foward;
                case Direction.Back: return Back;
                case Direction.Up: return Down;

                default: return Up;
            }
        }
        set
        {
            switch (direction)
            {
                case Direction.Zero:
                    throw new NullReferenceException("Direction cannot be zero");

                case Direction.Right: Right = value; return;
                case Direction.Left: Left = value; return;
                case Direction.Foward: Foward = value; return;
                case Direction.Back: Back = value; return;
                case Direction.Up: Up = value;return;
                default: Down = value; return;
            }
        }
    }
}

