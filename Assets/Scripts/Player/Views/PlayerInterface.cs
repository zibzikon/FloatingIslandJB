using UnityEngine;

public class PlayerInterface : MonoBehaviour
{
    [SerializeField] private Player _player;

    public void Initialize(Player player)
    {
        _player = player;
    }
}