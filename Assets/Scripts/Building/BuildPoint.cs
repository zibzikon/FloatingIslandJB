using System;
using System.Collections.Generic;
using UnityEngine;
public class BuildPoint
{
    public readonly IEnumerable<BuildingType> WhiteList;
    public readonly Vector3 BuildPosition;
    public BuildPoint(BuildingType[] whiteList, Vector3 buildPosition)
    {
        WhiteList = whiteList;
        BuildPosition = buildPosition;
    }
}

