using System;
using System.Collections.Generic;
using UnityEngine;
public class GameField : MonoBehaviour, IStartable
{
    private Cell[] _cells;
    private Vector3Int _size = new (10, 10, 10); 
    public void OnStart()
    {
        GenerateGameField();
    }
    private void GenerateGameField()
    {
        for (int y = 0, i = 0; y < _size.y; y++)
        {
            for (int z = 0; z < _size.z; z++)
            {
                for (int x = 0; x < _size.x; x++,i++)
                {
                    var currentCell = _cells[i] = new Cell();
                    if (y > 0)
                    {
                        Cell.SetUpDownNeighbours(currentCell, _cells[i - (_size.y + _size.z)]);
                    }
                    if (z > 0)
                    {
                        Cell.SetFowardBackNeighbours(currentCell, _cells[i - _size.x]);
                    }
                    if (x > 0)
                    {
                        Cell.SetRightLeftNeighbours(currentCell, _cells[i - 1]);
                    }
                }
            }
        }
    }
    public Cell GetCellByPosition(Vector3Int position)
    {
        return null;
    }
}

