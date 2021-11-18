using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetTime : MonoBehaviour
{
    Text time;
    public Slider s;
    void Start()
    {
        time = GetComponent<Text>();
        time.text = "Time: " + s.value;
    }

    // Update is called once per frame
    public void update()
    {
        time = GetComponent<Text>();
        time.text = "Time: " + s.value;
    }
}
