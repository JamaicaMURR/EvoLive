using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class SpdScrpt : MonoBehaviour
{
    public Text txt;
    public MasterScript ms;

    private NeoOptions nop;
    private Statistics st;

    void Awake()
    {
        nop = GameObject.Find("Master").GetComponent<NeoOptions>();
        st = GameObject.Find("Master").GetComponent<Statistics>();
    }

    void Update()
    {
        if(nop.speedFormat == 0)
            txt.text = "Speed: " + (int)ms.speed + " actions/s";// Math.Round(ms.speed, 3 - Signs(ms.speed));

        if(nop.speedFormat == 1)
        {
            int beforedot = 0;
            int intafterdot = 0;

            if(st.alive != 0)
            {
                beforedot = (int)ms.speed / st.alive;
                intafterdot = (int)((ms.speed / st.alive * 100) % 100);
            }

            string afterdot;

            if(intafterdot != 0)
                afterdot = intafterdot.ToString();
            else
                afterdot = "00";


            txt.text = "Speed: " + beforedot + "." + afterdot + " cycles/s";
        }
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
