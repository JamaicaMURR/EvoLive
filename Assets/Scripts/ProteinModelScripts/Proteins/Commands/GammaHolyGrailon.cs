using UnityEngine;
using System.Collections;

public class GammaHolyGrailon : Protein
{
    public override int PCode { get { return (int)P.GammaHolyGrailon; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[PCode] >= 6)
        {
            cv.proteins[PCode]--;
            cv.lifeResource += 0.75f * nop.proteinCost;

            if(cv.proteins[(int)P.FreeConsumon] >= 3)
            {
                cv.proteins[(int)P.FreeConsumon] -= 3;
                cv.lifeResource += 2.75f * nop.proteinCost;
            }

            if(cv.proteins[(int)P.AlphaHolyGrailon] >= 6)
            {
                cv.proteins[(int)P.AlphaHolyGrailon] -= 6;
                cv.proteins[(int)P.TransMovon] += 3;
                cv.Energy += 2.75f * nop.proteinCost;
            }
        }
    }
}
