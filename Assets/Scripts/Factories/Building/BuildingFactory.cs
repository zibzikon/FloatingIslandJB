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

        public void DestroyBuilding(global::Building building)
        {
            Destroy(building);
        }

        private global::Building GetNewBuilding(global::Building prefab)
        {
            var instance = Instantiate(prefab);
            instance.OriginFactory = this;
            return instance;
        }

    
    }
}
