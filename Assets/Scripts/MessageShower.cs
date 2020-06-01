using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MessageShower : MonoBehaviour
{
    public int delay;
    private int framesRemaning = 0;
    private bool isShowing = false;

    UIMover m;

    void Awake()
    {
        m = GetComponent<UIMover>();
    }

    public void ShowMessage(string text)
    {
        GetComponent<Text>().text = text;
        m.isToSecP = true;
        m.Act();
        framesRemaning = delay;
        isShowing = true;
    }

    void Update()
    {
        if(!m.isInProcess && isShowing)
            if(framesRemaning > 0)
                framesRemaning--;
            else
            {
                m.Act();
                isShowing = false;
            }
    }
}
