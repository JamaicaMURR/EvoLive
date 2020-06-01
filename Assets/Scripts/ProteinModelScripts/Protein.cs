using UnityEngine;
using System.Collections;

public abstract class Protein //: MonoBehaviour
{
    public abstract int PCode { get; }

    public abstract void ReactIn(GameObject cell);

    protected void Convert(GameObject cell, P sourceProtein, P resultProtein, int summ)
    {
        CellVars cv = cell.GetComponent<CellVars>();

        if(cv.proteins[(int)resultProtein]<summ && cv.proteins[(int)sourceProtein] + cv.proteins[(int)resultProtein] >= summ)
        {
            cv.proteins[(int)sourceProtein] -= summ - cv.proteins[(int)resultProtein];
            cv.proteins[(int)resultProtein] += summ - cv.proteins[(int)resultProtein];
        }
    }
}
