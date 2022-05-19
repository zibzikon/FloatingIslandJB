using Enums;
using Factories.Container;
using UnityEngine;
using UnityEngine.UI;

namespace Container.VIews
{
    public class CellView : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private ItemsContainerCellStateViewFactory _stateViewFactory;

        public void SetCellViewState(CellState cellState)
        {
            _image.sprite = _stateViewFactory.GetNewCellStateView(cellState);
        }
        public CellContentView CellContentView { get; set; }
    }
}

