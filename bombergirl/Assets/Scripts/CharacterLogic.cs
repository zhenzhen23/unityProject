using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// On character - interact with enemy and game booster
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
    public void setLostPanel()
    {
        //Debug.Log("hit and die!");
        ResultMgr.instance.losePanel.SetActive(true);

        // hide the scene objects
        ResultMgr.instance.snene.SetActive(false);
        ResultMgr.instance.Stage2.SetActive(false);
        ResultMgr.instance.InGamePanel.SetActive(false);
        ResultMgr.instance.mainCamera.SetActive(true);
        // todo: hide in-game panel
    }

    // when character hits an ememy, game over
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<IsEnemy>() != null)
        {
            Destroy(collision.gameObject);
            anim.SetTrigger("isDeath");
            Invoke("setLostPanel", 3f);

        }

        if (collision.gameObject.GetComponent<isFire>() != null)
        {
            Debug.Log("get !!!!!!!!!!!!!");
            anim.SetTrigger("isDeath");
            Invoke("setLostPanel", 3f);
        }


        //first level 
        if (collision.gameObject.GetComponent<IsDoor>() != null)
        {
            if(ResultMgr.instance.enemy <= 0)
            {
                setNextStagePanel();
                Destroy(collision.gameObject);
            }

            //check second level
            if (ResultMgr.instance.Stage2.activeSelf == true)
            {
                Debug.Log("this is second level");

                if (ResultMgr.instance.stage2Enemy <= 0)
                {
                    Debug.Log("go to here!");
                    ResultMgr.instance.winPanel.SetActive(true);
                    ResultMgr.instance.InGamePanel.SetActive(false);
                    ResultMgr.instance.mainCamera.SetActive(true);
                    // hide the scene objects
                    ResultMgr.instance.snene.SetActive(false);
                    ResultMgr.instance.Stage2.SetActive(false);

                    SoundMgr.instance.PlayWinSfx();
                    Destroy(collision.gameObject);
                }
            }
        }


        if (collision.gameObject.GetComponent<IsSpeeder>() != null)
        {
            anim.speed += 1;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.GetComponent<IsDoubleBombs>() != null)
        {
            PowerUpMgr.instance.maxBombNumber++;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.GetComponent<IsBooster>() != null)
        {
            PowerUpMgr.instance.isBoosted = true;
            Destroy(collision.gameObject);
        }
    }

    private void setNextStagePanel()
    {
        Debug.Log("go to next");
        ResultMgr.instance.NextStagePanel.SetActive(true);
        ResultMgr.instance.snene.SetActive(false);
        // hide the scene objects
        

        Invoke("setNextStage", 2f);
    }

    private void setNextStage()
    {
        ResultMgr.instance.NextStagePanel.SetActive(false);
        ResultMgr.instance.Stage2.SetActive(true);
        anim.speed -= 1;
        PowerUpMgr.instance.maxBombNumber--;
        PowerUpMgr.instance.isBoosted = false;

        // todo: set toolNum to 3

        // todo: set wall number to the num in the second level
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
