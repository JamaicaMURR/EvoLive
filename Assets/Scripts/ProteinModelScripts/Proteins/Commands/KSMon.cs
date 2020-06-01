using UnityEngine;
using System.Collections;

public class KSMon : Protein
{
    public override int PCode { get { return (int)P.KSMon; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[PCode] >= 6)
        {
            cv.proteins[PCode]--;
            cv.lifeResource += 0.75f * nop.proteinCost;

            int sur = cell.GetComponent<Observer>().GetSurrounding();

            if(sur == 6)
            {
                if(cv.proteins[(int)P.Killon] >= 12)
                {
                    cell.GetComponent<PMKiller>().RelKill(3);

                    cv.proteins[(int)P.Killon] -= 12;
                    cv.proteins[PCode] += 3;
                    cv.proteins[(int)P.TransBetaRestarton12]++;
                }
                else if(cv.proteins[(int)P.Movon] >= 12)
                {
                    cell.GetComponent<PMSwaper>().RelSwap(3);

                    cv.proteins[(int)P.Movon] -= 12;
                    cv.proteins[PCode]++;
                    cv.proteins[(int)P.Killon] += 3;
                }
            }

            if(sur == 0)
            {
                cv.proteins[(int)P.Movon] += 18;
                cv.proteins[(int)P.Swapon] += 3;
                cv.proteins[(int)P.BackBudon]++;
                cv.Energy -= 26 * nop.proteinCost;
            }
        }
    }
}
