using Factories.Container;
using Container;
using UnityEngine;

public class Inventory
{
    private ItemsContainerFactory _itemsContainerFactory;

    private ItemsContainer _itemsContainer;
    public ItemsContainer ItemsContainer => _itemsContainer;
    
    public Inventory(ItemsContainerFactory itemsContainerFactory)
    {
        _itemsContainerFactory = itemsContainerFactory;
    }
    
    public void GenerateInventory()
    {
        _itemsContainer = _itemsContainerFactory.GetNewContainer();
        _itemsContainer.Initialize(
            GeneralGameSettings.ContainerSettings.MAX_HORIZONTAL_SIZE *
            GeneralGameSettings.ContainerSettings.DEFAULT_ROWS_COUNT);
    }
}
