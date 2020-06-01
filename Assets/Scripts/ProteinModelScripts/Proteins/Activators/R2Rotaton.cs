using UnityEngine;
using System.Collections;

public class R2Rotaton : Protein
{
    public override int PCode { get { return (int)P.R2Rotaton; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();

        Convert(cell, P.TransRotaton, P.R2Rotaton, 8);

        if(cv.proteins[PCode] >= 8)
        {
            cell.GetComponent<PMRotator>().RelRotate(2, true);
            cv.proteins[PCode] -= 8;
        }
    }
}
