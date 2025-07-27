using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    public GameObject door;

    private SpriteRenderer spr;
    private BoxCollider2D coll;

    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerController.instance.item.Play();

            door.SetActive(true);
            spr.enabled = false;
            coll.enabled = false;
        }
    }
}
