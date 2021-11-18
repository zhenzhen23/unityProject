// this script will demonstrate a raycast from
// this object, along the direction (vDir)
// and respond to that raycast by.. stopping this object (or some other response)
using UnityEngine;

public class Raycast : MonoBehaviour
{
    // debug
    public bool debug; // debug instrumentation on
    public Color col; // draw our debug ray this color
    public Color openCol; // the color to draw when raycast is open
    public Color closedCol; // "" ... "" closed
                            // raycast state
    public Vector3 vDir; // the direction we are testing against
    public float distance; // the max distance our raycast will test against
    public bool hit; // did we hit something
    public int TestLayer; // layer to test against
    public float fixOffset;
    public float fixup;
    // response
    private Rigidbody rb; // so we can manipulate gravity/kinematic when ray hits!
                          // Use this for initialization
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
    }
    public void RaycastDemoUpdate()
    {
        // 1) handle debug drawing
        Vector3 vStart = this.transform.position;
        RaycastHit hitInfo;
        // initialize to open 'color'
        col = openCol;
        // 2) do the work
        hit = Physics.Raycast(vStart, vDir, out hitInfo, distance, (1 << TestLayer));
        if (hit == true)
        {
            // stop our cube...
            rb.isKinematic = true;
            // change the color to red, indicated closed
            col = closedCol;
            // attach to contact point
            Vector3 vContactPoint = hitInfo.point;
            // based on the collider that we have, we want to 'fixup' the final contact point
            Collider c = this.gameObject.GetComponent<Collider>();
            BoxCollider bc = (c as BoxCollider);
            if (bc != null)
            {
                fixup = fixOffset * this.gameObject.transform.localScale.y;
            }
            this.transform.position = new Vector3(vContactPoint.x, vContactPoint.y + fixup, vContactPoint.z);
        }
        else
        {
            // let it fall
            rb.isKinematic = false;
        }
        if (debug == true)
        {
            // draw the ray
            Vector3 vEnd = vStart + distance * vDir;
            Debug.DrawLine(vStart, vEnd, col);
        }
    }
    // Update is called once per frame
    void Update()
    {
        RaycastDemoUpdate();
    }
}