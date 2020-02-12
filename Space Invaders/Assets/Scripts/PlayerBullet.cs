using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBullet : MonoBehaviour
{
    public float speed = 30f;
    private Rigidbody2D rb2d;

    public Sprite explodedAlienImage;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        rb2d.velocity = Vector2.up * speed;



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Walls")
        {
            Destroy(gameObject);
        }

        if(collision.tag=="Alien")
        {
            SoundManager.Instance.playOneShot(SoundManager.Instance.AlienDies);

            IncreaseTextUIScoreAlien();

            collision.GetComponent<SpriteRenderer>().sprite = explodedAlienImage;
            Destroy(gameObject);

            Object.Destroy(collision.gameObject, 0.1f);
            collision.transform.gameObject.tag = "AlienExploded";
        }
        if (collision.tag == "Alien2")
        {
            SoundManager.Instance.playOneShot(SoundManager.Instance.AlienDies);

            IncreaseTextUIScoreAlien2();

            collision.GetComponent<SpriteRenderer>().sprite = explodedAlienImage;

            Destroy(gameObject);

            Object.Destroy(collision.gameObject, 0.1f);
            collision.transform.gameObject.tag = "AlienExploded";
        }
        if (collision.tag == "Alien3")
        {
            SoundManager.Instance.playOneShot(SoundManager.Instance.AlienDies);

            IncreaseTextUIScoreAlien3();

            collision.GetComponent<SpriteRenderer>().sprite = explodedAlienImage;

            Destroy(gameObject);

            Object.Destroy(collision.gameObject, 0.1f);
            collision.transform.gameObject.tag = "AlienExploded";
        }
        if (collision.tag == "Alien4")
        {
            SoundManager.Instance.playOneShot(SoundManager.Instance.AlienDies);

            IncreaseTextUIScoreAlien4();

            collision.GetComponent<SpriteRenderer>().sprite = explodedAlienImage;

            Destroy(gameObject);

            Object.Destroy(collision.gameObject, 0.1f);
            collision.transform.gameObject.tag = "AlienExploded";
        }
        if(collision.tag=="AlienExploded")
        {
            Destroy(gameObject.GetComponent<PlayerBullet>());
        }

        if (collision.tag=="Shield")
        {
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void IncreaseTextUIScoreAlien()
    {
        var textUIComp = GameObject.Find("Score Text").GetComponent<Text>();

        int score = int.Parse(textUIComp.text);

        score += 10;

        

        textUIComp.text = score.ToString();
    }
    void IncreaseTextUIScoreAlien2()
    {
        var textUIComp = GameObject.Find("Score Text").GetComponent<Text>();

        int score = int.Parse(textUIComp.text);

        score += 20;



        textUIComp.text = score.ToString();
    }
    void IncreaseTextUIScoreAlien3()
    {
        var textUIComp = GameObject.Find("Score Text").GetComponent<Text>();

        int score = int.Parse(textUIComp.text);

        score += 30;



        textUIComp.text = score.ToString();
    }
    void IncreaseTextUIScoreAlien4()
    {
        var textUIComp = GameObject.Find("Score Text").GetComponent<Text>();

        int score = int.Parse(textUIComp.text);

        score += 40;



        textUIComp.text = score.ToString();
    }
}
