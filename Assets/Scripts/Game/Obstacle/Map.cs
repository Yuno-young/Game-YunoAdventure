using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public Transform startPos;

    private void Start()
    {
        PlayerController.instance.transform.position = startPos.position;
    }
}
