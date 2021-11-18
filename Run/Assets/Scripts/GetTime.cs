using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetTime : MonoBehaviour
{
    public GameObject global;

    Text time;
    // Start is called before the first frame update
    void Start()
    {
        time = GetComponent<Text>();
        time.text = "Time: " + TimeMgr.instance.time + " S";

    }

    // Update is called once per frame
    void Update()
    {
        time.text = "Time: " + TimeMgr.instance.time + " S";
    }
}
