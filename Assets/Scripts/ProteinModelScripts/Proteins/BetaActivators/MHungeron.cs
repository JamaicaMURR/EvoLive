using UnityEngine;
using System.Collections;

public class MHungeron : Protein
{
    public override int PCode { get { return (int)P.MHungeron; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();

        if(cv.proteins[PCode] < 12 && cv.proteins[PCode] + cv.proteins[(int)P.Movon] >= 12)
        {
            cv.proteins[(int)P.Movon] -= 12 - cv.proteins[PCode];
            cv.proteins[PCode] += 12 - cv.proteins[PCode];
        }

        if(cv.proteins[PCode] >= 12)
        {
            if(cell.GetComponent<PMMover>().RelMove(0, true))
            {
                cv.proteins[PCode] -= 12;
            }
            else
            {
                cv.proteins[PCode] -= 6;
                cv.proteins[(int)P.Killon] += 3;
            }
        }
    }
}
