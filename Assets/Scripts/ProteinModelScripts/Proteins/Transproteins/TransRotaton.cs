using UnityEngine;
using System.Collections;

public class TransRotaton : Protein
{
    public override int PCode { get { return (int)P.TransRotaton; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();

        if(cv.proteins[PCode] > 0 && cv.proteins[(int)P.SplitPrion] >= 6)
        {
            cv.proteins[(int)P.SplitPrion] -= 6;
            cv.proteins[PCode] += 5;
        }
    }
}
