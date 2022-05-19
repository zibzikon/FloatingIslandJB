using Container.ViewModels;
using UnityEngine;

public class InventoryViewModel : ViewModelBehaviour, IUpdatable
{

    private InventoryView _inventoryView;
    public InventoryView InventoryView => _inventoryView;
    
    private Inventory _inventoryModel;
    public Inventory InventoryModel => _inventoryModel;

    [SerializeField] private InventoryViewFactory _inventoryViewFactory;
    
    [SerializeField] private ItemsContainerViewModel _itemsContainerViewModel;
    public ItemsContainerViewModel ItemsContainerViewModel => _itemsContainerViewModel;
    
    public void Initialize(Inventory inventoryModel, Transform inventoryViewTransform)
    {
        _inventoryModel = inventoryModel;
        _inventoryView = _inventoryViewFactory.GetNewInventoryView(inventoryViewTransform);
        _inventoryView.Initialize(inventoryModel.ItemsContainer.Size);
        _itemsContainerViewModel.Initialize(_inventoryModel.ItemsContainer, _inventoryView.ItemsContainerView);
    }
    
    public override void Visualize()
    {
      
    }
    
    public void OnUpdate()
    {
        _itemsContainerViewModel.OnUpdate();
    }
}
