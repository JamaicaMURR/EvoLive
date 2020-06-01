using UnityEngine;
using System.Collections;

public class CellVars : MonoBehaviour
{
    NeoOptions nop;
    Statistics st;
    Lifter lif;
    TNC tnc;

    float energy;
    public float Energy
    {
        get { return energy; }
        set
        {
            energy = value;

            if(energy > 1)
                energy = 1;
        }
    }

    [HideInInspector]
    public float lifeResource;
    public float Age
    {
        get
        {
            float result = 1 - lifeResource / nop.lifeResource;

            if(result < 0)
                result = 0;

            return result;
        }
    }

    [HideInInspector]
    bool isOnscene;
    public bool IsOnscene
    {
        get { return isOnscene; }
        set
        {
            if(!isOnscene && value)
            {
                lif.ToUp();
            }

            if(isOnscene && !value)
            {
                lif.ToDown();
                Wipe();
            }

            isOnscene = value;
        }
    }

    [HideInInspector]
    public int[] proteins;

    [HideInInspector]
    public int bornDir;

    [HideInInspector]
    public bool ORLabel;
    [HideInInspector]
    public bool DRLabel;
    [HideInInspector]
    public int DSLabel;
    //=============================================================================================================================

    void Awake()
    {
        nop = GameObject.Find("Master").GetComponent<NeoOptions>();
        st = GameObject.Find("Master").GetComponent<Statistics>();

        lif = GetComponent<Lifter>();
        tnc = GetComponent<TNC>();

        Wipe();
    }
    //=============================================================================================================================

    void Wipe()
    {
        energy = 0;
        lifeResource = 0;

        proteins = new int[(int)P.Last];

        ORLabel = false;
        DRLabel = false;
        DSLabel = -1;
    }

    //=============================================================================================================================

    public void EatVars(GameObject g)
    {
        CellVars gcv = g.GetComponent<CellVars>();

        energy = gcv.Energy;
        lifeResource = gcv.lifeResource;

        proteins = gcv.proteins;

        ORLabel = gcv.ORLabel;
        DRLabel = gcv.DRLabel;
        DSLabel = gcv.DSLabel;
    }

    //=============================================================================================================================

    public int[] DivideProteins()
    {
        int[] result = new int[proteins.Length];

        for(int i = 0; i < proteins.Length; i++)
        {
            result[i] = proteins[i] / 2;
            proteins[i] -= result[i];
        }

        return result;
    }

}
