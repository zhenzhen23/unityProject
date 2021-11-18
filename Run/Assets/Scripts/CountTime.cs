using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountTime : MonoBehaviour
{
    public GameObject global;

    bool count = true;

    Text time;
    // Start is called before the first frame update
    void Start()
    {
       
        InvokeRepeating("TimeCount", 1.0f, 1.0F);

    }

    void TimeCount()
    {
        if (count) {
            TimeMgr.instance.time += 1;
        }
    }

    public void stopCounting()
    {
        count = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
