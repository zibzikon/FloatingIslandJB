using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class EnumerableExtentions
{

    public static void DestroyObjects(this IEnumerable<MonoBehaviour> monoBehaviours)
    {
        foreach (var behaviour in monoBehaviours)
        {
            UnityEngine.Object.Destroy(behaviour);
        }
    }
}

