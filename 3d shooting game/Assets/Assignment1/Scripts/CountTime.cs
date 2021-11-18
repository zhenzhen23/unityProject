using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountTime : MonoBehaviour
{
    public Slider s;
    Text time;
    float gameTime;
    public GameObject EndPanel;
    public GameObject Global;

    // Start is called before the first frame update
    void Start()
    {
        gameTime = s.value;
        time = GetComponent<Text>();
        time.text = "Time: " + gameTime;
        InvokeRepeating("Time_count", 1.0f, 1.0F);
    }

    void Time_count()
    {
        int score = 0;
        score = Global.GetComponent<ScoreMgr>().score;
        if (gameTime < 0 && score < 20)
        {
            CancelInvoke();
            EndPanel.gameObject.SetActive(true);
            Global.GetComponent<AudioSource>().mute = true;
        }
        else
        {

            gameTime--;
            GetComponent<Text>().text = "Time: " + gameTime;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
