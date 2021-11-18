using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBlock : MonoBehaviour
{
    public GameObject block1;
    public GameObject block2;
    public GameObject block3;
    public GameObject block4;
    public GameObject block5;

    private GameObject[] blocks;

    [HideInInspector]
    public int z;

    // Start is called before the first frame update
    void Start()
    {
        blocks = new GameObject[] {block1, block2, block3, block4, block5};
        z = -10;

    }

    private void createBlock()
    {

        GameObject createdBlock =blocks[Random.Range(0, blocks.Length)];

        z -= 10;

        Instantiate(createdBlock, new Vector3(0, (float)0.8, z), createdBlock.transform.rotation);
    }

    void normalLevel()
    {
        blocks = new GameObject[] { block1, block3, block4, block5 };
    }

    void hardLevel()
    {
        blocks = new GameObject[] { block1, block3};
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
