using System.Collections.Generic;
using Enums;
using UnityEngine;
using Extentions;

public class EnemySpawner : ITargetContainer
{
    private GameField _gameField;
    private PathFindingField GameField = new PathFindingField();
    
    public ITarget GetClosestTarget(Vector3 startPosition, TargetType preferredTargetType)
    {
        return null;
    }

    public void Initialize()
    {
        
    }
    
    private Stack<PathCell> FindPath(PathCell startCell, PathCell endCell)
    {
        var reachableCells = new List<PathCell>() {startCell};
        var exploredCells = new List<PathCell>();
        while (reachableCells.Count > 0)
        {
            var currentCell = ChooseCell();
            
            if (currentCell == endCell)
            {
                return BuildPath(currentCell);
            }

            reachableCells.Remove(currentCell);
            exploredCells.Add(currentCell);

            var newReachableCells = currentCell.Neighbors.ToEnumerable();

            foreach (var cell in newReachableCells)
            {
                if (!exploredCells.Contains(cell)) continue;
                
                if (!reachableCells.Contains(cell))
                {
                    reachableCells.Add(cell);
                }

                if (currentCell.Cost +1 < cell.Cost)
                {
                    cell.PreviousCell = currentCell;
                    cell.Cost = currentCell.Cost + 1;
                }
            }

        }

        PathCell ChooseCell()
        {
            var minCost = Mathf.Infinity;
            var bestCell = new PathCell(new Vector3Int(0,0,0));

            foreach (var cell in reachableCells)
            {
                var fullCost = cell.GetFullCost(endCell);
                if (minCost > fullCost)
                {
                    minCost = fullCost;
                    bestCell = cell;
                }
            }

            return bestCell;
        }

        Stack<PathCell> BuildPath(PathCell cell)
        {
            var path = new Stack<PathCell>();
            var currentCell = cell;
            while (currentCell != null)
            {
                path.Push(currentCell);
                currentCell = currentCell.PreviousCell;
            }

            return path;
        }

        return null;
    }
}

public class PathFindingField
{
    private PathCell[,,] _pathCells;
    
    public void GeneratePathFindingField(Vector3Int size)
    {
        _pathCells = new PathCell[size.x, size.y, size.z];
        for (int y = 0; y < size.y; y++)
        {
            for (int x = 0; x < size.x; x++)
            {
                for (int z = 0; z < size.z; z++)
                {
                    var currentCell = _pathCells[x,y,z] = new PathCell(new Vector3Int(x,y,z));
                    if (y > 0)
                    {
                        PathCell.SetUpDownNeighbours(currentCell, _pathCells[x,y-1,z]);
                    }
                    if (z > 0)
                    {
                        PathCell.SetFowardBackNeighbours(currentCell, _pathCells[x,y,z-1]);
                    }
                    if (x > 0)
                    {
                        PathCell.SetRightLeftNeighbours(currentCell, _pathCells[x-1,y,z]);
                    }
                }
            }
        }
    }

    public PathCell GetCellByPosition(Vector3Int position)
    {
        return _pathCells[position.x, position.y, position.z];
    }
}

public class PathCell
{
    public Neighbors3<PathCell> Neighbors { get; }
    
    public int multiplier = 1;

    public int Cost;

    public PathCell PreviousCell;
    
    public readonly Vector3Int Position;
    
    public PathCell(Vector3Int position)
    {
        Position = position;
    }
    
    public int GetFullCost(PathCell endCell)
    {
        var length = (int)(Position - endCell.Position).magnitude;
        return Cost * multiplier + length;
    }
    
    public static void SetRightLeftNeighbours(PathCell right, PathCell left)
    {
        right.Neighbors.Left = left;
        left.Neighbors.Right = right;
    }
    public static void SetFowardBackNeighbours(PathCell foward, PathCell back)
    {
        foward.Neighbors.Back = back;
        back.Neighbors.Foward = foward;
    }
    public static void SetUpDownNeighbours(PathCell up, PathCell down)
    {
        up.Neighbors.Down = down;
        down.Neighbors.Up = up;
    }
}