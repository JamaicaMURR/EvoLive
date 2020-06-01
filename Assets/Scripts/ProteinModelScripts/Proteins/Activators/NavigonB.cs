using UnityEngine;
using System.Collections;

public class NavigonB : Protein
{
    public override int PCode { get { return (int)P.NavigonB; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();

        if(cv.proteins[(int)P.TransRotaton] >= 12)
        {
            cv.proteins[(int)P.TransRotaton] -= 12;
            cv.proteins[PCode] += 12;
        }

        if(cv.proteins[PCode] >= 12)
        {
            cv.proteins[PCode] -= 12;
            cell.GetComponent<PMRotator>().AbsRotate(cv.bornDir, true);
        }
    }
}
