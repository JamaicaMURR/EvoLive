using UnityEngine;
using System.Collections;

public class Rebirthon : Protein
{
    public override int PCode { get { return (int)P.Rebirthon; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();

        if(cv.proteins[PCode] >= 12)
        {
            cv.proteins[PCode] -= 12;
            cell.GetComponent<PMRebirther>().Rebirth();
        }
    }
}
