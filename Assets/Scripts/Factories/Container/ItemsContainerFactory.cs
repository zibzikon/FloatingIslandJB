using Container;
using UnityEngine;

namespace Factories.Container
{
    [CreateAssetMenu(fileName = "ItemsContainerFactory")]
    public class ItemsContainerFactory : ScriptableObject
    {
        public ItemsContainer GetNewContainer()
        {
            var container = new ItemsContainer();
            return container;
        }
    }
}