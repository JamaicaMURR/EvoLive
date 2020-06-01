using UnityEngine;
using System.Collections;

public class FastBackRoton : Protein
{
    public override int PCode { get { return (int)P.FastBackRoton; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[(int)P.BetaHolyGrailon] >= 12 && cv.proteins[(int)P.SpaceConsumon] == 0)
        {
            cv.proteins[(int)P.BetaHolyGrailon] -= 12;
            cv.Energy += 6 * nop.proteinCost;
            cv.lifeResource += 6 * nop.proteinCost;
        }

        if(cv.proteins[(int)P.BetaHolyGrailon] >= 12 && cv.proteins[(int)P.Fuson] >= 4)
        {
            cv.proteins[(int)P.BetaHolyGrailon] -= 12;
            cv.proteins[(int)P.Fuson] -= 4;
            cv.Energy += 8 * nop.proteinCost;
            cv.lifeResource += 4 * nop.proteinCost;
            cv.proteins[(int)P.MoveAcceleron] += 2;
            cv.proteins[(int)P.SCSinkon]++;
        }

        if(cv.proteins[PCode] >= 12)
        {
            cv.proteins[PCode] -= 12;

            cell.GetComponent<PMRotator>().RelRotate(3, true);

            cv.proteins[(int)P.GammaHolyGrailon] += 6;
            cv.proteins[(int)P.Killon] += 2;
        }
    }
}
