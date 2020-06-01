using UnityEngine;
using System.Collections;

public class TNOptions : MonoBehaviour
{
    public float pillarX = 0f;
    public float pillarY = 0f;
    public float gap = 0.3f;

    public int netWidth = 43;
    public int netHeight = 37;

    [SerializeField]
    private bool horizontalCircuit = true;

    public bool HorizontalCircuit
    {
        get { return horizontalCircuit; }
        set
        {
            horizontalCircuit = value;
        }
    }

    [SerializeField]
    private bool verticalCircuit = true;

    public bool VerticalCircuit
    {
        get { return verticalCircuit; }
        set
        {
            verticalCircuit = value;
        }
    }

    public int uLine = 0;
    public int dLine = 0;
    public int lPos = 0;
    public int rPos = 0;

    void Awake()
    {
        if(netHeight % 2 == 0)
            uLine = netHeight / 2 - 1;
        else
            uLine = netHeight / 2;

        dLine = -netHeight / 2;

        if(netWidth % 2 == 0)
            rPos = netWidth / 2 - 1;
        else
            rPos = netWidth / 2;

        lPos = -netWidth / 2;
    }

    //=============================================================================================================================

    public bool IsAtTN(int l, int p)
    {
        bool result = false;

        if(verticalCircuit || (l >= dLine && l <= uLine))
            if(horizontalCircuit || (p >= lPos && p <= rPos))
                result = true;

        return result;
    }
}
