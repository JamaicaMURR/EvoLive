using UnityEngine;
using System.Collections;

public class FCImidSprayon : Protein
{
    public override int PCode { get { return (int)P.FCImidSprayon; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        cv.proteins[PCode]--;
        cv.lifeResource += 0.75f * nop.proteinCost;

        if(cv.proteins[(int)P.FreeConsumon] >= 9)
        {
            cv.proteins[(int)P.FreeConsumon] -= 9;
            cv.Energy -= 6 * nop.proteinCost;
            cell.GetComponent<PMSprayer>().CustomSpray((int)P.GammaHolyGrailon, 6);
        }
        else if(cv.proteins[(int)P.TransBetaRestarton12]>=6)
        {
            cv.proteins[(int)P.TransBetaRestarton12] -= 6;
            cv.Energy -= 6 * nop.proteinCost;
            cell.GetComponent<PMSprayer>().CustomSpray((int)P.PopCornon, 6);
        }
        
    }
}
