using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PowerUpHeight : PowerUpBase
{
    [Header("Power Up Height")]
    public float amountHeight = 2f;
    public float aniamtionDuration = .1f;
    public Ease ease = Ease.OutBack;

    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerController.Instance.ChangeHeight(amountHeight, duration, aniamtionDuration, ease);
        PlayerController.Instance.SetPowerText("Voando");
    }
}
