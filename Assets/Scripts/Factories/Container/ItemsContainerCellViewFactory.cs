using Container;
using Container.VIews;
using UnityEngine;
using UnityEngine.Serialization;

namespace Factories.Container
{
    [CreateAssetMenu (fileName = "ItemsContainerCellViewFactory")]
    public class ItemsContainerCellViewFactory: ScriptableObject
    {
        [SerializeField] private ItemsContainerCellContentViewFactory _cellContentViewFactory;
        [SerializeField] private CellView cellViewPrefab;
        
        public CellView GetNewContainerCellView(ItemType itemType, Transform instanceParent)
        {
            var cellViewInstance = Instantiate(cellViewPrefab, instanceParent);
            cellViewInstance.CellContentView  = _cellContentViewFactory.GetNewContainerCellContentView(itemType, cellViewInstance.transform);
            
            return cellViewInstance;
        }
    }
}