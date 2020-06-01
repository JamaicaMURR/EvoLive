using UnityEngine;
using System.Collections;

public class Nothingon : Protein
{
    public override int PCode { get { return (int)P.Nothingon; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();

        if(cv.proteins[PCode] >= 24)
        {
            cv.proteins[PCode] -= 12;
            cell.GetComponent<PMSprayer>().CustomSpray(PCode, 6);
        }
    }
}
