using System;
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
    
    [SerializeField] private PlayerWithWorldInteraction _playerWithWorldInteraction;
    
    private List<IUpdatable> _contentToUpdate = new();

    private Inventory _inventory;
    public Inventory Inventory => _inventory;
    
    private Builder _builder;
    

    public void Initialize(GameField.GameField gameField,Transform plyerUi)
    {
        _builder = new Builder(new BuilderBehaviour(gameField, _buildingFactory, _buildingPointersFactory, Camera.main));
        _contentToUpdate.Add(_builder);
    }
    public void OnUpdate()
    {
        foreach (var content in _contentToUpdate)
        {
            content.OnUpdate();
        }
    }

    private void Update()
    {
        
    }
}