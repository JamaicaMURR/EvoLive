using UnityEngine;
using System.Collections;

public class Statizer
{
    public int vals = 1000;
    public int curVals = 0;

    public float curP = 0;
    private float v = 0;

    public float V { get { return v; } }

    public void Add(float nv)
    {
        if(curVals < vals)
            curVals++;

        curP = 1f / curVals;

        v += (nv - v) * curP;
    }

    public void Reset()
    {
        curVals = 1;
    }
}
