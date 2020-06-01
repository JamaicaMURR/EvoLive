using UnityEngine;
using System.Collections;

public class TransMovon : Protein
{
    public override int PCode { get { return (int)P.TransMovon; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();

        if(cv.proteins[PCode] >= 12)
        {
            cv.proteins[PCode] -= 12;
            cv.proteins[(int)P.Movon] += 12;
        }
    }
}
