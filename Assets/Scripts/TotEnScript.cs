using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class TotEnScript : MonoBehaviour
{
    public Text txt;
    public Statistics st;

    void Update()
    {
        txt.text = "Energy: " + Math.Round(st.energyTotal, 4 - Signs(st.energyTotal));
    }

    int Signs(float n)
    {
        int result = 1;

        int bd = (int)n;

        bd /= 10;

        while(bd > 0)
        {
            bd /= 10;
            result++;
        }

        return result;
    }
}
