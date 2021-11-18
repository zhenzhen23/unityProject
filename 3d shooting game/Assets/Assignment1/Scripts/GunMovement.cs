using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMovement : MonoBehaviour
{
    public Vector2 axis;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ShipMovementUpdate()
    {
        axis.x = Input.GetAxis("Horizontal");
        axis.y = Input.GetAxis("Vertical");


        this.transform.Translate(-moveSpeed * axis.x * Vector3.forward, Space.Self);
        if (this.transform.position.y > 1)
        {
            this.transform.Translate(moveSpeed * axis.y * Vector3.up, Space.Self);
        }
        else
        {
            this.transform.localPosition = Vector3.MoveTowards(this.transform.localPosition, new Vector3(this.transform.position.x, 2, this.transform.position.z), moveSpeed * 0.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        ShipMovementUpdate();
    }
}
