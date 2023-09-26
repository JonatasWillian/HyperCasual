using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    public Vector2 pasPosition;
    public float velocity = 1f;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Move(Input.mousePosition.x - pasPosition.x);
        }
        pasPosition = Input.mousePosition;
    }

    public void Move(float speed)
    {
        transform.position += Vector3.right * Time.deltaTime * speed * velocity;
    }
}
