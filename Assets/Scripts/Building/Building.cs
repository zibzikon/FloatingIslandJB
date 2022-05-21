using System;
using System.Collections.Generic;
using Factories.Building;
using UnityEngine;

public class Building : MonoBehaviour , IStartable, IRecyclable
{
    [SerializeField]
    private CollisionObject _collisionObject;
    public CollisionObject CollisionObject 
    {
        get
        {
            if (_collisionObject.Parent != null && _collisionObject.Parent != this) 
                throw new InvalidOperationException("Collision parent dont equals true parent object");
            return _collisionObject;
        }
    }
    
    [SerializeField] private BuildingType _buildingType;
    public BuildingType BuildingType => _buildingType;
    
    public Building SupportBuilding { get; private set; }

    public void SetSupportBuilding(BuildingWithChilds supportBuilding, Vector3 position)
    {
        SupportBuilding = supportBuilding;
        this.transform.position = position;
    }

    public virtual void OnStart()
    {
        throw new NotImplementedException();
    }

    public void Recycle()
    {
        Destroy(this.gameObject);
    }
}