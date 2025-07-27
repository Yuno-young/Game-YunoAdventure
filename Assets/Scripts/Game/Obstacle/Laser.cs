using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public Animator anim;
    private SpriteRenderer spriteRen;

    public Sprite lockOn;

    private void Awake()
    {
        spriteRen = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerController.instance.item.Play();
            anim.SetTrigger("close");
            spriteRen.sprite = lockOn;
        }
    }
}
