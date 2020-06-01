using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class IterationsScript : MonoBehaviour
{
    public Text txt;
    public Statistics st;

    void Update()
    {
        txt.text = "Cycles: " + TextFormatter.Format(st.cycles, 15);
    }
}
