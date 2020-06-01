using UnityEngine;
using System.Collections;

public class UIinputController : MonoBehaviour
{
    public UIMover[] acts;
    public KeyCode[] kkds;

    void Update()
    {
        for(int i=0; i<acts.Length && i<kkds.Length;i++)
        {
            if(Input.GetKeyDown(kkds[i]))
                acts[i].Act();
        }
    }
}
