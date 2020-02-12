using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBullet : BulletMain
{
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        rb2d.velocity = Vector2.down * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SoundManager.Instance.playOneShot(SoundManager.Instance.ShipExplosion);

            collision.GetComponent<SpriteRenderer>().sprite = sprite;

            Destroy(gameObject);
            Object.Destroy(collision.gameObject, 0.5f);
        }
        if(collision.tag=="Shield")
        {
            Destroy(gameObject);
            Object.Destroy(collision.gameObject);

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
