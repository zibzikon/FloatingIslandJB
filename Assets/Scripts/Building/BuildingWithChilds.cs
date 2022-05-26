using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
[RequireComponent(typeof(BuildPoints))]
public class BuildingWithChilds : Building, IUpdatable
{
    public Neighbors<List<BuildPoint>> BuildPoints { get; private set; }
    
    private static readonly IEnumerable<BuildingType> BuildingTypesWithChilds = new[]
    {
        BuildingType.SupportPillar,
        BuildingType.Wall
    };

    private void Awake()
    {
        BuildPoints = GetComponent<BuildPoints>().Points;
    }

    public virtual void OnUpdate()
    {
    }
    public static bool IsBuildingWithChilds(Building building)
    {
        return BuildingTypesWithChilds.Contains(building.BuildingType);
    }
}

