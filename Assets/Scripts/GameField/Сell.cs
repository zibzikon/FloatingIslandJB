using UnityEngine;
public class Cell
{
    public Vector3Int Position { get; }
    public Neighbors<Cell> neighbours;

    private Building _building;
    public Building Building
    {
        get => _building;
        set
        {
            if (_building != null)
            {
                _building.Recycle();
            }
            _building = value;
        }
    }

    public static void SetRightLeftNeighbours(Cell right, Cell left)
    {
        right.neighbours.Left = left;
        left.neighbours.Right = right;
    }
    public static void SetFowardBackNeighbours(Cell foward, Cell back)
    {
        foward.neighbours.Back = back;
        back.neighbours.Foward = foward;
    }
    public static void SetUpDownNeighbours(Cell up, Cell down)
    {
        up.neighbours.Down = down;
        down.neighbours.Up = up;
    }
}

