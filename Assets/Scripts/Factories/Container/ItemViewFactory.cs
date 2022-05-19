using System;
using Container.VIews;
using UnityEngine;

namespace Factories.Container
{
    [CreateAssetMenu(fileName = "ItemViewFactory")]

    public class ItemViewFactory : ScriptableObject
    {
        [SerializeField] private ItemView _empty;
        [SerializeField] private ItemView _stone;
        [SerializeField] private ItemView _wood;

        public ItemView GetItemView(ItemType itemType)
        {
            switch (itemType)
            {
                case ItemType.Empty: return GetItemView(_empty);
                case ItemType.Stone: return GetItemView(_stone);
                case ItemType.Wood: return GetItemView(_wood);
            }

            throw new NullReferenceException();
        }
        
        private ItemView GetItemView(ItemView inventoryCellContentView)
        {
            return inventoryCellContentView;
        }
    }
}