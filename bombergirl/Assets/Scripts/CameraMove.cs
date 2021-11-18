using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform character;
    Vector3 offset;
    public float time = 5f;
    public GameObject anotherCamera;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - character.position;
        anotherCamera.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = character.position + offset;
        transform.position = Vector3.Lerp(transform.position, position, time * Time.deltaTime);   
        }
}
