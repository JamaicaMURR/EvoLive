using UnityEngine;
using System.Collections;

public class TransNavigonB : Protein
{
    public override int PCode { get { return (int)P.TransNavigonB; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[PCode] >= 18)
        {
            cv.proteins[PCode] -= 12;
            cv.proteins[(int)P.NavigonB] += 6;
            cv.proteins[(int)P.TransRotaton] += 4;
            cv.Energy += 1.5f * nop.proteinCost;
        }

        if(cv.proteins[(int)P.BetaHolyGrailon] >= 8 && (cv.proteins[(int)P.LightSpeedon] > 0 || cv.proteins[(int)P.HEBomUtiliton] >= 2))
        {
            cv.proteins[(int)P.BetaHolyGrailon] -= 6;
            cv.lifeResource += 4 * nop.proteinCost;
            cv.Energy += 1.25f * nop.proteinCost;
        }
    }
}
