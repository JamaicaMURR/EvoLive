using UnityEngine;
using System.Collections;

public class BetaHolyGrailon : Protein
{
    public override int PCode { get { return (int)P.BetaHolyGrailon; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[PCode] >= 6 && cv.proteins[(int)P.AlphaHolyGrailon] > 0)
        {
            cv.proteins[PCode] -= 3;
            cv.proteins[(int)P.CellConsumon] += 24;
            cv.Energy -= 24 * nop.proteinCost;
        }

        if(cv.proteins[PCode] > 0 && cv.proteins[(int)P.HighEnDeathon] >= 3)
        {
            cv.proteins[PCode]--;
            cv.proteins[(int)P.HighEnDeathon] -= 3;
            cv.proteins[(int)P.AlphaHolyGrailon] += 3;
            cv.Energy += 0.5f * nop.proteinCost;
        }
    }
}
