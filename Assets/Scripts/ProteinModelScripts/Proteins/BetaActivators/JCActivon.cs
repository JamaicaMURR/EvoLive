using UnityEngine;
using System.Collections;

public class JCActivon : Protein
{
    public override int PCode { get { return (int)P.JCActivon; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();

        if(cv.proteins[PCode] >= 12 && cv.proteins[(int)P.JCeenon] >= 6)
        {
            if(cell.GetComponent<PMJCeener>().RelJCeen(0))
            {
                cv.proteins[PCode] -= 12;
                cv.proteins[(int)P.JCeenon] -= 6;
            }
            else
            {
                cv.proteins[PCode]-=6;
                cv.proteins[(int)P.Equalon] += 5;
            }
        }

        if(cv.proteins[PCode]>=24)
        {
            cv.proteins[PCode] -= 18;
            cv.proteins[(int)P.Equalon] += 16;
        }
    }
}
