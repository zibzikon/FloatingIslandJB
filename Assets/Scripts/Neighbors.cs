﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neighbors<T>
{ 
    public T Right;
    public T Left;
    public T Foward;
    public T Back;
    public T Up;
    public T Down;

    public T this[Direction3 direction]
    {
        get 
        { 
            switch(direction)
            {
                case Direction3.Zero:
                    throw new NullReferenceException("Direction cannot be zero");

                case Direction3.Right: return Right;
                case Direction3.Left: return Left;
                case Direction3.Foward: return Foward;
                case Direction3.Back: return Back;
                case Direction3.Up: return Down;

                default: return Up;
            }
        }
        set
        {
            switch (direction)
            {
                case Direction3.Zero:
                    throw new NullReferenceException("Direction cannot be zero");

                case Direction3.Right: Right = value; return;
                case Direction3.Left: Left = value; return;
                case Direction3.Foward: Foward = value; return;
                case Direction3.Back: Back = value; return;
                case Direction3.Up: Up = value;return;
                default: Down = value; return;
            }
        }
    }

    public T this[int i]
    {
        get
        {
            switch (i)
            {
                case 0: return Right;
                case 1: return Left;
                case 2: return Foward;
                case 3: return Back;
                case 4: return Up;
                case 5: return Down;
                default: throw new IndexOutOfRangeException();
            }
        }
        set
        {
            switch (i)
            {
                case 0: Right = value;
                    break;
                case 1: Left = value;
                    break;
                case 2: Foward = value;                   
                    break;
                case 3: Back = value;                   
                    break;
                case 4: Up = value;                   
                    break;
                case 5: Down = value;                   
                    break;

                default: throw new IndexOutOfRangeException();
            }
        }
    }
}

