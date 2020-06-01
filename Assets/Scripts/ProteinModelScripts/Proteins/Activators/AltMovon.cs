using UnityEngine;
using System.Collections;

public class AltMovon : Protein
{
    public override int PCode { get { return (int)P.AltMovon; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[(int)P.Movon] >= 6)
        {
            cv.proteins[(int)P.Movon] -= 4;
            cv.proteins[PCode] += 3;
            cv.lifeResource += 0.5f * nop.proteinCost;
        }

        if(cv.proteins[(int)P.PopCornon] > 0 && cv.proteins[(int)P.Maklayon] >= 6)
        {
            cell.GetComponent<PMSuicider>().Suicide();
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

                cv.proteins[(int)P.JCeenon]++;
                cv.proteins[(int)P.EnerGivon] += 4;
                cv.proteins[(int)P.GForBudon] += 3;
            }
            else
            {
                cv.proteins[PCode] -= 2;
                cv.Energy += 1.75f * nop.proteinCost;
            }
        }
    }
}
