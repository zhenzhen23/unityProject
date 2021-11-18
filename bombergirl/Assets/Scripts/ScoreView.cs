using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    private Text displayScoreTxt;
    // Start is called before the first frame update
    void Start()
    {
        displayScoreTxt = GetComponentInChildren<Text>(true);
    }

    private void ScoreViewUpdate()
    {
        if (displayScoreTxt)
        {
            displayScoreTxt.text = "Score : " + ScoreMgr.instance.score;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ScoreViewUpdate();
    }
}
