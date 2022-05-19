
using UnityEngine;

public class GameInitializer : MonoBehaviour, IUpdatable, IStartable
{
    [SerializeField]
    private Player _playerPrefab;

    private Player _player;
    
    [SerializeField]
    private Canvas _generalCanvas;

    [SerializeField] private MainUI _mainUIPrefab;
    
    private void Update()
    {
        OnUpdate();
    }
    
    private void Start()
    {
        OnStart();
    }
    
    public void OnStart()
    {
        var mainUI = Instantiate(_mainUIPrefab, _generalCanvas.transform);
        mainUI.Initialize(_player);
        
        _player = Instantiate(_playerPrefab);
        _player.Initialize(mainUI.transform);
        _player.OnStart();
    }

    public void OnUpdate()
    {
        _player.OnUpdate();
    }
}

