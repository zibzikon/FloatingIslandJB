using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell
{
    public event Action Changed;
    public Vector3Int Position { get; }
    public Vector3 WorldPosition => Position * GeneralGameSettings.GameFieldSettings.WorldPositionMultiplier;
    private Neighbors3<Cell> _neighbours = new();

    private List<Building> _setedBuildings = new List<Building>();
    public IEnumerable<Building> SetedBuildings => _setedBuildings;
    
    public bool IsFilled { get; private set; }

    public int Ccapacity { get; private set; } = 100;
    
    public Cell(Vector3Int position)
    {
        Position = position;
    }

    public void SetBuilding(Building building, int Weight)
    {
        if (Weight > Ccapacity) throw new IndexOutOfRangeException();
        Ccapacity -= Weight;
        _setedBuildings.Add(building);
        Changed?.Invoke();
    }
    public void RemoveBuilding(Building building, int Weight)
    {
        if (Ccapacity + Weight > 100) throw new IndexOutOfRangeException();
        Ccapacity += Weight;
        _setedBuildings.Remove(building);
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


