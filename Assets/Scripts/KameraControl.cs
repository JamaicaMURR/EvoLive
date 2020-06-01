using UnityEngine;
using System.Collections;

public class KameraControl : MonoBehaviour
{
    public Camera[] cams;

    public float speed = 2;
    public float scalespeed = 7.5f;

    public Transform lcamt;
    public Transform rcamt;
    public Transform ucamt;
    public Transform dcamt;

    Transform t;

    float lcx;
    float rcx;
    float ucy;
    float dcy;
    float vNetSize;
    float hNetSize;
    float minScale;
    float maxScale;

    Vector3 mpos;
    Vector3 deltam;
    bool scrollmode = false;

    NeoOptions nop;
    TNOptions tno;

    void Awake()
    {
        nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        t = GetComponent<Transform>();

        tno = GameObject.Find("Master").GetComponent<TNOptions>();

        vNetSize = tno.netHeight * tno.gap * 0.866f;
        hNetSize = tno.netWidth * tno.gap;

        minScale = vNetSize / 2;
        maxScale = 1.5f;
    }

    void Start()
    {
        lcx = lcamt.position.x;
        rcx = rcamt.position.x;
        ucy = ucamt.position.y;
        dcy = dcamt.position.y;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            mpos = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
            scrollmode = true;
        }

        if(Input.GetKey(KeyCode.Mouse0))
        {
            deltam = Input.mousePosition - mpos;
            mpos = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
        }

        if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            scrollmode = false;
        }

        if(scrollmode)
        {
            float scalefactor = cams[0].orthographicSize * 2 / Screen.height;
            t.transform.position += new Vector3(-deltam.x * scalefactor, -deltam.y * scalefactor, 0);
        }

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            t.transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        }

        if(Input.GetKey(KeyCode.RightArrow))
        {
            t.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }

        if(Input.GetKey(KeyCode.UpArrow))
        {
            t.transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        }

        if(Input.GetKey(KeyCode.DownArrow))
        {
            t.transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
        }

        if(Input.mouseScrollDelta.y < 0)
        {
            foreach(Camera cam in cams)
            {
                cam.orthographicSize += scalespeed * Time.deltaTime;

                if(cam.orthographicSize > minScale)
                    cam.orthographicSize = minScale;
            }
        }

        if(Input.mouseScrollDelta.y > 0)
        {
            foreach(Camera cam in cams)
            {
                cam.orthographicSize -= scalespeed * Time.deltaTime;

                if(cam.orthographicSize < maxScale)
                    cam.orthographicSize = maxScale;
            }
        }

        if(t.transform.position.x >= rcx)
        {
            t.transform.position = new Vector3(0, t.transform.position.y, 0);
        }

        if(t.transform.position.x <= lcx)
            t.transform.position = new Vector3(0, t.transform.position.y, 0);

        if(t.transform.position.y >= ucy)
            t.transform.position = new Vector3(t.transform.position.x, 0, 0);

        if(t.transform.position.y <= dcy)
            t.transform.position = new Vector3(t.transform.position.x, 0, 0);
    }
}
