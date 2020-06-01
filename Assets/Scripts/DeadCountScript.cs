using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DeadCountScript : MonoBehaviour
{
    public Text txt;
    public Statistics st;

    void Update()
    {
        txt.text = "Dead: " + TextFormatter.Format(st.dead, 15);
    }
}
