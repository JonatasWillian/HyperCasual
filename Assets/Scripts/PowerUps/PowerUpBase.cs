using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBase : ItemCollactableBase
{
    [Header("Power Up duration")]
    public float duration;

    protected override void Collect()
    {
        base.Collect();
        StartPowerUp();
    }

    protected virtual void StartPowerUp()
    {
        Debug.Log("Start PowerUp");
        Invoke(nameof(EndPowerUp), duration);
    }

    protected virtual void EndPowerUp()
    {
        Debug.Log("End PowerUp");
    }
}
