using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLogic : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<IsTarget>() != null)
        {
            // if target is enemy, minus 1
            if (collision.gameObject.GetComponent<IsEnemy>() != null)
            {
                ResultMgr.instance.enemy--;
                ScoreMgr.instance.score = (int)ScoreMgr.instance.score + 100;
                SoundMgr.instance.PlayKillSfx();
            }

            // if target is character, lose game
            if (collision.gameObject.GetComponent<IsCharacter>() != null)
            {
                ResultMgr.instance.InGamePanel.SetActive(false);
                ResultMgr.instance.losePanel.SetActive(true);

                // hide the scene objects
                ResultMgr.instance.snene.SetActive(false);
              

                SoundMgr.instance.PlayFailSfx();

                // todo: hide in-game panel

            }

            Destroy(collision.gameObject);
        }
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
