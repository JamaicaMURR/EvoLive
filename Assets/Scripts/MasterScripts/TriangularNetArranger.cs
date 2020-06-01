using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TriangularNetArranger : MonoBehaviour
{
    public GameObject cell;
    public GameObject label;
    public GameObject effect;

    public int effectsPerPlace;
    public bool spawnlabels = false;

    TNOptions tN;
    MapMaster mm;
    EffectsMaster em;

    void Awake()
    {
        tN = GetComponent<TNOptions>();
        mm = GetComponent<MapMaster>();
        em = GetComponent<EffectsMaster>();
    }

    void Start()
    {
        if(spawnlabels)
        {
            for(int i = tN.dLine; i <= tN.uLine; i++)
            {
                for(int j = tN.lPos; j <= tN.rPos; j++)
                {
                    Arrange(label, i, j);
                }
            }
        }

        for(int i = tN.dLine; i <= tN.uLine; i++)
        {
            for(int j = tN.lPos; j <= tN.rPos; j++)
            {
                mm.deadstack.Add(Arrange(cell, i, j));
            }
        }

        for(int i = tN.dLine; i <= tN.uLine; i++)
        {
            for(int j = tN.lPos; j <= tN.rPos; j++)
            {
                for(int h = 0; h < effectsPerPlace; h++)
                    em.RegIn(Arrange(effect, i, j));
            }
        }
    }

    GameObject Arrange(GameObject pref, int line, int pos)
    {
        GameObject clone = Instantiate(pref);

        clone.GetComponent<TNC>().SetTNC(line, pos);

        return clone;
    }
}
