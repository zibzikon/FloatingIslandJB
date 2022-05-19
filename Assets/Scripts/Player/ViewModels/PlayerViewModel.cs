using UnityEngine;
using UnityEngine.Serialization;

public class PlayerViewModel : MonoBehaviour, IUpdatable
{
    [SerializeField] private InventoryViewModel _inventoryViewModel;
    public InventoryViewModel InventoryViewModel => _inventoryViewModel;

    public void Initialize(Inventory inventoryModel, Transform parentTransform)
    {
        _inventoryViewModel.Initialize(inventoryModel, parentTransform);
    }

    public void OnUpdate()
    {
        _inventoryViewModel.OnUpdate();
    }
}
 