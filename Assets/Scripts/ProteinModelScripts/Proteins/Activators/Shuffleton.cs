using UnityEngine;
using System.Collections;

public class Shuffleton : Protein
{
    public override int PCode { get { return (int)P.Shuffleton; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[(int)P.YoungEnergivon] >=36)
        {
            cv.proteins[(int)P.YoungEnergivon] -= 36;
            cell.GetComponent<PMSprayer>().CustomSpray((int)P.YoungEnergivon, 30);
        }
        else if(cv.proteins[PCode] >= 12)
        {
            if(cell.GetComponent<PMEqualizer>().RelShuffle(0))
            {
                cv.proteins[PCode] -= 12;
                cv.proteins[(int)P.YoungEnergivon] += 2;
                cv.proteins[(int)P.SpaceConsumon]++;
            }
            else
            {
                if(cv.proteins[(int)P.VoidConsumon] > 0)
                {
                    cv.proteins[PCode] -= 3;
                    cv.Energy += 2.5f * nop.proteinCost;
                }
                else
                {
                    cv.proteins[PCode]--;
                    cv.lifeResource += 0.5f * nop.proteinCost;
                }
            }
        }
    }
}
