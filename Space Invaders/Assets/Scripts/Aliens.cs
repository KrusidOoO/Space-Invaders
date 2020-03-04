using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Aliens : MonoBehaviour
{
    public float speed = 10f;

    public Rigidbody2D rb2d;

    public Sprite startingImage;

    public Sprite AltImage;

    private new SpriteRenderer renderer;

    public float secBeforeChange = 0.5f;

    public GameObject AlienBullet;

    public float minFireRate = 1.0f;

    public float maxFireRate = 3.0f;

    public float baseFireRateWait = 3.0f;

    public Sprite explodedShipImage;
    // Start is called before the first frame update
    void Start()
    {
        Scene currentEditorScene = UnityEditor.SceneManagement.EditorSceneManager.GetActiveScene();
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene == SceneManager.GetSceneByName("Intro Screen") || currentEditorScene == UnityEditor.SceneManagement.EditorSceneManager.GetSceneByBuildIndex(0))
        {
            Debug.Log("Time is paused");
            Time.timeScale = 0;
        
        }
        else if (currentScene == SceneManager.GetSceneByName("Level 1") || currentEditorScene == UnityEditor.SceneManagement.EditorSceneManager.GetSceneByBuildIndex(1))
        {
            Debug.Log("Time is resumed");
            Time.timeScale = 1;
            rb2d = GetComponent<Rigidbody2D>();

            rb2d.velocity = new Vector2(1, 0) * speed;

            renderer = GetComponent<SpriteRenderer>();

            StartCoroutine(changeAlienSprite());

            baseFireRateWait = baseFireRateWait + Random.Range(minFireRate, maxFireRate);
        }

    }

    //Turn in opposite direction

    void Turn(int direction)
    {
        Vector2 newVelocity = rb2d.velocity;
        newVelocity.x = speed * direction;
        rb2d.velocity = newVelocity;
    }
    //Move down after hitting wall
    void MoveDown()
    {
        Vector2 position = transform.position;
        position.y -= 2;
        transform.position = position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name=="Left Wall")
        {
            Turn(1);
            MoveDown();
        }
        if(collision.gameObject.name=="Right Wall")
        {
            Turn(-1);
            MoveDown();
        }
        if(collision.gameObject.tag=="Bullet")
        {
            SoundManager.Instance.playOneShot(SoundManager.Instance.AlienDies);
            Destroy(gameObject);
        }
    }



    public IEnumerator changeAlienSprite()
    {
        while(true)
        {
            if(renderer.sprite==startingImage)
            {
                renderer.sprite = AltImage;
            }
            else
            {
                renderer.sprite = startingImage;
                SoundManager.Instance.playOneShot(SoundManager.Instance.AlienBuzz2);
            }

            yield return new WaitForSeconds(secBeforeChange);
        }
    }

    private void FixedUpdate()
    {
        if(Time.time>baseFireRateWait)
        {
            baseFireRateWait = baseFireRateWait + Random.Range(minFireRate, maxFireRate);

            Instantiate(AlienBullet, transform.position, Quaternion.identity);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            SoundManager.Instance.playOneShot(SoundManager.Instance.ShipExplosion);
            collision.GetComponent<SpriteRenderer>().sprite = explodedShipImage;
            Destroy(gameObject);
            Object.Destroy(collision.gameObject, 0.5f);
        }
    }
}
