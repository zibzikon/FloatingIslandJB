using System;
using Container;
using Container.ViewModels;
using Container.VIews;
using Enums;
using UnityEngine;

public class ContainerInteractionBehaviour : MonoBehaviour, IUpdatable
{
    private Transform _generalCanvas;
    private ItemsContainerViewModel _containerViewModel;
    
    private Container.Cell _selectedCell;
    private CellContent _currentCellContent;
    private CellContentView _selectedCellContentViewVisualize;

    private CellView _selectedCellView;
    private CellView _lastSelectedCellView;

    public void OnUpdate()
    {
        var selectedCellView = GetClickedCellView();
       
        if (_lastSelectedCellView != null)
        {
            _lastSelectedCellView.SetCellViewState(CellState.Default);
        }
        
        if (selectedCellView == null) return;
        if (Input.GetMouseButtonDown(0))
        {
            _selectedCell = GetClickedCell();
            
            var tempCurrentCellContent = new CellContent();
            tempCurrentCellContent.SetContent(_selectedCell.CellContent);
            
            if (_currentCellContent != null)
            {
                tempCurrentCellContent.SetContent(_currentCellContent);
               _currentCellContent.SetContent(_selectedCell.CellContent);
               _containerViewModel.ItemsContainer.SetCellContent(_selectedCell, tempCurrentCellContent); 
            }
            else
            {
                _currentCellContent = tempCurrentCellContent;
                _containerViewModel.ItemsContainer.ResetCellContent(_selectedCell);
            } 
        }
        else
        {
            selectedCellView.SetCellViewState(CellState.Selected);
        }

        _lastSelectedCellView = selectedCellView;
    }
    
    public void Initialize(Transform generalCanvas, ItemsContainerViewModel itemsContainerViewModel)
    {
        _generalCanvas = generalCanvas;
        _containerViewModel = itemsContainerViewModel;
    }
    
    private Container.Cell GetClickedCell()
    {
        var cellViews = _containerViewModel.ItemsContainerView.CellViews;
        foreach (var cellView in cellViews)
        {
            if(RectTransformUtility.RectangleContainsScreenPoint(cellView.GetComponent<RectTransform>(), Input.mousePosition))
            {
                var selectedCellView = GetClickedCellView();

                return _containerViewModel.ItemsContainer.Cells[
                        Array.IndexOf(_containerViewModel.ItemsContainerView.CellViews, selectedCellView)];
            }
        }
        
        return null;
    }
    
    private CellView GetClickedCellView()
    {
        var cellViews = _containerViewModel.ItemsContainerView.CellViews;
        foreach (var cellView in cellViews)
        {
            if(RectTransformUtility.RectangleContainsScreenPoint(cellView.GetComponent<RectTransform>(), Input.mousePosition))
            {
                return cellView;
            }
        }
        
        return null;
    }
    
}
