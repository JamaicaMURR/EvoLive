using UnityEngine;
using System.Collections;

public class LeftRotaton : Protein
{
    public override int PCode { get { return (int)P.LeftRotaton; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();

        if(cv.proteins[(int)P.TransRotaton]>=12)
        {
            cv.proteins[(int)P.TransRotaton] -= 12;
            cv.proteins[PCode] += 12;
        }

        if(cv.proteins[PCode] >= 4)
        {
            cell.GetComponent<PMRotator>().RelRotate(-1, true);
            cv.proteins[PCode] -= 4;
        }
    }
}
