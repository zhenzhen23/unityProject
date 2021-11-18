using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruct : MonoBehaviour
{
    private void SelfDestruct()
    {
        Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SelfDestruct", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
