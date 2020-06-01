using UnityEngine;
using System.Collections;

public class TransInjecton : Protein
{
    public override int PCode { get { return (int)P.TransInjecton; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[PCode] >= 6 && cv.proteins[(int)P.Injecton] >= 6)
        {
            cv.proteins[PCode] -= 6;
            cv.proteins[(int)P.Injecton] += 6;
        }

        if(cv.proteins[(int)P.BetaHolyGrailon]>=12)
        {
            cv.proteins[(int)P.BetaHolyGrailon] -= 12;
            cv.proteins[PCode] += 9;
            cv.lifeResource += nop.proteinCost;
            cv.Energy += nop.proteinCost;
        }
    }
}
