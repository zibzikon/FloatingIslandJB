using System;
using System.Collections.Generic;
using Factories.Building;
using UnityEngine;

public abstract class Building : MonoBehaviour , IStartable, IRecyclable
{
    [SerializeField]
    private CollisionObject _collisionObject;
    public CollisionObject CollisionObject 
    {
        get
        {
            if (_collisionObject.Parent != null && _collisionObject.Parent != this) throw new InvalidOperationException("Collision parent dont equals true parent object");
            return _collisionObject;
        }
    } 

    public abstract BuildingType BuildingType { get; }

    public BuildingFactory OriginFactory { get; set; }

    private Building _supportBuilding;
    public Building SupportBuilding { get => _supportBuilding; }

    public void SetSupportBuilding(BuildingWithChilds supportBuilding, Vector3 position)
    {
        _supportBuilding = supportBuilding;
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