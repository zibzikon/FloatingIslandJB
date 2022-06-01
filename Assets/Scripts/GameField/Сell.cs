using System;
using UnityEngine;


public class Cell
{
    public event Action Changed;
    public Vector3Int Position { get; }
    public Vector3 WorldPosition => Position * GeneralGameSettings.GameFieldSettings.WorldPositionMultiplier;
    private Neighbors<Cell> _neighbours = new();
    
    public bool IsFilled { get; private set; }
    
    public Cell(Vector3Int position)
    {
        Position = position;
    }

    public void Fill()
    {
        IsFilled = true;
        Changed?.Invoke();
    }

    public void Clear()
    {
        IsFilled = false;
        Changed?.Invoke();
    }
    public static void SetRightLeftNeighbours(Cell right, Cell left)
    {
        right._neighbours.Left = left;
        left._neighbours.Right = right;
    }
    public static void SetFowardBackNeighbours(Cell foward, Cell back)
    {
        foward._neighbours.Back = back;
        back._neighbours.Foward = foward;
    }
    public static void SetUpDownNeighbours(Cell up, Cell down)
    {
        up._neighbours.Down = down;
        down._neighbours.Up = up;
    }
}


