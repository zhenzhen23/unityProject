using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

// On fire - interaction with all objects touched by fire
public class FireLogic : MonoBehaviour
{
    public GameObject door;
    //public GameObject anim;

    public void OnCollisionEnter(Collision collision)
    {
        //collision.gameObject.GetComponent<MeshCollider>().enabled = false;
        if (collision.gameObject.GetComponent<IsTarget>() != null)
        {
            
            Destroy(collision.gameObject.GetComponent<IsEnemy>());

            // if target is enemy, minus 1
            if (collision.gameObject.GetComponent<IsEnemy>() != null)
            {
               
                if (ResultMgr.instance.Stage2.activeSelf == true)
                {
                    ResultMgr.instance.stage2Enemy--;
                }
                else
                {
                    ResultMgr.instance.enemy--;
                }
                ScoreMgr.instance.score = (int)ScoreMgr.instance.score + 100;
                SoundMgr.instance.PlayKillSfx();
            }
            // when target is a not an enemy
            if (collision.gameObject.GetComponent<IsEnemy>() == null)
            {
                
                // generate power-up here
                Vector3 position = collision.gameObject.transform.position;
                PowerUpMgr.instance.GeneratePowerUp(position);
            }

            if (collision.gameObject.GetComponent<isHiddenDoor>() != null)
            {
                Instantiate(door, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            }
            Destroy(collision.gameObject);
        }

        // if target is character, lose game
        if (collision.gameObject.GetComponent<IsCharacter>() != null)
        {

        }
    }
    public void setLostPanel()
    {
        ResultMgr.instance.InGamePanel.SetActive(false);
        ResultMgr.instance.losePanel.SetActive(true);
        ResultMgr.instance.mainCamera.SetActive(true);

        // hide the scene objects
        ResultMgr.instance.snene.SetActive(false);
        ResultMgr.instance.Stage2.SetActive(false);

        SoundMgr.instance.PlayFailSfx();
        // todo: hide in-game panel
    }

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
    }
}
