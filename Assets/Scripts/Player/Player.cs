using System.Collections.Generic;
using System.Drawing;
using Factories.Building;
using Factories.Container;
using Container;
using UnityEngine;

public sealed class Player: MonoBehaviour, IPlayer, IUpdatable
{
    
    [SerializeField] private ItemsContainerFactory _inventoryFactory;
    
    [SerializeField] private BuildingFactory _buildingFactory;

    [SerializeField] private BuildingPointersFactory _buildingPointersFactory;

    [SerializeField] private PlayerViewModel _playerViewModel;
    
    [SerializeField] private PlayerWithWorldInteraction _playerWithWorldInteraction;
    
    private List<IUpdatable> _contentToUpdate = new();

    private Inventory _inventory;
    public Inventory Inventory => _inventory;
    
    private Builder _builder;
    

    public void Initialize(Transform plyerUi)
    
    {
        _inventory = new Inventory(_inventoryFactory);
        _inventory.GenerateInventory();
        
        _builder = new Builder(new BuilderBehaviour(_buildingFactory, _buildingPointersFactory, Camera.main));
        _contentToUpdate.Add(_builder);

        _playerWithWorldInteraction.Initialize(_playerViewModel, plyerUi);
        _contentToUpdate.Add(_playerWithWorldInteraction);
        
        _playerViewModel.Initialize(_inventory, plyerUi.transform);
        _contentToUpdate.Add(_playerViewModel);
    }
    public void OnUpdate()
    {
        foreach (var content in _contentToUpdate)
        {
            content.OnUpdate();
        }
    }
    
}