using System;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof( Transform))]
public class BuildPoint: MonoBehaviour
{
    [SerializeField] private List<BuildingType> _whiteList;
    public List<BuildingType> WhiteList => _whiteList;

    public Vector3 BuildPosition { get; private set; }

    private void Awake()
    {
        BuildPosition = GetComponent<Transform>().position;
    }
}

