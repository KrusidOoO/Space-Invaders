using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance = null;

    public AudioClip AlienBuzz1;
    public AudioClip AlienBuzz2;
    public AudioClip AlienDies;
    public AudioClip BulletFire;
    public AudioClip ShipExplosion;

    private AudioSource soundEffectAudio;
    // Start is called before the first frame update
    void Start()
    {
        if(Instance==null)
        {
            Instance = this;
        }
        else if(Instance!=this)
        {
            Destroy(gameObject);
        }
        AudioSource theSource = GetComponent<AudioSource>();
        soundEffectAudio = theSource;
    }

    public void playOneShot(AudioClip clip)
    {
        soundEffectAudio.PlayOneShot(clip);
    }
        
        
}
