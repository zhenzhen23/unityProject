using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public GameObject openDoor;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void checkEnemy()
    {
        if (ResultMgr.instance.enemy <= 0)
        {
            Destroy(this.gameObject);
            Instantiate(openDoor, this.transform.position, this.transform.rotation);
        }
    }



    // Update is called once per frame
    void Update()
    {
        checkEnemy();
    }
}
