using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMgr : MonoBehaviour
{
    public static SoundMgr instance;
    public AudioClip dropSfx;
    public AudioClip bombSfx;
    public AudioClip killSfx;
    public AudioClip winSfx;
    public AudioClip failSfx;

    private AudioSource asource;

    public void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);

        // create the audiosource if we need it
        if (asource == null)
        {
            asource = this.gameObject.AddComponent<AudioSource>();
            if (asource)
            {
                asource.playOnAwake = false;
            }
        }
    }

    public void PlayDropSfx()
    {
        if(asource != null)
        {
            if(dropSfx != null)
            {
                asource.PlayOneShot(dropSfx);
            }
        }
    }

    public void PlayBombSfx()
    {
        if (asource != null)
        {
            if (bombSfx != null)
            {
                asource.PlayOneShot(bombSfx);
            }
        }
    }

    public void PlayWinSfx()
    {
        if (asource != null)
        {
            if (winSfx != null)
            {
                asource.PlayOneShot(winSfx);
            }
        }
    }

    public void PlayFailSfx()
    {
        if (asource != null)
        {
            if (failSfx != null)
            {
                asource.PlayOneShot(failSfx);
            }
        }
    }


    public void PlayKillSfx()
    {
        if (asource != null)
        {
            if (killSfx != null)
            {
                asource.PlayOneShot(killSfx);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
