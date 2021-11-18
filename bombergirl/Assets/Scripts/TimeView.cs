using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// On InGamePanel.Time
public class TimeView : MonoBehaviour
{
    private Text displayTimeTxt;
    float totalTime;
    // Start is called before the first frame update
    void Start()
    {
        if (ResultMgr.instance.snene.activeSelf == true)
        {
            TimeMgr.instance.time = (int)120f;
        }
        else{
            TimeMgr.instance.time = (int)240f;
        }
        totalTime = TimeMgr.instance.time;
        displayTimeTxt = GetComponentInChildren<Text>(true);
        displayTimeTxt.text = "Time : " + totalTime;
    }

    private void TimeViewUpdate()
    {

        if (ResultMgr.instance.winPanel.activeSelf == false)
        {
            if(ResultMgr.instance.NextStagePanel.activeSelf == true)
            {
                Debug.Log("we do update the time");
                totalTime = 240f;
            }
           
            totalTime -= 1 * Time.deltaTime;
            displayTimeTxt.text = "Time : " + totalTime.ToString("0");
            TimeMgr.instance.time = (int)totalTime;
            if (totalTime <= 0)
            {
                TimeMgr.instance.time = 0;
                displayTimeTxt.text = "Time : 0";
            }

            if (totalTime <= 10)
            {
                displayTimeTxt.color = Color.red;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        TimeViewUpdate();
    }
}
