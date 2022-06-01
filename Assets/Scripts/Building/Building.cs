using System;
using System.Collections.Generic;
using System.Linq;
using Extentions;
using UnityEngine;

public abstract class Building : MonoBehaviour , IRecyclable
{
    [SerializeField] private Vector3Int _startPosition;
    
    public Vector3Int PositionOnGameField { get; private set; }
    
    [SerializeField] private List<Vector3Int> _occupyingCells;

    [SerializeField] private BuildingType _buildingType;

    [SerializeField] private Direction2 _direction = Direction2.Foward;
    
    public BuildingType BuildingType => _buildingType;

    private IBuildingContainer _supportBuilding;

    private GameField _gameField;
    private List<Cell> _settedCells = new ();
    
    private static readonly IEnumerable<BuildingType> _buildingTypesCanBeSettedOnGameField = new[]
    {
        BuildingType.SupportPillar
    };

    public static bool CanBeSettedOnGameField(Building building)
    {
        return _buildingTypesCanBeSettedOnGameField.Contains(building._buildingType);
    }
    public void Initialize(GameField gameField)
    {
        _gameField = gameField;
    }
    public void SetDirection(Direction2 direction)
    {
        for (int i = 0; i < _occupyingCells.Count; i++)
        {
            var cell = _occupyingCells[i];
            _occupyingCells[i] = cell.SetDirection(_direction, direction);
        }
        
        _direction = direction;
    }
    
    public bool TrySetBuilding(IBuildingContainer buildingContainer ,BuildPoint buildPoint)
    {
        buildingContainer.SetBuildPointsPosition();
        if (TrySetCells(_gameField.GetCellByPosition(buildPoint.OccupedCellPosition)) == false) return false;
        _supportBuilding = buildingContainer;
        this.transform.position = buildPoint.BuildPosition;
        Debug.Log("buildingWasSeted");
        return true;
    }

    public bool TrySetBuilding(Cell startCell)
    {
        if (TrySetCells(startCell) == false) return false;
        this.transform.position = startCell.WorldPosition;
        Debug.Log("buildingWasSeted");
        return true;
    }

    private bool TrySetCells(Cell startCell)
    {
        var tempSettedCells = new List<Cell>();
        foreach (var cellPosition in _occupyingCells)
        {
           var cell = _gameField.GetCellByPosition(_startPosition + startCell.Position + cellPosition);
           if (cell.IsFilled && !_settedCells.Contains(cell)) return false;
           tempSettedCells.Add(cell);
        }

        PositionOnGameField = startCell.Position + _startPosition;
        _settedCells.ForEach(cell=>cell.Clear());
        tempSettedCells.ForEach(cell => cell.Fill());
        _settedCells = tempSettedCells;
        
        return true;
    }
    

    public void Recycle()
    {
        _settedCells.ForEach(cell=>cell.Clear());
    }
}