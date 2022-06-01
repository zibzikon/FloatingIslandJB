using System;
using UnityEngine;

namespace Factories.Building
{
    [CreateAssetMenu(fileName = "BuildingFactory")]
    public class BuildingFactory : ScriptableObject
    {
        [SerializeField]private global::Building _supportPillarPrefab;
        public void Reclaim(global::Building building)
        {
            building.Recycle();
            Destroy(building.gameObject);
        }
        public global::Building GetNewBuilding(BuildingType type)
        {
            switch (type)
            {
                case BuildingType.SupportPillar:
                    return GetNewBuilding(_supportPillarPrefab);
            }
            
            throw new NullReferenceException();
        }

        private global::Building GetNewBuilding(global::Building prefab)
        {
            var instance = Instantiate(prefab);
            return instance;
        }

    
    }
}
