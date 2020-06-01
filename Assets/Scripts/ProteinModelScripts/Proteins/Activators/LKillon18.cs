using UnityEngine;
using System.Collections;

public class LKillon18 : Protein
{
    public override int PCode { get { return (int)P.LKillon18; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[PCode] < 18 && cv.proteins[PCode] + cv.proteins[(int)P.Killon] >= 18)
        {
            cv.proteins[(int)P.Killon] -= 18 - cv.proteins[PCode];
            cv.proteins[PCode] += 18 - cv.proteins[PCode];
        }

        if(cv.proteins[PCode] >= 18)
        {
            if(cell.GetComponent<PMKiller>().RelKill(0))
            {
                cv.proteins[PCode] -= 18;
                cv.Energy += 6 * nop.proteinCost;
                cv.proteins[(int)P.Pushon] += 3;
            }
        }
    }
}
