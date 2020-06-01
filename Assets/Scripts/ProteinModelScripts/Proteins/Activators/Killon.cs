using UnityEngine;
using System.Collections;

public class Killon : Protein
{
    public override int PCode { get { return (int)P.Killon; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();

        if(cv.proteins[PCode] >= 12)
        {
            if(cell.GetComponent<PMKiller>().RelKill(0))
            {
                cv.proteins[PCode] -= 12;
                cv.proteins[(int)P.CellConsumon] += 3;
            }
            else
                cv.proteins[PCode]--;
        }
    }
}
