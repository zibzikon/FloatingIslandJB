using System.Linq;
using Extentions;
using UnityEngine;


    public class GameField : MonoBehaviour
    {
        private Cell[,,] _cells;
        private Vector3Int _size = new (10, 10, 10);
        [SerializeField] private GameFieldCellView _cellViewPrefab;
        [SerializeField] private Transform _debugObjectTransform;
        
        private void Start()
        {
            GenerateGameField();
        }
        private void GenerateGameField()
        {
            _cells = new Cell[_size.x , _size.y , _size.z];
            for (int y = 0; y < _size.y; y++)
            {
                for (int z = 0; z < _size.z; z++)
                {
                    for (int x = 0; x < _size.x; x++)
                    {
                        var positionMultiplier = GeneralGameSettings.GameFieldSettings.WorldPositionMultiplier;
                        var currentCell = _cells[x,y,z] = new Cell(new Vector3Int(x,y,z));
                        
                        if (GeneralGameSettings.DebugMode)
                        {
                            var cellView = Instantiate(_cellViewPrefab,
                                new Vector3(x*positionMultiplier,y*positionMultiplier,z*positionMultiplier),
                                Quaternion.identity,_debugObjectTransform);
                        
                            cellView.Initialize(currentCell);

                        }
                       
                        if (y > 0)
                        {
                            Cell.SetUpDownNeighbours(currentCell, _cells[x,y-1,z]);
                        }
                        if (z > 0)
                        {
                            Cell.SetFowardBackNeighbours(currentCell, _cells[x,y,z-1]);
                        }
                        if (x > 0)
                        {
                            Cell.SetRightLeftNeighbours(currentCell, _cells[x-1,y,z]);
                        }
                    }
                }
            }
        }
        public Cell GetCellByPosition(Vector3Int position)
        {
            return _cells[position.x, position.y, position.z];
        }
        public Cell GetCellByWorldPosition(Vector3 position)
        {
            var correctPosition = position.RoundToVector3Int() / GeneralGameSettings.GameFieldSettings.WorldPositionMultiplier;
            return _cells[correctPosition.x, correctPosition.y, correctPosition.z];
        }
    }

