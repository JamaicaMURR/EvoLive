using UnityEngine;
using System.Collections;

public class Swapon : Protein
{
    public override int PCode { get { return (int)P.Swapon; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[PCode] < 12 && cv.proteins[PCode] + cv.proteins[(int)P.InjDeathon] >= 12)
        {
            cv.proteins[(int)P.InjDeathon] -= 12 - cv.proteins[PCode];
            cv.proteins[PCode] += 12 - cv.proteins[PCode];
        }

        if(cv.proteins[PCode] >= 12)
        {
            if(cell.GetComponent<PMSwaper>().RelSwap(0))
            {
                cv.proteins[PCode] -= 12;
                cv.proteins[(int)P.ShiftIngibiton]++;
                cv.proteins[(int)P.LowEnergivon] += 3;
            }
            else if(cv.proteins[(int)P.Sprayon] > 0)
            {
                cv.proteins[PCode]--;
                cv.Energy -= 1.75f * nop.proteinCost;
                cv.proteins[(int)P.Fuson] += 2;
            }
            else
            {
                cv.proteins[PCode]--;
                cv.lifeResource += 0.25f * nop.proteinCost;
            }
        }
    }
}
