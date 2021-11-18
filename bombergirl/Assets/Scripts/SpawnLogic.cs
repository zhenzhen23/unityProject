using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// on character - spawn bomb
public class SpawnLogic : MonoBehaviour
{
    public GameObject obj;
    public KeyCode keyToPress;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void SpawnLogicUpdate()
    {
        // check for keypress
        if (Input.GetKeyDown(keyToPress))
        {
            if (PowerUpMgr.instance.maxBombNumber == 0)
            {
                return;
            }
            Spawn();
        }

    }
   
    public void Spawn()
    {
        SoundMgr.instance.PlayDropSfx();
        Instantiate(obj,this.transform.position, this.transform.rotation);
        PowerUpMgr.instance.maxBombNumber--;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnLogicUpdate();
    }
}
