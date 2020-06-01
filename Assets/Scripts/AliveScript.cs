using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class AliveScript : MonoBehaviour
{
    public Text txt;
    public Statistics st;

    void Update()
    {
        txt.text = "Alive: " + Format(4, (ulong)st.alive);
    }

    string Format(int symbols, ulong number)
    {
        string result = number + "";

        while(result.Length < symbols)
        {
            result = "0" + result;
        }

        return result;
    }
}
