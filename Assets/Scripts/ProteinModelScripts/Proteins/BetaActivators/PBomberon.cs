using UnityEngine;
using System.Collections;

public class PBomberon : Protein
{
    public override int PCode { get { return (int)P.PBomberon; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();

        if(cv.proteins[PCode] >= 12)
        {
            if(cell.GetComponent<PMPusher>().RelPush(0))
            {
                cv.proteins[PCode] -= 12;
                cv.proteins[(int)P.Accumuton] += 3;
            }
            else
            {
                cv.proteins[PCode] -= 6;
                cv.proteins[(int)P.FreeconsumExplodon] += 3;
            }
        }
    }
}
