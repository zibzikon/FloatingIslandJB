using Container;
using Container.VIews;
using UnityEngine;
using UnityEngine.Serialization;

namespace Factories.Container
{
    [CreateAssetMenu (fileName = "ItemsContainerCellContentViewFactory")]
    public class ItemsContainerCellContentViewFactory: ScriptableObject
    {
        [SerializeField] private ItemViewFactory _itemViewFactory; 
        [SerializeField] private CellContentView cellContentViewPrefab;
        
        public CellContentView GetNewContainerCellContentView(ItemType itemType, Transform instanceParent)
        {
            var itemView =_itemViewFactory.GetItemView(itemType);
            var cellContentView = Instantiate(cellContentViewPrefab, instanceParent);
            cellContentView.Sprite = itemView.Sprite;
            return cellContentView;
        }
    }
}