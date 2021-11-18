using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// on bomb - spawn fire and self destruct
public class BombLogic : MonoBehaviour
{
    public GameObject fire1;
    public GameObject fire2;
    public GameObject fire3;

    private void SelfDestruct()
    {
        Destroy(this.gameObject);
        PowerUpMgr.instance.maxBombNumber++;
    }

    public void Spawn1()
    {
        SoundMgr.instance.PlayBombSfx();
        Instantiate(fire1, this.transform.position, this.transform.rotation);
    }
    public void Spawn2()
    {
        Instantiate(fire2, this.transform.position, this.transform.rotation);
    }
    public void Spawn3()
    {
        Instantiate(fire3, this.transform.position, this.transform.rotation);
    }

    // When the character leaves the bomb, he cannot go through the bomb
    private void OnTriggerExit(Collider collider)
    {
        this.gameObject.GetComponent<SphereCollider>().isTrigger = false;       
    }    

    // Start is called before the first frame update
    void Start()
    {

        Invoke("SelfDestruct", 2.4f);
        Invoke("Spawn1", 2.1f);
        
        if (PowerUpMgr.instance.isBoosted == false)
        {
            Invoke("Spawn2", 2.2f);
        }
        else
        {
            Invoke("Spawn3", 2.2f);
        }      
    }

    // Update is called once per frame
    void Update()
    {

    }
}
