using UnityEngine;
using System.Collections;

public class SplitonStealon : Protein
{
    public override int PCode { get { return (int)P.SplitonStealon; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[PCode] >= 12)
        {
            if(cell.GetComponent<PMCellConsumer>().RelProtSteal(0, P.Spliton))
            {
                cv.proteins[PCode] -= 12;
                cv.proteins[(int)P.Backwardon]++;
                cv.proteins[(int)P.BetaHolyGrailon]++;
                cv.proteins[(int)P.Conservon] += 2;
            }
            else
            {
                cv.proteins[PCode]--;
                cv.proteins[(int)P.LowEnergivon]++;
                cv.proteins[(int)P.TransRotaton]++;
                cv.Energy -= 1.25f * nop.proteinCost;
            }
        }
    }
}
