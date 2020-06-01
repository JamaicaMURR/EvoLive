using UnityEngine;
using System.Collections;

public class FSpliton : Protein
{
    public override int PCode { get { return (int)P.FSpliton; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[PCode] >= 18)
        {
            int sur = cell.GetComponent<Observer>().GetSurrounding();

            if(sur < 3)
            {
                cv.proteins[PCode] -= 12;
                cv.proteins[(int)P.Spliton] += 6;
                cv.Energy += 5.5f * nop.proteinCost;

                if(cv.proteins[(int)P.Spliton] >= 12)
                {
                    cv.proteins[(int)P.Spliton] -= 12;

                    if(cell.GetComponent<PMSplitter>().RelSplit(3))
                    {
                        cv.proteins[(int)P.SpaceConsumon] += 2;
                    }
                    else
                    {
                        cv.proteins[(int)P.Spliton] += 3;
                        cv.proteins[(int)P.HEBomUtiliton] += 3;
                        cv.proteins[(int)P.L2Rotaton] += 3;
                        cv.proteins[(int)P.R2Rotaton] += 3;
                    }
                }
            }
            else
            {
                cv.proteins[PCode] -= 3;
                cv.Energy -= 4 * nop.proteinCost;
                cv.proteins[(int)P.Killon] += 6;
            }
        }
    }
}
