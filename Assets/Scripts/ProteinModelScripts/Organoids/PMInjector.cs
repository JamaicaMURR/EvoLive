using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PMInjector : Organoid
{
    public Sprite effect;
    public Sprite partInjEffect;

    private MapMaster mm;

    void Awake()
    {
        mm = GameObject.Find("Master").GetComponent<MapMaster>();
    }

    //=============================================================================================================================

    public bool RelInject(int direction, int erot)
    {
        return AbsInject(TNC.NormalizeDir(GetComponent<TNC>().Dir + direction), erot);
    }

    //=============================================================================================================================

    public bool RelInject(int direction)
    {
        return AbsInject(TNC.NormalizeDir(GetComponent<TNC>().Dir + direction), 0);
    }

    //=============================================================================================================================

    public bool AbsInject(int direction, int effectdir)
    {
        bool isSuccess = false;

        GameObject target = GetComponent<Observer>().GetCellFromDir(direction);

        if(target != null)
        {
            target.GetComponent<GNM>().Genome = GetComponent<GNM>().GetReplicatedGenome();

            ShowUniEffect(effect, true, effectdir);

            isSuccess = true;

            target.GetComponent<GenColorer>().ReColor(true);
        }

        return isSuccess;
    }

    //=============================================================================================================================

    public bool AbsPartInject(int direction, int effectdir)
    {
        bool isSuccess = false;

        GameObject target = GetComponent<Observer>().GetCellFromDir(direction);

        if(target != null)
        {
            //GNM g = GetComponent<GNM>();
            //GNM tg = target.GetComponent<GNM>();

            //List<float> part = g.GetReplicatedGenome();
            //part.RemoveRange(g.Gci, part.Count);

            //if(tg.Length>g.Gci)
            //tg.Genome.RemoveRange(g.)

            //target.GetComponent<GNM>().Genome = GetComponent<GNM>().GetReplicatedGenome();

            //ShowUniEffect(effect, true, effectdir);

            //isSuccess = true;

            //target.GetComponent<GenColorer>().ReColor(true);
        }

        return isSuccess;
    }
}
