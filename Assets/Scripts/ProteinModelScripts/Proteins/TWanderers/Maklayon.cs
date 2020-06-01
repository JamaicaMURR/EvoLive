using UnityEngine;
using System.Collections;

public class Maklayon : Protein
{
    public override int PCode { get { return (int)P.Maklayon; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();

        if(cv.proteins[PCode] >= 6 && cv.proteins[(int)P.Movon] >= 6)
        {
            cv.proteins[PCode] -= 6;
            cv.proteins[(int)P.Movon] += 4;
            cv.proteins[(int)P.MoveAcceleron]++;
        }

        if(cv.proteins[PCode] >= 12)
        {
            cv.proteins[PCode] -= 12;
            cell.GetComponent<PMSprayer>().CustomSpray(PCode, 6);
        }
    }
}
