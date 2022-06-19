using System;
using UnityEngine.Events;

public interface IDiethable
{
    public UnityEvent Died { get; }

    public void Die();

}
