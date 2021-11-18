using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMgr : MonoBehaviour
{
    public static SoundMgr instance;
    public AudioClip impactSfx;
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

    public void PlayImpactSfx()
    {
        if (asource != null)
        {
            if (impactSfx != null) {
                asource.PlayOneShot(impactSfx);
                asource.volume = 1;
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