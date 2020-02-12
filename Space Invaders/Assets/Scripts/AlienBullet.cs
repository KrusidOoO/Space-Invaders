using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBullet : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float speed = 30f;
    public Sprite ExplodedShipImage;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        rb2d.velocity = Vector2.down * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Walls")
        {
            Destroy(gameObject);
        }
        if (collision.tag == "Player")
        {
            SoundManager.Instance.playOneShot(SoundManager.Instance.ShipExplosion);

            collision.GetComponent<SpriteRenderer>().sprite = ExplodedShipImage;

            Destroy(gameObject);
            Object.Destroy(collision.gameObject, 0.5f);
        }
        if(collision.tag=="Shield")
        {
            Destroy(gameObject);
            Object.Destroy(collision.gameObject);

        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
