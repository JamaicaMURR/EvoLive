using UnityEngine;
using System.Collections;

public class FCPlagStarton : Protein
{
    public override int PCode { get { return (int)P.FCPlagStarton; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();

        if(cv.proteins[PCode] < 12 && cv.proteins[PCode] + cv.proteins[(int)P.VoidConsumon] >= 12)
        {
            cv.proteins[(int)P.VoidConsumon] -= 12 - cv.proteins[PCode];
            cv.proteins[PCode] += 12 - cv.proteins[PCode];
        }

        if(cv.proteins[PCode] >= 12)
        {
            if(cell.GetComponent<PMVoidConsumer>().RelConsume(0))
            {
                cv.proteins[PCode] -= 12;
                cv.proteins[(int)P.BackBudon] += 3;
            }
            else
            {
                cv.proteins[PCode] -= 4;
                cv.proteins[(int)P.FreeconsumExplodon] += 2;
                cv.proteins[(int)P.FCPlaguon]++;
            }
        }
    }
}
