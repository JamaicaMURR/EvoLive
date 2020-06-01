using UnityEngine;
using System.Collections;

public class BackBudon : Protein
{
    public override int PCode { get { return (int)P.BackBudon; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[PCode] >= 6 && cv.proteins[(int)P.BetaHolyGrailon] >= 24)
        {
            cv.proteins[PCode] -= 6;
            cv.proteins[(int)P.BetaHolyGrailon] -= 24;
            cv.lifeResource += 29.5f * nop.proteinCost;
        }

        if(cv.proteins[PCode] < 60 && cv.proteins[PCode] + cv.proteins[(int)P.Explodon] >= 60)
        {
            cv.proteins[(int)P.Explodon] -= 60 - cv.proteins[PCode];
            cv.proteins[PCode] += 60 - cv.proteins[PCode];
        }

        if(cv.proteins[PCode] >= 60)
        {
            float budEn = 50 * nop.proteinCost;
            int dir = TNC.NormalizeDir(cell.GetComponent<TNC>().Dir + 3);

            if(cell.GetComponent<PMSpamer>().SetBud(dir, budEn))
            {
                cv.proteins[PCode] -= 60;
                cv.lifeResource += 4 * nop.proteinCost;
            }
            else
            {
                cv.proteins[PCode]--;
                cv.lifeResource += 0.75f * nop.proteinCost;
            }
        }
    }
}
