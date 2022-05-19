using UnityEngine;


[CreateAssetMenu(fileName = "InventoryViewFactory")]
public class InventoryViewFactory : ScriptableObject
{
    [SerializeField] private InventoryView _inventoryViewPrefab;
    
    public InventoryView GetNewInventoryView(Transform parentTransform)
    {
       var inventoryViewInstance = Instantiate(_inventoryViewPrefab, parentTransform);
       return inventoryViewInstance;
    }

}
