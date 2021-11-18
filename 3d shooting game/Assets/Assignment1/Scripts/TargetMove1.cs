using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class TargetMove1 : MonoBehaviour
{
    private float Speed = 10;
    bool right = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void MoveLeft()
    {
        this.transform.Translate(0.5f * Speed * Time.deltaTime * -Vector3.right, Space.Self);
        right = true;
    }

    public void MoveRight()
    { 

        this.transform.Translate(0.5f * Speed * Time.deltaTime * Vector3.right, Space.Self);
        right = false;
    }

    void Move()
    {
        if (right)
        {
            Invoke( "MoveRight",2f);
        }
        else
        {
            Invoke( "MoveLeft",2f);
        }
    }


    // Update is called once per frame
    void Update()
    {
        Move();

    }
}
