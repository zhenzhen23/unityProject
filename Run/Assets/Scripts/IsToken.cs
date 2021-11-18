using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsToken : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Invoke("SelfDestruct", 0.1f);
        SoundMgr.instance.PlayTokenSound();

        if (this.gameObject.GetComponent<BlueToken>() != null)
        {
            ScoreMgr.instance.score += 3;
        }
        else if(this.gameObject.GetComponent<RedToken>() != null)
        {
            ScoreMgr.instance.score += 5;
        }

    }

    private void SelfDestruct()
    {
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
