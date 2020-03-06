using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlienBullet : BulletMain
{
        Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        Scene currentEditorScene = UnityEditor.SceneManagement.EditorSceneManager.GetActiveScene();
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene == SceneManager.GetSceneByName("Intro Screen") || currentEditorScene == SceneManager.GetSceneByName("Intro Screen"))
        {
            Debug.Log("Time is paused");
            Time.timeScale = 0;
        }
        else if (currentScene == SceneManager.GetSceneByName("Level 1") || currentEditorScene == SceneManager.GetSceneByName("Level 1"))
        {
            Debug.Log("Time resumed");
            Time.timeScale = 1;
            rb2d = GetComponent<Rigidbody2D>();
            GameObject[] healthObj = new GameObject[] {GameObject.Find("SpaceShipHealth_1"),GameObject.Find("SpaceShipHealth_2"),GameObject.Find("SpaceShipHealth_3") };

            rb2d.velocity = Vector2.down * speed;
            rb2d.velocity = Vector2.down * speed*Time.timeScale;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SoundManager.Instance.playOneShot(SoundManager.Instance.ShipExplosion);

            anim.SetTrigger();
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
}
