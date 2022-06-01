using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Extentions;

public class Testing : MonoBehaviour
{ 
   [SerializeField]private Vector3Int position;
   [SerializeField] private Direction2 _direction;
   [SerializeField] private Direction2 _settingDirection;

   private void Awake()
   {
       transform.position = position;
   }

   private void Update()
   {
       if (Input.GetMouseButtonDown(0))
       {
           position = position.SetDirection(_direction, _settingDirection);
           _direction = _settingDirection;
           transform.position = position;
       }
   }
}
