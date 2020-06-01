using UnityEngine;
using System.Collections;

public class LowEnergivon : Protein
{
    public override int PCode { get { return (int)P.LowEnergivon; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[PCode] < 72 && cv.proteins[PCode] + cv.proteins[(int)P.InjDeathon] >= 72)
        {
            cv.proteins[(int)P.InjDeathon] -= 72 - cv.proteins[PCode];
            cv.proteins[PCode] += 72 - cv.proteins[PCode];
        }

        if(cv.proteins[PCode] >= 72 && cv.Energy < 0.25)
        {
            cv.proteins[PCode] -= 72;
            cv.Energy += 70 * nop.proteinCost;
        }

        if(cv.proteins[(int)P.AlphaHolyGrailon] >= 6)
        {
            cv.proteins[(int)P.AlphaHolyGrailon] -= 6;
            cv.Energy += 6 * nop.proteinCost;
            cv.lifeResource -= 6 * nop.proteinCost;
        }
    }
}
