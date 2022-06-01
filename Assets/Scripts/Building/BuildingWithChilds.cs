using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(BuildPoints))]
public class BuildingWithChilds : Building, IUpdatable, IBuildingContainer
{
    private Neighbors<List<BuildPoint>> _buildPoints;
    
    private static readonly IEnumerable<BuildingType> BuildingTypesWithChilds = new[]
    {
        BuildingType.SupportPillar,
        BuildingType.Wall
    };
    
    private void Awake()
    {
        _buildPoints = GetComponent<BuildPoints>().Points;
    }


    public BuildPoint GetCorrectBuildPoint(Building building, Direction3 direction)
    {
        var buildPoints = _buildPoints[direction];
        return buildPoints?.FirstOrDefault(buildPoint => buildPoint.WhiteList.Contains(building.BuildingType));
    }
    
    public void SetBuildPointsPosition()
    {
        for (int i = 0; i < 6; i++)
        {
            foreach (var buildPoint in _buildPoints[i])
            {
                buildPoint.SetPosition(this.PositionOnGameField);
            }
        }
    }
    
    public virtual void OnUpdate()
    {
    }
    
    public static bool IsBuildingWithChilds(Building building)
    {
        return BuildingTypesWithChilds.Contains(building.BuildingType);
    }
    
}

