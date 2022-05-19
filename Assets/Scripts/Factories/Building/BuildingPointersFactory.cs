using System.Collections.Generic;
using UnityEngine;

namespace Factories.Building
{
    [CreateAssetMenu(fileName = "BuildingPointersFactory")]
    public class BuildingPointersFactory: ScriptableObject
    {
        [SerializeField] 
        private BuildingPointer _buildPointerPrefab;

        private Dictionary<Direction, Quaternion> _directionToRtation = new()
        {
            [Direction.Right] = new Quaternion(),
            [Direction.Left] = new Quaternion(),
            [Direction.Foward] = new Quaternion(),
            [Direction.Back] = new Quaternion(),
            [Direction.Up] = new Quaternion(),
            [Direction.Down] = new Quaternion()
        };

        public BuildingPointer GetNewBuildPointer(Direction direction, Vector3 offset, Vector3 spawnPosition)
        {
            var instance = Instantiate(_buildPointerPrefab, spawnPosition + offset, _directionToRtation[direction]).GetComponent<BuildingPointer>();
            instance.Initialize( direction);
            return instance;
        }
        public void DestroyBuildingPointer( BuildingPointer buildingPointer)
        {
            Destroy(buildingPointer.gameObject);
        }
    }
}