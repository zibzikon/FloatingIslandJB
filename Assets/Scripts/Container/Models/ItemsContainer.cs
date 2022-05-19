using System;
using Factories.Container;

namespace Container
{
    public class ItemsContainer
    {
        public event Action ContainerChanged;
        
        private Cell[] _cells;
        public Cell[] Cells => _cells;

        public int Size => _cells.Length;
        
        private ItemsContainerCellContentFactory cellContentFactory;

        public Cell SelectCell(int index)
        {
            if (index >= Size)
            {
                throw new IndexOutOfRangeException();
            }
            return Cells[index];
        }

        public void SetCellContent(Cell cell, CellContent cellContent)
        {
            cell.CellContent.SetContent(cellContent.Item, cellContent.ItemType);
            ContainerChanged?.Invoke();
        }
        
        public void ResetCellContent(Cell cell)
        {
            cell.CellContent.SetContent(null, ItemType.Empty);
            ContainerChanged?.Invoke();
        }
        
        public void Initialize(int size)
        {
            cellContentFactory = new ItemsContainerCellContentFactory();
            Generate(size);
        }

        private void Generate(int size)
        {
            Cell[] cells = new Cell[size];
            for (int i = 0; i < size; i++)
            {
                if (i % 3 == 0)
                {
                    cells[i] = new Cell(cellContentFactory.GetNewContainerCellContent(new Random().Next(0,1) == 0?ItemType.Stone:ItemType.Wood));
                }
                else
                {
                    cells[i] = new Cell(cellContentFactory.GetNewContainerCellContent(ItemType.Empty));
                }
            }

            _cells = cells;
        }
    }
}