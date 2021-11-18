using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetScore : MonoBehaviour
{
    public GameObject global;

    Text score;
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
        score.text = "Score: " + ScoreMgr.instance.score;

    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + ScoreMgr.instance.score;
        if (ScoreMgr.instance.score > 20)
        {
            GameObject.Find("Global").SendMessage("normalLevel");
        }
        if (ScoreMgr.instance.score > 30)
        {
            GameObject.Find("Global").SendMessage("hardLevel");
        }
    }
}
