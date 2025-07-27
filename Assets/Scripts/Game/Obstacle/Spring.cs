using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    private Animator anim;
    public AudioSource source;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            source.Play();
            anim.SetBool("spring", true);
            collision.GetComponent<PlayerController>().Spring();
        }
    }
    public void EventSpring()
    {
        anim.SetBool("spring", false);
    }


}
