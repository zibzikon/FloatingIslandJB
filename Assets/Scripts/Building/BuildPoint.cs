using System;
using System.Collections.Generic;
using UnityEngine;
public class BuildPoint: MonoBehaviour
{
    [SerializeField] private List<BuildingType> _whiteList;
    public List<BuildingType> WhiteList => _whiteList;
    
    [SerializeField] private Transform _buildTransform;
    public Vector3 BuildPosition => _buildTransform.position;
    
}

