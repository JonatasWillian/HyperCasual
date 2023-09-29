using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;
using TMPro;
using DG.Tweening;

public class PlayerController : Singleton<PlayerController>
{
    [Header("Lerp")]
    public Transform target;
    public float lerSpeed = 1f;

    [Header("Move Forward")]
    public float speed = 1f;

    [Header("Tag Enemy")]
    public string tagEnemy = "Enemy";
    public string tagEndLine = "EndLine";

    public GameObject endScreen;

    [Header("Text")]
    public TextMeshPro uiTextPowerUp;

    [Header("Coin Collector")]
    public GameObject coinCollector;

    public bool invencible = true;

    private bool _canRun;
    private Vector3 _pos;
    private float _currentSpeed;
    private Vector3 _startPosition;


    private void Start()
    {
        _startPosition = transform.position;
        ResetSpeed();
    }

    void Update()
    {
        if (!_canRun) return;

        _pos = target.position;
        _pos.y = transform.position.y;
        _pos.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, _pos, lerSpeed * Time.deltaTime);
        transform.Translate(transform.forward * _currentSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag(tagEnemy))
        {
            if(!invencible) EndGame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag(tagEndLine))
        {
            EndGame();
        }
    }

    private void EndGame(bool b = true)
    {
        endScreen.SetActive(true);
        _canRun = false;
    }

    public void StartToRun()
    {
        _canRun = true;
    }

    #region PowerUps
    public void SetPowerText(string s)
    {
        uiTextPowerUp.text = s;
    }

    public void PowerUpSpeedUp(float f)
    {
        _currentSpeed = f;
    }

    public void ResetSpeed()
    {
        _currentSpeed = speed;
    }

    public void SetInvencible(bool b = true)
    {
        invencible = b;
    }

    public void ChangeHeight(float amount, float duration, float animationDuration, Ease ease)
    {
        //var p = transform.position;
        //p.y = _startPosition.y + amount;
        //transform.position = p;

        transform.DOMoveY(_startPosition.y + amount, animationDuration).SetEase(ease);
        Invoke(nameof(ResetHeight), duration);
    }

    public void ResetHeight()
    {
        transform.DOMoveY(_startPosition.y, .1f);
        StartCoroutine(ResetText());
    }

    public float durationCoroutine = .6f;

    IEnumerator ResetText()
    {
        yield return new WaitForSeconds(durationCoroutine);
        PlayerController.Instance.SetPowerText("");
    }

    public void ChangeCoiCollectorSize(float amount)
    {
        coinCollector.transform.localScale = Vector3.one * amount;
    }
    #endregion
}
