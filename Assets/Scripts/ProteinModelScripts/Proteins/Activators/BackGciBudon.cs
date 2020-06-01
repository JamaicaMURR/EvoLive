using UnityEngine;
using System.Collections;

public class BackGciBudon : Protein
{
    public override int PCode { get { return (int)P.BackGciBudon; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[PCode] >= 6 && cv.proteins[(int)P.AlphaHolyGrailon] >= 24)
        {
            cv.proteins[PCode] -= 6;
            cv.proteins[(int)P.AlphaHolyGrailon] -= 24;
            cv.lifeResource += 29.5f * nop.proteinCost;
        }

        if(cv.proteins[PCode] >= 72)
        {
            float budEn = 66 * nop.proteinCost;
            int dir = TNC.NormalizeDir(cell.GetComponent<TNC>().Dir + 3);

            if(cell.GetComponent<PMSpamer>().SetBud(dir, budEn, true))
            {
                cv.proteins[PCode] -= 72;
                cv.lifeResource += 3 * nop.proteinCost;
            }
            else
            {
                cv.proteins[PCode]--;
                cv.lifeResource += 0.75f * nop.proteinCost;
            }
        }
    }
}
