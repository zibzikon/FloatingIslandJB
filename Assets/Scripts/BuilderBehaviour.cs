using System;
using System.Collections.Generic;
using System.Linq;
using Factories.Building;
using UnityEngine;

public class BuilderBehaviour : IUpdatable

{
    private Camera _mainCamera;

    private BuildingFactory _buildingFactory;

    private readonly List<IUpdatable> _buildingsToUpdate = new();

    private Building _currentBuilding;
    private Building _selectedBuilding;


    private BuildingPointersFactory _buildingPointersFactory;

    private BuildingPointer _selectedBuildingPointer;
    private List<BuildingPointer> _spawnedPointers;
    private bool _currentBuildingIsReadyToSet => _selectedBuilding != null && _selectedBuildingPointer != null;
    public BuilderBehaviour(BuildingFactory buildingFactory, BuildingPointersFactory buildingPointersFactory, Camera mainCamera)
    {
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
                _selectedBuilding = SelectItem()?.GetComponent<BuildingWithChilds>();
                if (_selectedBuilding != null)
                {
                    OnBuildingSelected();
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
        _currentBuilding = _buildingFactory.GetNewBuilding(type);
        if (BuildingWithChilds.IsBuildingWithChilds(_currentBuilding)) _buildingsToUpdate.Add((BuildingWithChilds)_currentBuilding);
    }

    private List<BuildingPointer> SpawnBuiildingPointers(BuildingWithChilds building)
    {
        var buildingTrueSize = building.GetComponent<MeshRenderer>().bounds.size;
        var buildingTrueCenterPosition = building.GetComponent<MeshRenderer>().bounds.center;
        var builingPointers = new List<BuildingPointer>();
        foreach (var direction in DirectionExtentions.GetDirectionEnumerable())
            if (GetCorrectBuildingBuildPoint(building, _currentBuilding, direction) != null)
                builingPointers.Add(_buildingPointersFactory.GetNewBuildPointer(direction, direction.ToVector3(), buildingTrueCenterPosition + buildingTrueSize));

        Debug.Log("Building Pointers Is Spawned");
        return builingPointers;
    }

    private MonoBehaviour SelectItem()
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
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                return hit.collider;
            }
            return null;
        }
    }

    private void SetCurrentBuilding()
    {
        if (BuildingWithChilds.IsBuildingWithChilds(_selectedBuilding))
        {
            var correctBuildPoint = GetCorrectBuildingBuildPoint((BuildingWithChilds)_selectedBuilding, _currentBuilding, _selectedBuildingPointer.Direction);
            if (correctBuildPoint != null)
            {
                _currentBuilding.SetSupportBuilding((BuildingWithChilds)_selectedBuilding, correctBuildPoint.BuildPosition);
            }
        }
    }

    private BuildPoint GetCorrectBuildingBuildPoint(BuildingWithChilds supportBuilding, Building childBuilding, Direction direction)
    {
        var a = supportBuilding.BuildPoints[direction];
        if (a != null)
        {
            foreach (var buildPoint in a)
            {
                if (buildPoint.WhiteList.Contains(_currentBuilding.BuildingType))
                {
                    return buildPoint;
                }
            }
        }
        return null;
    }

    private void SetCurrentBuildingPosition()
    {
        if (BuildingWithChilds.IsBuildingWithChilds(_selectedBuilding))
        {
            var correctBuildPoint = GetCorrectBuildingBuildPoint((BuildingWithChilds)_selectedBuilding, _currentBuilding, _selectedBuildingPointer.Direction);
            if (correctBuildPoint != null)
            {
                _currentBuilding.transform.position = correctBuildPoint.BuildPosition;
                Debug.Log("Current Building Position Is Seted");
            }
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
        _buildingFactory.DestroyBuilding(_currentBuilding);
        Reset();
        Debug.Log("Setting Building Is Declined");
    }

    public void Reset()
    {
        _currentBuilding = null;
        _selectedBuilding = null;
        _selectedBuildingPointer = null;
        _spawnedPointers.DestroyObjects();
        _selectedBuildingPointer = null;
        Debug.Log("Fields Is Reseted");
    }
}

