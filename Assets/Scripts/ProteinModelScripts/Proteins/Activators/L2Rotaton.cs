using UnityEngine;
using System.Collections;

public class L2Rotaton : Protein
{
    public override int PCode { get { return (int)P.L2Rotaton; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();

        Convert(cell, P.TransRotaton, P.L2Rotaton, 8);

        if(cv.proteins[PCode] >= 8)
        {
            cell.GetComponent<PMRotator>().RelRotate(4, true);
            cv.proteins[PCode] -= 8;
        }
    }
}
