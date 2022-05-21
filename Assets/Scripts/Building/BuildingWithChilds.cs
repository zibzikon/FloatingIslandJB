using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
[RequireComponent(typeof(Neighbors<List<BuildPoint>>))]
public class BuildingWithChilds : Building, IUpdatable
{
    public Neighbors<List<BuildPoint>> BuildPoints { get; private set; }
    
    private void InitializeBuildPoints()
    {
        BuildPoints = GetComponent<Neighbors<List<BuildPoint>>>();
    }

    public static readonly IEnumerable<BuildingType> BuildingTypesWithChilds = new[]
    {
        BuildingType.SupportPillar,
        BuildingType.Wall
    };

    public override void OnStart()
    {
        InitializeBuildPoints();
    }
    public virtual void OnUpdate()
    {
    }
    public static bool IsBuildingWithChilds(Building building)
    {
        return BuildingTypesWithChilds.Contains(building.BuildingType);
    }
}

