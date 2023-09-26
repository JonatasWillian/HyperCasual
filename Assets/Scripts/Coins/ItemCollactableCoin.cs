using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollactableCoin : ItemCollactableBase
{
    public Collider collider;

    private void Start()
    {
        CoinsAnimationManager.Instance.RegisterCoin(this);
    }

    protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.Instance.AddCoins();
        collider.enabled = false;
    }
}
