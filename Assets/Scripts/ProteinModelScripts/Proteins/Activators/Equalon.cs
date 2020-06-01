using UnityEngine;
using System.Collections;

public class Equalon : Protein
{
    public override int PCode { get { return (int)P.Equalon; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[PCode] >= 6 && cv.proteins[(int)P.BetaHolyGrailon] >= 12)
        {
            cv.proteins[PCode] -= 6;
            cv.proteins[(int)P.BetaHolyGrailon] -= 9;
            cv.lifeResource += 14.5f * nop.proteinCost;
        }

        if(cv.proteins[PCode] >= 12)
        {
            if(cell.GetComponent<PMEqualizer>().RelEqualize(0))
            {
                cv.proteins[PCode] -= 12;
                cv.proteins[(int)P.BetaHolyGrailon] += 6;
            }
            else
                cv.proteins[PCode]--;
        }
    }
}
