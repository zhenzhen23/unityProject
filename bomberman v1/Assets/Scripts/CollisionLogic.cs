using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionLogic : MonoBehaviour
{
    private Animator anim;
    private Rigidbody emery_rigidbody;
    private int[] rotation = { 90, 180, 270 };
    private float time = 0;
    private Vector3 lastPo;
    private Vector3 CurrentPo;

    private void LockPosition()
    {
        //face 0 and 180 check z
        if (anim.transform.eulerAngles.y.Equals(0))
        {


            emery_rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY
                | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX;

        }

        //face 90 and 270 check x
        if (anim.transform.eulerAngles.y.Equals(90))
        {
            Rigidbody player = anim.GetComponent<Rigidbody>();
            if (player.velocity == Vector3.zero)
            {
                // do idle animations
                //Debug.Log("not move");
            }
            emery_rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY
                | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;

        }

        if (anim.transform.eulerAngles.y.Equals(180))
        {
            Rigidbody player = anim.GetComponent<Rigidbody>();
            if (player.velocity == Vector3.zero)
            {
                // do idle animations
                //Debug.Log("not move");
            }

            if (CurrentPo.x - lastPo.x > -1 && CurrentPo.x - lastPo.x < 1)
            {
                //Debug.Log("Blocked");
            }

            emery_rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY
                | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX;

        }

        if (anim.transform.eulerAngles.y.Equals(270))
        {
            Rigidbody player = anim.GetComponent<Rigidbody>();
            if (player.velocity == Vector3.zero)
            {
                // do idle animations
                //Debug.Log("not move");
            }
            emery_rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY
                 | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<IsBlock>() != null || collision.gameObject.GetComponent<IsBomb>() != null)
        {
            lastPo = anim.transform.position;
            Invoke("CheckNotMove", 1f);
            Invoke("checkBlock", 1f);
            this.gameObject.GetComponent<Animator>().transform.Rotate(Vector3.up, rotation[UnityEngine.Random.Range(0, 2)]);

        }

        if (collision.gameObject.GetComponent<IsEnemy>() != null)
        {
            emery_rigidbody.detectCollisions = false;
            Invoke("SetCollision", 0.5f);
        }
    }

    private void SetCollision()
    {
        emery_rigidbody.detectCollisions = true;
    }

    public void CheckNotMove()
    {

        CurrentPo = anim.transform.position;

    }

    public void checkBlock()
    {
        if (anim.transform.eulerAngles.y.Equals(0) || anim.transform.eulerAngles.y.Equals(180))
        {
            int oldZ = (int)Math.Floor(lastPo.z);
            int newZ = (int)Math.Floor(CurrentPo.z);
            if (oldZ == newZ)
            {
                this.gameObject.GetComponent<Animator>().transform.Rotate(Vector3.up, 180);
            }
        }
        else
        {
            int oldX = (int)Math.Floor(lastPo.x);
            int newX = (int)Math.Floor(CurrentPo.x);
            if (oldX == newX)
            {
                this.gameObject.GetComponent<Animator>().transform.Rotate(Vector3.up, 180);
            }
        }



    }

    // Start is called before the first frame update
    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
        emery_rigidbody = anim.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        LockPosition();
    }
}
