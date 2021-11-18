using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLogic : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Move()
    {
        if (anim != null)
        {         
            // walk fwd if 'w' key is down
            if (Input.GetKey(KeyCode.W))
            {
                this.transform.rotation = Quaternion.Euler(0, 0, 0);
                anim.SetBool("Walking", true);
            }
            else if(Input.GetKey(KeyCode.A))
            {
                this.transform.rotation = Quaternion.Euler(0,-90,0);
                anim.SetBool("Walking", true);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                this.transform.rotation = Quaternion.Euler(0, 90, 0);
                anim.SetBool("Walking", true);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                this.transform.rotation = Quaternion.Euler(0, 180, 0);
                anim.SetBool("Walking", true);
            }
            else
            {
                anim.SetBool("Walking", false);
            }

        }
    }

    // when character hits an ememy, game over
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<IsEnemy>() != null)
        {
            //Debug.Log("hit and die!");
            ResultMgr.instance.losePanel.SetActive(true);

            // hide the scene objects
            ResultMgr.instance.snene.SetActive(false);

            ResultMgr.instance.InGamePanel.SetActive(false);

            // todo: hide in-game panel

        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
