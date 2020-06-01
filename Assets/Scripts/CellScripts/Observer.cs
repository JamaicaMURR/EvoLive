using UnityEngine;
using System.Collections;
using System;

public class Observer : MonoBehaviour
{
    TNOptions tN;
    MapMaster mm;

    void Awake()
    {
        tN = GameObject.Find("Master").GetComponent<TNOptions>();
        mm = GameObject.Find("Master").GetComponent<MapMaster>();
    }

    //=============================================================================================================================

    public GameObject GetObjectWithTagAndTNC(string tag, int line, int pos)
    {
        GameObject result = null;

        if(GetComponent<TNC>().NormalizeLinePos(line, pos, out line, out pos))
        {
            GameObject[] allOfThem = GameObject.FindGameObjectsWithTag(tag);

            if(allOfThem.Length > 0)
            {
                foreach(GameObject g in allOfThem)
                {
                    if(g.GetComponent<TNC>().Line == line)
                    {
                        if(g.GetComponent<TNC>().Pos == pos)
                        {
                            result = g;
                            break;
                        }
                    }
                }
            }
        }

        return result;
    }

    public GameObject GetCellFromDir(int dir)
    {
        GameObject result = null;

        TNC tnc = GetComponent<TNC>();

        int tl = 0;
        int tp = 0;

        if(tnc.TNCAtDir(dir, out tl, out tp))
            if(mm.IsOccupied(tl, tp))
                result = mm.GetFrom(tl, tp);

        return result;
    }

    public GameObject GetCellInFront()
    {
        return GetCellFromDir(GetComponent<TNC>().Dir);
    }

    public int GetSurrounding()
    {
        TNC tnc = GetComponent<TNC>();

        int r = 0;

        for(int i = 0; i < 6; i++)
        {
            int tl = 0;
            int tp = 0;

            if(tnc.TNCAtDir(i, out tl, out tp))
                if(mm.IsOccupied(tl, tp))
                    r++;
        }

        return r;
    }
}
