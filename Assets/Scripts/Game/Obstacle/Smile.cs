using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smile : MonoBehaviour
{
    public float moveSpeed;

    private float leftCap;
    private float rightCap;

    private int dir = 1;

    public float range;

    private void Start()
    {
        leftCap = transform.position.x - range;
        rightCap = transform.position.x + range;
    }
    void Update()
    {
        transform.Translate(Vector2.right * moveSpeed * dir * Time.deltaTime);

        if (transform.position.x < leftCap)
        {
            dir = 1;
            transform.localScale = new Vector3(-1, 1, 1) * .5f;
        }
        if(transform.position.x > rightCap)
        {
            dir = -1;
            transform.localScale = new Vector3(1, 1, 1) * .5f;
        }
    }
}
