using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeView : MonoBehaviour
{
    private Text displayTimeTxt;
    float totalTime = 120f;
    // Start is called before the first frame update
    void Start()
    {
        displayTimeTxt = GetComponentInChildren<Text>(true);
        displayTimeTxt.text = "Time : " + totalTime;
    }

    private void TimeViewUpdate()
    {

        if(ResultMgr.instance.winPanel.activeSelf == false)
        {
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
