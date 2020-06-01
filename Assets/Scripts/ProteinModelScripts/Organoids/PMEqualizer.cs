using UnityEngine;
using System.Collections.Generic;

public class PMEqualizer : Organoid
{
    public Sprite effect;
    public Sprite shuffleEffect;

    private MapMaster mm;

    //=============================================================================================================================

    void Awake()
    {
        mm = GameObject.Find("Master").GetComponent<MapMaster>();
    }

    //=============================================================================================================================

    public bool AbsEqualize(int absDir)
    {
        bool isSuccess = false;

        GameObject target = GetComponent<Observer>().GetCellFromDir(absDir);

        if(target != null)
        {
            List<float> sgch = GetComponent<GNM>().Genome;
            List<float> tgch = target.GetComponent<GNM>().Genome;

            int gcl;

            if(sgch.Count > tgch.Count)
                gcl = tgch.Count;
            else
                gcl = sgch.Count;

            for(int i = 0; i < gcl; i++)
            {
                float sa = (sgch[i] + tgch[i]) / 2;
                sgch[i] = sa;
                tgch[i] = sa;
            }

            GetComponent<GenColorer>().ReColor(true);
            target.GetComponent<GenColorer>().ReColor(true);

            ShowUniEffect(effect, true);

            isSuccess = true;
        }

        return isSuccess;
    }

    //=============================================================================================================================

    public bool RelEqualize(int relDir)
    {
        return AbsEqualize(TNC.NormalizeDir(GetComponent<TNC>().Dir + relDir));
    }

    //=============================================================================================================================

    public bool AbsShuffle(int absDir)
    {
        bool isSuccess = false;

        GameObject target = GetComponent<Observer>().GetCellFromDir(absDir);

        if(target != null)
        {
            List<float> sgch = GetComponent<GNM>().Genome;
            List<float> tgch = target.GetComponent<GNM>().Genome;

            int gcl;

            if(sgch.Count > tgch.Count)
                gcl = tgch.Count;
            else
                gcl = sgch.Count;

            for(int i = 0; i < gcl; i++)
            {
                if(i % 2 == 0)
                    tgch[i] = sgch[i];
            }

            target.GetComponent<GenColorer>().ReColor(true);

            ShowUniEffect(shuffleEffect, false, absDir);

            isSuccess = true;
        }

        return isSuccess;
    }

    //=============================================================================================================================

    public bool RelShuffle(int dir)
    {
        return AbsShuffle(TNC.NormalizeDir(GetComponent<TNC>().Dir + dir));
    }
}
