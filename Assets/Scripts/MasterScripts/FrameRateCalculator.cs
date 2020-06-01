using UnityEngine;
using System.Collections;

public class FrameRateCalculator : MonoBehaviour
{
    public float markTime = 0.25f;
    public float dftsmoother = 0.1f;
    public float afrsmoother = 0.01f;

    private float timeCounter = 0;
    private int framesCounter = 0;

    public float framerate = 0;
    public float afr = 0;
    public float fdt = 0;

    void Start()
    {

    }

    void Update()
    {
        if(timeCounter<markTime)
        {
            timeCounter += Time.deltaTime;
            framesCounter++;
        }
        else
        {
            float oldFr = framerate;

            framerate = framesCounter / timeCounter;

            fdt += (framerate - oldFr - fdt) * dftsmoother;
            afr += (framerate - afr) * afrsmoother;

            framesCounter = 0;
            timeCounter = 0;
        }
    }
}
