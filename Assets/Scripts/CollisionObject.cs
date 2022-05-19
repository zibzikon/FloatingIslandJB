using System;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider))]
public class CollisionObject : MonoBehaviour
{
    public Collider Collider => GetComponent<Collider>();
    
    [SerializeField]
    private MonoBehaviour _parent;
    public MonoBehaviour Parent => _parent;
}

