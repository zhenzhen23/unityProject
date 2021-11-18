using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMgr : MonoBehaviour
{
    public static SoundMgr instance;

    public AudioClip jump;
    public AudioClip slide;
    public AudioClip token;
    private AudioSource asource;

    void Start()
    {

    }

    public void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);

        if (asource == null)
        {
            asource = this.gameObject.AddComponent<AudioSource>();
            if (asource)
            {
                asource.playOnAwake = false;
            }
        }
    }

    public void PlayJumpSound()
    {
        if (asource != null)
        {
            if (jump != null)
            {
                asource.PlayOneShot(jump);
            }
        }
    }

    public void PlaySlideSound()
    {
        if (asource != null)
        {
            if (slide != null)
            {
                asource.PlayOneShot(slide);
            }
        }
    }

    public void PlayTokenSound()
    {
        if (asource != null)
        {
            if (token != null)
            {
                asource.PlayOneShot(token);
            }
        }
    }

    void Update()
    {

    }
}