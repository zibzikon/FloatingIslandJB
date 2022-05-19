using UnityEngine;

public class PlayerWithWorldInteraction : MonoBehaviour, IUpdatable
{
    private PlayerViewModel _playerViewModel;
    [SerializeField]private ContainerInteractionBehaviour _containerInteractionBehaviour;
    
    public void Initialize(PlayerViewModel playerViewModel, Transform generalCanvas)
    {
        _containerInteractionBehaviour.Initialize(generalCanvas, playerViewModel.InventoryViewModel.ItemsContainerViewModel);
    }

    public void OnUpdate()
    {
        _containerInteractionBehaviour.OnUpdate();
    }
}