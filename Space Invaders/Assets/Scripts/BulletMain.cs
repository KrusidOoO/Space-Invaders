using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMain : MonoBehaviour
{
    protected Rigidbody2D rb2d;
    public float speed = 30f;
    public Sprite sprite;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Walls")
        {
            Destroy(gameObject);
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
