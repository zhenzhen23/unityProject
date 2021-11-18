using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletLogic : MonoBehaviour
{
    //public GameObject EndPanel;

    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.GetComponent<IsATarget>() != null)
        {
            SoundMgr.instance.PlayImpactSfx();

            Invoke("SelfDestruct", 0.1f);
            collision.gameObject.GetComponent<Rigidbody>().useGravity = true;
            Destroy(collision.gameObject.GetComponent<IsATarget>());
            Destroy(collision.gameObject.GetComponent<TargetMove1>());
            Destroy(collision.gameObject.GetComponent<TargetMove2>());


            if (collision.gameObject.GetComponent<ThreeMarkTarget>() != null)
            {
                ScoreMgr.instance.score+=3;
            }
            if (collision.gameObject.GetComponent<FiveMarkTarget>() != null)
            {   
                ScoreMgr.instance.score += 5;
            }
            if (collision.gameObject.GetComponent<TenMarkTarget>() != null)
            {
             ScoreMgr.instance.score += 10;
            }
        }
    }

    private void SelfDestruct()
    {
        Destroy(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SelfDestruct", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
