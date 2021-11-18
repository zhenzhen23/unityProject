using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMgr : MonoBehaviour
{
    public static PowerUpMgr instance;
    public bool isSpeeded = false;
    public int maxBombNumber = 1;
    public bool isBoosted = false;
    public int blockNum = 20;
    public int toolNum = 1;

    public GameObject speeder;
    public GameObject doubleBomb;
    public GameObject booster;

    public void Awake()
    {
        // only keep the first copy of this script around
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    public void GeneratePowerUp(Vector3 position)
    {
        if (PowerUpMgr.instance.toolNum != 0)
        {
            System.Random randm = new System.Random();
            int chanceNum = randm.Next(0, instance.blockNum);
            Debug.Log("chance is: " + chanceNum);

            if (chanceNum == 0)
            {
                int powerUpNum = randm.Next(0, 3);
                Debug.Log("number is: " + powerUpNum);
                switch (powerUpNum)
                {
                    case 0:
                        Instantiate(speeder, position, this.gameObject.transform.rotation);
                        break;
                    case 1:
                        Instantiate(doubleBomb, position, this.gameObject.transform.rotation);
                        break;
                    case 2:
                        Instantiate(booster, position, this.gameObject.transform.rotation);
                        break;
                }
                instance.toolNum--;
            }
            instance.blockNum--;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
