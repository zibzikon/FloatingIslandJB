using Container;
using Container.VIews;
using UnityEngine;
using UnityEngine.Serialization;

namespace Factories.Container
{
    [CreateAssetMenu(fileName = "ItemsContainerViewFactory")]
    public class ItemsContainerViewFactory : ScriptableObject
    {
       [SerializeField] private ItemsContainerView itemsContainerViewPrefab;
        public ItemsContainerView GetNewItemsContainerView(Transform parentTransform)
        {
            var containerViewInstance = Instantiate(itemsContainerViewPrefab, parentTransform);
            return containerViewInstance;
        }
    }
}