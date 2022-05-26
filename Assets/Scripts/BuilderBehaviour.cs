using System;
using System.Collections.Generic;
using System.Linq;
using Extentions;
using Factories.Building;
using UnityEngine;

public class BuilderBehaviour : IUpdatable, IRecyclable
{
    private Camera _mainCamera;

    private GameField.GameField _gameField;
    
    private BuildingFactory _buildingFactory;

    private readonly List<IUpdatable> _buildingsToUpdate = new();

    private Building _currentBuilding;
    private Building _selectedBuilding;
    
    private BuildingPointersFactory _buildingPointersFactory;

    private BuildingPointer _selectedBuildingPointer;
    private List<BuildingPointer> _spawnedPointers = new();
    private bool _currentBuildingIsReadyToSet => CheckBuildingSettingAvialible();
    public bool BuildingWasSpawned => _currentBuilding != null;
  
    public BuilderBehaviour(GameField.GameField gameField,BuildingFactory buildingFactory, 
        BuildingPointersFactory buildingPointersFactory, Camera mainCamera)
    {
        _gameField = gameField;
        _buildingFactory = buildingFactory;
        _buildingPointersFactory = buildingPointersFactory;
        _mainCamera = mainCamera;
    }

    public void OnUpdate()
    {
        foreach (var building in _buildingsToUpdate)
        {
            building.OnUpdate();
        }
        if (_currentBuilding != null)
        {
            if (Input.GetKeyDown(KeyCode.E) && _currentBuildingIsReadyToSet)
            {
                AcceptSettingBuilding();
            }
            else if (Input.GetKeyDown(KeyCode.Q))
            {
                DeclineSettingBuilding();
            }
            else if ( Input.GetMouseButtonDown(0) && _selectedBuilding == null)
            {            

                var selectedBuilding= SelectItem()?.GetComponent<BuildingWithChilds>();
                if (selectedBuilding != null && selectedBuilding != _currentBuilding)
                {
                    _selectedBuilding = selectedBuilding;
                    OnBuildingSelected();
                }
                else
                {
                    SetCurrentBuildingPosition();
                }
            }
            else if (Input.GetMouseButtonDown(0) && _selectedBuilding != null && _selectedBuildingPointer == null)
            {
                _selectedBuildingPointer = SelectItem()?.GetComponent<BuildingPointer>();
                if (_selectedBuildingPointer != null)
                {
                    OnPointerSelected();
                }
            }
        }
    }

    public void SpawnBuilding(BuildingType type)
    {
        if (_currentBuilding != null)
        {
            throw new InvalidOperationException();
        }
        _currentBuilding = _buildingFactory.GetNewBuilding(type);
        if (BuildingWithChilds.IsBuildingWithChilds(_currentBuilding)) 
            _buildingsToUpdate.Add((BuildingWithChilds)_currentBuilding);
    }

    private List<BuildingPointer> SpawnBuiildingPointers(BuildingWithChilds building)
    {
        var buildingTrueSize = building.GetComponent<MeshRenderer>().bounds.size;
        var buildingTrueCenterPosition = building.GetComponent<MeshRenderer>().bounds.center;
        var builingPointers = new List<BuildingPointer>();
        
        foreach (var direction in DirectionExtentions.GetDirectionEnumerable())
            if (GetCorrectBuildingBuildPoint(building, _currentBuilding, direction) != null)
                builingPointers.Add(_buildingPointersFactory.GetNewBuildPointer(direction,
                    direction.ToVector3(), buildingTrueCenterPosition + buildingTrueSize));

        Debug.Log("Building Pointers Is Spawned");
        return builingPointers;
    }

    private Transform SelectItem()
    {
        var collisionObject = GetRayCollision()?.GetComponent<CollisionObject>();
        if (collisionObject != null)
        {
            return collisionObject.Parent;
        }
        return null;
        Collider GetRayCollision()
        {
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            return Physics.Raycast(ray, out var hit) ? hit.collider : null;
        }
    }

    private static RaycastHit GetRaycastHitByMousePosition(Camera camera)
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        return Physics.Raycast(ray, out var hit) ? hit : new RaycastHit();
    }
    
    private bool CheckBuildingSettingAvialible()
    {
        return _selectedBuilding != null && _selectedBuildingPointer != null;
    }
    
    private void SetCurrentBuilding()
    {
        if (BuildingWithChilds.IsBuildingWithChilds(_selectedBuilding))
        {
            var correctBuildPoint = GetCorrectBuildingBuildPoint((BuildingWithChilds)_selectedBuilding,
                _currentBuilding, _selectedBuildingPointer.Direction);
            if (correctBuildPoint != null)
            {
                _currentBuilding.SetSupportBuilding((BuildingWithChilds)_selectedBuilding,
                    correctBuildPoint.BuildPosition);
            }
        }
    }

    private BuildPoint GetCorrectBuildingBuildPoint(BuildingWithChilds supportBuilding, Building childBuilding, 
        Direction direction)
    {
        var buildPoints = supportBuilding.BuildPoints[direction];
        return buildPoints?.FirstOrDefault(buildPoint => buildPoint.WhiteList.Contains(_currentBuilding.BuildingType));
    }

    private void SetCurrentBuildingPosition()
    {
        if (_selectedBuilding != null)
        {
            var correctBuildPoint = GetCorrectBuildingBuildPoint((BuildingWithChilds)_selectedBuilding, 
                _currentBuilding, _selectedBuildingPointer.Direction);
            if (correctBuildPoint == null) return;
            _currentBuilding.transform.position = correctBuildPoint.BuildPosition;
            Debug.Log("Current Building Position Is Seted");
        }
        else
        {
            var currentCell = _gameField.GetCellByPosition(GetRaycastHitByMousePosition(_mainCamera).point.ToVector3Int());
            if (currentCell == null) return;
            _currentBuilding.transform.position = currentCell.WorldPosition;
        }
    }

    private void OnBuildingSelected()
    {
        if (BuildingWithChilds.IsBuildingWithChilds(_selectedBuilding))
        {
            var buildingWithChilds = (BuildingWithChilds)_selectedBuilding;
            _spawnedPointers = SpawnBuiildingPointers(buildingWithChilds);
            Debug.Log("Building Is Selected");

        }
    }

    private void OnPointerSelected()
    {
        SetCurrentBuildingPosition();
        Debug.Log("Pointer Is Selected");
    }

    private void AcceptSettingBuilding()
    {
        if (_currentBuildingIsReadyToSet == false)
            throw new InvalidOperationException("Current building is not ready to set");

        SetCurrentBuilding();
        Reset();
        Debug.Log("Setting Building Is Accepted");

    }

    private void DeclineSettingBuilding()
    {
        _buildingFactory.Reclaim(_currentBuilding);
        Reset();
        Debug.Log("Setting Building Is Declined");
    }

    private void Reset()
    {
        _currentBuilding = null;
        _selectedBuilding = null;
        _selectedBuildingPointer = null;
        _spawnedPointers.DestroyObjects();
        _selectedBuildingPointer = null;
        Debug.Log("Fields Is Reseted");
    }

    public void Recycle()
    {
        Reset();
    }
}

