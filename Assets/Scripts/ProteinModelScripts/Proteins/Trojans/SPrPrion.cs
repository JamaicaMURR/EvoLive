using UnityEngine;
using System.Collections;

public class SPrPrion : Protein
{
    public override int PCode { get { return (int)P.SPrPrion; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();

        if(cv.proteins[PCode] >= 18)
        {
            cv.proteins[PCode] -= 12;
            cell.GetComponent<PMSprayer>().Spray();
        }
    }
}
