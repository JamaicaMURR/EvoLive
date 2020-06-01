using UnityEngine;
using System.Collections;

public class PMCellConsumer : Organoid
{
    public Sprite effect;
    public Sprite protStealEffect;

    MapMaster mm;

    //=============================================================================================================================

    void Awake()
    {
        mm = GameObject.Find("Master").GetComponent<MapMaster>();
    }

    public bool AbsConsume(int direction)
    {
        bool isSuccess = false;

        TNC tnc = GetComponent<TNC>();

        GameObject target = GetComponent<Observer>().GetCellFromDir(direction);

        if(target != null)
        {
            CellVars tcv = target.GetComponent<CellVars>();
            CellVars cv = GetComponent<CellVars>();

            if(tcv.Energy > 1 - cv.Energy)
            {
                tcv.Energy -= 1 - cv.Energy;
                cv.Energy = 1;
            }
            else
            {
                tcv.Energy = 0;
                cv.Energy += tcv.Energy;
            }

            ShowUniEffect(effect, true);

            isSuccess = true;
        }

        return isSuccess;
    }

    public bool RelConsume(int direction)
    {
        return AbsConsume(TNC.NormalizeDir(GetComponent<TNC>().Dir + direction));
    }

    //=============================================================================================================================

    public bool AbsProtSteal(int direction, P protein)
    {
        bool isSuccess = false;

        TNC tnc = GetComponent<TNC>();

        GameObject target = GetComponent<Observer>().GetCellFromDir(direction);

        if(target != null)
        {
            CellVars tcv = target.GetComponent<CellVars>();
            CellVars cv = GetComponent<CellVars>();

            cv.proteins[(int)protein] += tcv.proteins[(int)protein];
            tcv.proteins[(int)protein] = 0;

            ShowUniEffect(protStealEffect, false, direction);

            isSuccess = true;
        }

        return isSuccess;
    }

    public bool RelProtSteal(int dir, P protein)
    {
        return AbsProtSteal(TNC.NormalizeDir(GetComponent<TNC>().Dir + dir), protein);
    }
}
