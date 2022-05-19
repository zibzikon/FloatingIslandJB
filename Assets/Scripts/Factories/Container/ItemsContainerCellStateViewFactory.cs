using System;
using Enums;
using UnityEngine;

namespace Factories.Container
{
    [CreateAssetMenu (fileName = "ItemsContainerCellViewStateFactory", menuName = "Factories/Container/ItemsContainerCellViewStateFactory")]
    public class ItemsContainerCellStateViewFactory: ScriptableObject
    {
        [SerializeField] private Sprite _default;
        [SerializeField] private Sprite _selected;
        
        public Sprite GetNewCellStateView(CellState cellState)
        {
            return cellState switch
            {
                CellState.Default => _default,
                CellState.Selected => _selected,
                _ => throw new NullReferenceException()
            };
        }
    }
}