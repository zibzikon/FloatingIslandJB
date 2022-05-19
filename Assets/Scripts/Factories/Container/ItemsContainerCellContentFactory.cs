using System;
using Container;

namespace Factories.Container
{
    public class ItemsContainerCellContentFactory 
    {
        public CellContent GetNewContainerCellContent(ItemType itemType)
        {
            switch (itemType)
            {
                case ItemType.Empty: return GetNewContainerCellContent(null, itemType);
                case ItemType.Stone: return GetNewContainerCellContent(new Stone(), itemType);
                case ItemType.Wood: return GetNewContainerCellContent(new Wood(), itemType);
            }

            throw new NullReferenceException();
        }

        private CellContent GetNewContainerCellContent(Item item, ItemType itemType)
        {
            return new CellContent(item, itemType);
        }
    }
}