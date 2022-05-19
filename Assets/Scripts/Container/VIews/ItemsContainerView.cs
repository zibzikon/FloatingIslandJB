using System;
using System.Collections.Generic;
using Enums;
using Factories.Container;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Container.VIews
{
    public class ItemsContainerView : MonoBehaviour, IUpdatable
    {
        [SerializeField] private GridLayoutGroup _cellsContainerView;
        [SerializeField] private ItemsContainerCellViewFactory _itemsContainerCellViewFactory;
        [SerializeField] private ItemViewFactory _itemViewFactory;
        
        public CellView[] CellViews;

        public void Initialize(int length)
        {
            CellViews = new CellView[length];
            GenerateContainer();
        }

        public void OnUpdate()
        {
        }

        public void SetItem(ItemType itemType, int index)
        {
            if (index >= CellViews.Length)
            {
                throw new IndexOutOfRangeException();
            }

            var cellView = CellViews[index].CellContentView;
            cellView.Sprite = _itemViewFactory.GetItemView(itemType).Sprite;
            
            cellView.VisibilityType = itemType == ItemType.Empty ? VisibilityType.Invisible : VisibilityType.Visible;
        }
        
        private void GenerateContainer()
        {
            for (int i = 0; i < CellViews.Length; i++)
            {
                CellViews[i] = _itemsContainerCellViewFactory.GetNewContainerCellView(ItemType.Empty, _cellsContainerView.transform);
            }
        }
        
        private CellView GetClickedCell()
        {
            foreach (var cell in CellViews)
            {
                if(RectTransformUtility.RectangleContainsScreenPoint(cell.GetComponent<RectTransform>(), Input.mousePosition))
                {
                    Debug.Log("asdas");
                    return cell;
                }
            }

            return null;
        }


    }
}