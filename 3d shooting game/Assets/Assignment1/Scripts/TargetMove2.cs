using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMove2 : MonoBehaviour
{
    private float Speed = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void MoveUp()
    {

        this.transform.Translate(-0.5f * Speed * Time.deltaTime * Vector3.forward, Space.Self);
    }

    // Update is called once per frame
    void Update()
    {
       Invoke( "MoveUp",4f);
    }
}
