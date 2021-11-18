using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetScore : MonoBehaviour
{
    public GameObject WinPanel;
    public GameObject Global;

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
        CountScroe();
    }

    private void CountScroe()
    {
        if (ScoreMgr.instance.score >= 20)
        {

            WinPanel.gameObject.SetActive(true);
            Global.GetComponent<AudioSource>().mute = true;

        }
    }
}
