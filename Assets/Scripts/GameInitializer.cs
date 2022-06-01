using UnityEngine;

public class GameInitializer : MonoBehaviour, IUpdatable
{
    [SerializeField]
    private Player _playerPrefab;

    private Player _player;
    
    [SerializeField]
    private Canvas _generalCanvas;

    [SerializeField] private MainUI _mainUIPrefab;

    [SerializeField] private GameField _gameField; 
    
    private void Update()
    {
        OnUpdate();
    }
    
    private void Start()
    {
        Initialize();
    }
    
    public void Initialize()
    {
        var mainUI = Instantiate(_mainUIPrefab, _generalCanvas.transform);
        mainUI.Initialize(_player);
        
        _player = Instantiate(_playerPrefab);
        _player.Initialize(_gameField, mainUI.transform);
    }

    public void OnUpdate()
    {
        _player.OnUpdate();
    }
}

