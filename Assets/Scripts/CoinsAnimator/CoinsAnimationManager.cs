using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;
using DG.Tweening;

public class CoinsAnimationManager : Singleton<CoinsAnimationManager>
{
    public List<ItemCollactableCoin> itens;

    [Header("Animation")]
    public float scaleDuration = .2f;
    public float scaleTimeBeTweenPieces = .1f;
    public Ease ease = Ease.OutBack;

    private void Start()
    {
        itens = new List<ItemCollactableCoin>();
    }
    public void RegisterCoin(ItemCollactableCoin i)
    {
        if(!itens.Contains(i))
        {
            itens.Add(i);
            i.transform.localScale = Vector3.zero;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            StartAniamtion();
        }
    }

    public void StartAniamtion()
    {
        StartCoroutine(ScalePiecesByTime());
    }

    IEnumerator ScalePiecesByTime()
    {
        itens.RemoveAll(i => i.Equals(null));

        foreach (var p in itens)
        {
            p.transform.localScale = Vector3.zero;
        }

        Sort();

        yield return null;

        for (int i = 0; i < itens.Count; i++)
        {
            itens[i].transform.DOScale(1, scaleDuration).SetEase(ease);
            yield return new WaitForSeconds(scaleTimeBeTweenPieces);
        }
    }

    private void Sort()
    {
        itens = itens.OrderBy(x => Vector3.Distance(this.transform.position, x.transform.position)).ToList();
    }
}
