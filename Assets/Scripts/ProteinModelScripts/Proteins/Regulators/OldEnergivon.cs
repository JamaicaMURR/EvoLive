using UnityEngine;
using System.Collections;

public class OldEnergivon : Protein
{
    public override int PCode { get { return (int)P.OldEnergivon; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[(int)P.AlphaHolyGrailon]>=6)
        {
            cv.proteins[(int)P.AlphaHolyGrailon] -= 6;
            cv.lifeResource += 5.5f * nop.proteinCost;
        }

        if(cv.proteins[PCode] >= 24 && cv.Age >= 0.5)
        {
            cv.proteins[PCode] -= 24;
            cv.Energy += 22 * nop.proteinCost;
        }
    }
}
