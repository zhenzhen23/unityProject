using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultMgr : MonoBehaviour
{
    public static ResultMgr instance;
    public GameObject startPanel;
    public GameObject winPanel;
    public GameObject losePanel;
    public GameObject snene;
    public GameObject InGamePanel;
    public GameObject NextStagePanel;
    public GameObject Stage2;
    public GameObject mainCamera;
    public int enemy = 3;
    public int stage2Enemy = 1;
    private bool isOver;

    public void Awake()
    {
        // only keep the first copy of this script around
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    public void ResultInfoUpdate()
    {
        if (TimeMgr.instance.time == 0)
        {
            SoundMgr.instance.PlayFailSfx();
            losePanel.SetActive(true);
            mainCamera.SetActive(true);
            snene.SetActive(false);
            InGamePanel.SetActive(false);
        }
    }

    public void checkWinByEnemyNum()
    {
        if (ResultMgr.instance.stage2Enemy <= 0)
        {

            Invoke("setWinPanel", 1f);
            // todo: hide in-game panel

        }
    }

    public void setWinPanel()
    {
        ResultMgr.instance.winPanel.SetActive(true);
        ResultMgr.instance.InGamePanel.SetActive(false);
        ResultMgr.instance.mainCamera.SetActive(true);
        // hide the scene objects
        ResultMgr.instance.snene.SetActive(false);
        ResultMgr.instance.Stage2.SetActive(false);

        SoundMgr.instance.PlayWinSfx();
    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ResultInfoUpdate();
        //checkWinByEnemyNum();
    }
}
