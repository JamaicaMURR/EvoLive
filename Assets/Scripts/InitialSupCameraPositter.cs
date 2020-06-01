using UnityEngine;
using System.Collections;

public class InitialSupCameraPositter : MonoBehaviour
{
    public int poscode;

    TNOptions tno;

    void Awake()
    {
        tno = GameObject.Find("Master").GetComponent<TNOptions>();

        float vNetSize = tno.netHeight * tno.gap * 0.866f;
        float hNetSize = tno.netWidth * tno.gap;

        float vCamSize = GetComponent<Camera>().orthographicSize * 2;
        float hCamSize = ((float)Screen.width / Screen.height) * vCamSize;

        switch(poscode)
        {
            case 0:
                GetComponent<Transform>().position = new Vector3(hNetSize, 0, 0);
                break;
            case 1:
                GetComponent<Transform>().position = new Vector3(hNetSize, -vNetSize, 0);
                break;
            case 2:
                GetComponent<Transform>().position = new Vector3(0, -vNetSize, 0);
                break;
            case 3:
                GetComponent<Transform>().position = new Vector3(-hNetSize, -vNetSize, 0);
                break;
            case 4:
                GetComponent<Transform>().position = new Vector3(-hNetSize, 0, 0);
                break;
            case 5:
                GetComponent<Transform>().position = new Vector3(-hNetSize, vNetSize, 0);
                break;
            case 6:
                GetComponent<Transform>().position = new Vector3(0, vNetSize, 0);
                break;
            case 7:
                GetComponent<Transform>().position = new Vector3(hNetSize, vNetSize, 0);
                break;
        }

        //GetComponent<Transform>().position = new Vector3(0, vCamSize, 0);
    }
}
