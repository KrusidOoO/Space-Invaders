using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 30f;


    public GameObject PlayerBullet;
    protected CharacterController2D1 controller2D;
    // Start is called before the first frame update

    void FixedUpdate()
    {
        float HorzMove = Input.GetAxisRaw("Horizontal");

        GetComponent<Rigidbody2D>().velocity = new Vector2(HorzMove, 0) * speed;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            Instantiate(PlayerBullet, transform.position, Quaternion.identity);

            SoundManager.Instance.PlayOneShot(SoundManager.Instance.BulletFire);
        }
    }
}
