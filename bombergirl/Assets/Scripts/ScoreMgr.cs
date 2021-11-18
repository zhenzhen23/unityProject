using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMgr : MonoBehaviour
{
    public int score;
    public static ScoreMgr instance;
    // Start is called before the first frame update

    public void Awake()
    {
        // only keep the first copy of this script around
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
