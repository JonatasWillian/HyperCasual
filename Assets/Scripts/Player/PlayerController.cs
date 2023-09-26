using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;

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

    private bool _canRun;
    private Vector3 _pos;
    private float _currentSpeed;

    private void Start()
    {
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
            EndGame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag(tagEndLine))
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        endScreen.SetActive(true);
        _canRun = false;
    }

    public void StartToRun()
    {
        _canRun = true;
    }

    #region PowerUps
    public void PowerUpSpeedUp(float f)
    {
        _currentSpeed = f;
    }

    public void ResetSpeed()
    {
        _currentSpeed = speed;
    }
    #endregion
}
