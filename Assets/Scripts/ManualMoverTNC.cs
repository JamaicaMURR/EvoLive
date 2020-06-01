using UnityEngine;
using System.Collections;

public class ManualMoverTNC : MonoBehaviour
{
    //private TNC tnc;
    //private Rotator r;

    //void Start()
    //{
    //    tnc = GetComponent<TNC>();
    //    r = GetComponent<Rotator>();
    //}

    //void Update()
    //{

    //    if(Input.GetKeyDown(KeyCode.A))
    //    {
    //        r.RelRotate(-1, true);
    //    }

    //    if(Input.GetKeyDown(KeyCode.D))
    //    {
    //        r.RelRotate(1, true);
    //    }

    //    if(Input.GetKey(KeyCode.W))
    //    {
    //        GetComponent<Mover>().RelMove(0, true);
    //    }

    //    if(Input.GetKey(KeyCode.S))
    //    {
    //        GetComponent<Mover>().RelMove(3, true);
    //    }

    //    if(Input.GetKeyDown(KeyCode.R))
    //    {
    //        GetComponent<Replicator>().RelReplicateForward(0, 0, 0.01f, true, 0, false);
    //    }

    //    if(Input.GetKeyDown(KeyCode.Q))
    //    {
    //        Debug.Log(tnc.GetDir());
    //        Debug.Log(GetComponent<Transform>().rotation);
    //    }

        //if(Input.GetKeyDown(KeyCode.Q))
        //{
        //    r.RotateRelative(-1, true); ;
        //}

        //if(Input.GetKeyDown(KeyCode.E))
        //{
        //    r.RotateRelative(1, true);
        //}

        //if(Input.GetKeyDown(KeyCode.F))
        //    r.RotateAbsolute(3);
    //}
}
