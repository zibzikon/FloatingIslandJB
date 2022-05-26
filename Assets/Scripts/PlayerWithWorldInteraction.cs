using UnityEngine;

public class PlayerWithWorldInteraction : MonoBehaviour, IUpdatable
{
    private PlayerViewModel _playerViewModel;
    [SerializeField]private ContainerInteractionBehaviour _containerInteractionBehaviour;
    
    public void Initialize(Transform generalCanvas)
    {
    }

    public void OnUpdate()
    {
        _containerInteractionBehaviour.OnUpdate();
    }
}