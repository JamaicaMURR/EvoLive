using UnityEngine;
using System.Collections;

public class Pushon : Protein
{
    public override int PCode { get { return (int)P.Pushon; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();

        if(cv.proteins[PCode] >= 12)
        {
            if(cell.GetComponent<PMPusher>().RelPush(0))
            {
                cv.proteins[PCode] -= 12;
                cv.proteins[(int)P.AlphaHolyGrailon] += 4;
            }
            else
                cv.proteins[PCode]--;
        }
    }
}
