using UnityEngine;
using System.Collections;

public class PMSprayer : Organoid
{
    private TNC tnc;

    public Sprite sprayEffect;
    public Sprite customSprayEffect;
    public Sprite exchangEffect;
    public Sprite protGiveEffect;

    private MapMaster mm;

    void Awake()
    {
        tnc = GetComponent<TNC>();

        mm = GameObject.Find("Master").GetComponent<MapMaster>();
    }

    public void Spray()
    {
        CellVars cv = GetComponent<CellVars>();

        int[] gift = new int[cv.proteins.Length];

        for(int i = 0; i < gift.Length; i++)
        {
            gift[i] = cv.proteins[i] / 6;
            cv.proteins[i] -= gift[i] * 6;
        }

        Observer o = GetComponent<Observer>();

        for(int i = 0; i < 6; i++)
        {
            GameObject target = o.GetCellFromDir(i);

            if(target != null)
            {
                CellVars tcv = target.GetComponent<CellVars>();

                for(int j = 0; j < gift.Length; j++)
                    tcv.proteins[j] += gift[j];
            }
        }

        ShowUniEffect(sprayEffect, false);
    }

    public void CustomSpray(int pcode, int amount)
    {
        CellVars cv = GetComponent<CellVars>();

        int gift = amount / 6;

        Observer o = GetComponent<Observer>();

        for(int i = 0; i < 6; i++)
        {
            GameObject target = o.GetCellFromDir(i);

            if(target != null)
            {
                CellVars tcv = target.GetComponent<CellVars>();

                tcv.proteins[pcode] += gift;
            }
        }

        ShowUniEffect(customSprayEffect, false);
    }

    public bool AbsProteinExchange(int direction)
    {
        bool isSuccess = false;

        GameObject target = GetComponent<Observer>().GetCellFromDir(direction);

        if(target != null)
        {
            int[] cvp = GetComponent<CellVars>().proteins;
            int[] tcvp = target.GetComponent<CellVars>().proteins;

            for(int i = 0; i < cvp.Length; i++)
            {
                int cvpg = cvp[i] / 2;
                int cvpr = cvp[i] - cvpg;
                int tcvpg = tcvp[i] / 2;
                int tcvpr = tcvp[i] - tcvpg;
                cvp[i] = cvpr + tcvpg;
                tcvp[i] = tcvpr + cvpg;
            }

            ShowUniEffect(exchangEffect, true);

            isSuccess = true;
        }

        return isSuccess;
    }

    public bool RelProteinExchange(int direction)
    {
        return AbsProteinExchange(TNC.NormalizeDir(GetComponent<TNC>().Dir + direction));
    }

    public bool AbsProteinGive(int direction, P protein, int pAmount)
    {
        bool isSuccess = false;

        GameObject target = GetComponent<Observer>().GetCellFromDir(direction);

        if(target != null)
        {
            target.GetComponent<CellVars>().proteins[(int)protein] += pAmount;

            ShowUniEffect(protGiveEffect, true);

            isSuccess = true;
        }

        return isSuccess;
    }

    public bool RelProteinGive(int direction, P protein, int pAmount)
    {
        return AbsProteinGive(TNC.NormalizeDir(GetComponent<TNC>().Dir + direction), protein, pAmount);
    }
}
