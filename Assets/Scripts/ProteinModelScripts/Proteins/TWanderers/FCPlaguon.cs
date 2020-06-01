using UnityEngine;
using System.Collections;

public class FCPlaguon : Protein
{
    public override int PCode { get { return (int)P.FCPlaguon; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();

        if(cv.proteins[PCode] >= 6 && cv.proteins[(int)P.SplitDeenergon] >= 6)
        {
            cv.proteins[PCode] -= 6;
            cv.proteins[(int)P.SplitDeenergon] -= 6;
            cv.proteins[(int)P.OldEnergivon] += 10;
        }

        if(cv.proteins[PCode] >= 12)
        {
            cv.proteins[PCode] -= 12;
            cv.proteins[(int)P.TransInjecton] += 10;
        }
    }
}
