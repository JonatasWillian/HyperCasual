using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BounceHelperPowerUp : MonoBehaviour
{
    [Header("Animation")]
    public float scaleDuration = .2f;
    public float scaleBounce = 1.2f;
    public Ease ease = Ease.OutBack;
    public Transform targetTrasform;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            BouncePlayerPowerUp();
        }
    }

    public void BouncePlayerPowerUp()
    {
        targetTrasform.DOScale(scaleBounce, scaleDuration).SetEase(ease).SetLoops(2, LoopType.Yoyo);
    }
}
