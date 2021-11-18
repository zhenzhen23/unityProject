using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombLogic : MonoBehaviour
{
    public GameObject fire1;
    public GameObject fire2;
    public GameObject fire3;

    private void SelfDestruct()
    {
        SoundMgr.instance.PlayBombSfx();
        Destroy(this.gameObject);
        BombMgr.instance.isSpawned = false;
    }

    public void Spawn1()
    {
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
        Invoke("Spawn2", 2.2f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
