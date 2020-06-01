using UnityEngine;
using System.Collections;

public class InjSPrion : Protein
{
    public override int PCode { get { return (int)P.InjSPrion; } }

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
