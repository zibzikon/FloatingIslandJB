using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public abstract class BuildingWithChilds : Building, IUpdatable
{
    public abstract Neighbors<List<BuildPoint>> BuildPoints { get; }
    protected abstract void InitializeBuildPoints();

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

