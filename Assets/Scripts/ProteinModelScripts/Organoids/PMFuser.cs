using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PMFuser : Organoid
{
    public Sprite effect;

    private MapMaster mm;

    void Awake()
    {
        mm = GameObject.Find("Master").GetComponent<MapMaster>();
    }

    //=============================================================================================================================

    public bool RelFuse(int direction)
    {
        return AbsFuse(TNC.NormalizeDir(GetComponent<TNC>().Dir + direction));
    }

    //=============================================================================================================================

    public bool AbsFuse(int direction)
    {
        bool isSuccess = false;

        GameObject target = GetComponent<Observer>().GetCellFromDir(direction);

        if(target != null)
        {
            target.GetComponent<GNM>().Genome = new List<float>(GetComponent<GNM>().Genome);

            CellVars cv = GetComponent<CellVars>();
            CellVars tcv = target.GetComponent<CellVars>();

            for(int i = 0; i < tcv.proteins.Length; i++)
                tcv.proteins[i] += cv.proteins[i];

            tcv.Energy += cv.Energy;

            ShowUniEffect(effect, true);

            target.GetComponent<GenColorer>().ReColor(true);

            cv.Energy = 0;

            isSuccess = true;
        }

        return isSuccess;
    }
}
