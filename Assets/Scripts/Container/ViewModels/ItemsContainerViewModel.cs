using Container.VIews;

namespace Container.ViewModels
{
    public class ItemsContainerViewModel: ViewModelBehaviour, IUpdatable
    {
        private ItemsContainerView _itemsContainerView;
        public ItemsContainerView ItemsContainerView => _itemsContainerView;
        
        private ItemsContainer _itemsContainer;
        public ItemsContainer ItemsContainer => _itemsContainer;

        public override void Visualize()
        {
            for (int i = 0; i < _itemsContainer.Size; i++)
            {
                var itemType = _itemsContainer.Cells[i].CellContent.ItemType;
                _itemsContainerView.SetItem(itemType, i);
            }
        }

        public void Initialize(ItemsContainer itemsContainer, ItemsContainerView itemsContainerView)
        {
            _itemsContainer = itemsContainer;
            _itemsContainerView = itemsContainerView;
            _itemsContainer.ContainerChanged += Visualize;
            Visualize();
        }
       
        private void OnDisable()
        {
           _itemsContainer.ContainerChanged -= Visualize;
        }


        public void OnUpdate()
        {
        }
    }
}