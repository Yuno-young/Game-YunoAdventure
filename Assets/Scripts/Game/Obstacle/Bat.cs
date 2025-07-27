using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    public float moveSpeed;

    private float leftCap;
    private float rightCap;

    private int dir = 1;

    public float range;

    private void Start()
    {
        leftCap = transform.position.y - range;
        rightCap = transform.position.y + range;
    }
    void Update()
    {
        transform.Translate(Vector2.up * moveSpeed * dir * Time.deltaTime);

        if (transform.position.y < leftCap)
        {
            dir = 1;
        }
        if (transform.position.y > rightCap)
        {
            dir = -1;
        }
    }
}
