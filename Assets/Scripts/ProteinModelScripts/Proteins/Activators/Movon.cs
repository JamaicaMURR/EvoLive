using UnityEngine;
using System.Collections;

public class Movon : Protein
{
    public override int PCode { get { return (int)P.Movon; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();

        if(cv.proteins[(int)P.Maklayon] > 0)
        {
            cv.proteins[PCode]--;
            cv.proteins[(int)P.Maklayon]++;
        }

        if(cv.proteins[(int)P.PopCornon] >= 6)
        {
            cv.proteins[(int)P.PopCornon] -= 4;
            cv.proteins[PCode] += 3;
        }

        if(cv.proteins[(int)P.PopCornon] > 0 && cv.proteins[(int)P.Maklayon] >= 6)
        {
            cell.GetComponent<PMSuicider>().Suicide();
        }
        else if(cv.proteins[(int)P.Maklayon] >= 12)
        {
            cv.proteins[(int)P.Maklayon] -= 12;
            cell.GetComponent<PMSprayer>().CustomSpray((int)P.Maklayon, 6);
        }
        else if(cv.proteins[PCode] >= 12)
        {
            if(cell.GetComponent<PMMover>().RelMove(0, true))
            {
                cv.proteins[PCode] -= 12;

                if(cv.proteins[(int)P.MoveAcceleron] >= 12)
                {
                    cv.proteins[PCode] += 12;
                    cv.proteins[(int)P.MoveAcceleron] -= 12;
                }
            }
            else
                cv.proteins[PCode]--;
        }
    }
}
