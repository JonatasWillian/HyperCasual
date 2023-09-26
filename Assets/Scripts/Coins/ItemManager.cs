using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Core.Singleton;
using TMPro;

public class ItemManager : Singleton<ItemManager>
{
    //public int currentPoints;

    //public Player player;

    [Header("Points")]
    public SOInt coins;
    public SOInt diamonds;

    [Header("Tags")]
    public string tagToCoin = "Coin";
    public string tagToDiamond = "Diamond";
    
    /*[Header("TextMesh")]
    public TextMeshProUGUI uiTextPointsCoin;
    public TextMeshProUGUI uiTextPointsDiamond;*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == tagToCoin)
        {
            AddCoins();
        }

        if (collision.transform.tag == tagToDiamond)
        {
            AddDiamond();
        }
    }

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        coins.value = 0;
        diamonds.value = 0;
        UpDateUI();
    }

    public void AddCoins(int coin = 1)
    {
        coins.value += coin;
        UpDateUI();
    }

    public void AddDiamond(int diamond = 10)
    {
        diamonds.value += diamond;
        UpDateUI();
    }


    public void UpDateUI()
    {
        //uiTextPointsCoin.text = coins.ToString();
        //uiTextPointsDiamond.text = diamonds.ToString();

        //UIInGameManager.UpdateTextCoins(coins.value.ToString());
        //UIInGameManager.UpdateTextDiamond(diamonds.value.ToString());
    }
}
