using Container.VIews;
using Factories.Container;
using UnityEngine;
public class InventoryView : MonoBehaviour
{
    [SerializeField] private ItemsContainerViewFactory _itemsContainerViewFactory;
    
    [SerializeField] private Transform _itemsContainerParentTransform;

    private ItemsContainerView _itemsContainerView;
  
    public ItemsContainerView ItemsContainerView => _itemsContainerView;
    
    public void Initialize(int size)
    {
        _itemsContainerView = _itemsContainerViewFactory.GetNewItemsContainerView(_itemsContainerParentTransform);
        _itemsContainerView.Initialize(size);
    }
}
