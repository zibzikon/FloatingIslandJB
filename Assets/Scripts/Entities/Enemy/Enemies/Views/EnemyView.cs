using UnityEngine;

public class EnemyView : MonoBehaviour
{
    private Enemy _enemyModel;
    
    public void Initialize(Enemy model)
    {
        _enemyModel = model;
    }
}
