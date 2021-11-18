using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            Spawn();

        }

    }

    public void Spawn()
    {
        Instantiate(obj, this.transform.position, this.transform.rotation);

    }

    // Update is called once per frame
    void Update()
    {
        SpawnLogicUpdate();
    }
}
