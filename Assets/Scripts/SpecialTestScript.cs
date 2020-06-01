using UnityEngine;
using System.Collections;

public class SpecialTestScript : MonoBehaviour
{
    public float someF = 0;
    public float step = 0.1f;

    void Start()
    {

    }

    void Update()
    {
        someF += step;
    }
}
