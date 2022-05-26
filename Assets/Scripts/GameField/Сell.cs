using UnityEngine;

namespace GameField
{
    public class Cell
    {
        public Vector3Int Position { get; }
        public Vector3 WorldPosition => Position * GeneralGameSettings.GameFieldSettings.WorldPositionMultiplier;
        private Neighbors<Cell> _neighbours = new();

        private Building _building;

        public Cell(Vector3Int position)
        {
            Position = position;
        }

        public Building Building
        {
            get => _building;
            set
            {
                if (_building != null)
                {
                    _building.Recycle();
                }
                _building = value;
            }
        }

        public static void SetRightLeftNeighbours(Cell right, Cell left)
        {
            right._neighbours.Left = left;
            left._neighbours.Right = right;
        }
        public static void SetFowardBackNeighbours(Cell foward, Cell back)
        {
            foward._neighbours.Back = back;
            back._neighbours.Foward = foward;
        }
        public static void SetUpDownNeighbours(Cell up, Cell down)
        {
            up._neighbours.Down = down;
            down._neighbours.Up = up;
        }
    }
}

