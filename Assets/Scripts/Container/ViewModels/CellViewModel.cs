using Container.VIews;

namespace Container.ViewModels
{
    public class CellViewModel
    {
        private Cell _cellModel;
        public Cell CellModel => _cellModel;
        
        private CellView _cellView;
        public CellView CellView => _cellView;
    }
}