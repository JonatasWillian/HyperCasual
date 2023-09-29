using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSpeedUp : PowerUpBase
{
    [Header("Power Speed Up")]
    public float amountToSpeed;

    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerController.Instance.PowerUpSpeedUp(amountToSpeed);
        PlayerController.Instance.SetPowerText("velocidade");
    }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerController.Instance.ResetSpeed();
        PlayerController.Instance.SetPowerText("");
    }
}
