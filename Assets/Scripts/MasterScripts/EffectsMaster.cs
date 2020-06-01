using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EffectsMaster : MonoBehaviour
{
    [HideInInspector]
    public List<GameObject>[,] places;

    TNOptions tno;

    void Awake()
    {
        tno = GetComponent<TNOptions>();
        places = new List<GameObject>[tno.netHeight, tno.netWidth];
    }

    public void RegIn(GameObject g)
    {
        TNC gtnc = g.GetComponent<TNC>();

        int pl = gtnc.Line - tno.dLine;
        int pp = gtnc.Pos - tno.lPos;

        if(places[pl, pp] == null)
            places[pl, pp] = new List<GameObject>();

        places[pl, pp].Add(g);
    }

    public void ShowAt(Sprite s, int l, int p, int dir)
    {
        int pl = l - tno.dLine;
        int pp = p - tno.lPos;

        UniEffectScript ues = GetUnworking(pl, pp);

        if(ues != null)
            ues.Show(s, dir);
    }

    UniEffectScript GetUnworking(int l, int p)
    {
        UniEffectScript res = null;

        foreach(GameObject g in places[l, p])
            if(!g.GetComponent<UniEffectScript>().atWork)
                res = g.GetComponent<UniEffectScript>();

        return res;
    }
}
