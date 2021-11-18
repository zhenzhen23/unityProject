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
    public int enemy = 3;
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
            snene.SetActive(false);
            InGamePanel.SetActive(false);
        }
    }

    private void checkWinByEnemyNum()
    {
        if (ResultMgr.instance.enemy <= 0)
        {

            Invoke("setWinPanel", 1f);
            // todo: hide in-game panel

        }
    }

    private void setWinPanel()
    {
        ResultMgr.instance.winPanel.SetActive(true);
        ResultMgr.instance.InGamePanel.SetActive(false);
        // hide the scene objects
        ResultMgr.instance.snene.SetActive(false);

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
        checkWinByEnemyNum();
    }
}
