using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    private Animator anim;
    public KeyCode jump;
    public KeyCode slide;
    public KeyCode punch;
    public KeyCode kick;
    public GameObject endPanel;
    public GameObject inGamePanel;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }


    private void PlayerLogicUpdate()
    {
        if (Input.GetKeyDown(jump) == true)
        {
            anim.SetTrigger("jump");
            SoundMgr.instance.PlayJumpSound();
        }

        if (Input.GetKeyDown(slide) == true)
        {
            anim.SetTrigger("slide");
            SoundMgr.instance.PlaySlideSound();
        }

        if (Input.GetKeyDown(punch) == true)
        {
            anim.SetTrigger("punch");
        }

        if (Input.GetKeyDown(kick) == true)
        {
            anim.SetTrigger("kick");
        }

    }

    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.GetComponent<IsBlock>() != null)
        {
            //SoundMgr.instance.PlayImpactSfx();

            endPanel.gameObject.SetActive(true);
            inGamePanel.gameObject.SetActive(false);

            anim.SetTrigger("stand");
            GameObject.Find("jasper").SendMessage("stopCounting");

        }

    }

    // Update is called once per frame
    void Update()
    {
        PlayerLogicUpdate();
    }
}
