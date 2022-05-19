using System;
using System.Collections.Generic;
using UnityEngine;
public class SupportPillar : BuildingWithChilds
{
    [SerializeField]
    private Transform _wallBuildPositionTransform;
    [SerializeField]
    private Transform _nextSupportPillarBuildTransform;
    public override BuildingType BuildingType => BuildingType.SupportPillar;

    private Neighbors<List<BuildPoint>> _buildPoints = new Neighbors<List<BuildPoint>>();
    public override Neighbors<List<BuildPoint>> BuildPoints => _buildPoints;

    protected override void InitializeBuildPoints()
    {
        _buildPoints.Up = new List<BuildPoint> { new BuildPoint(new BuildingType[] { BuildingType.SupportPillar }, _nextSupportPillarBuildTransform.position) };
        _buildPoints.Foward = new List<BuildPoint> { new BuildPoint(new BuildingType[] { BuildingType.SupportPillar }, _nextSupportPillarBuildTransform.position )};
    }
}
