using UnityEngine;
using System.Collections;

public class TransSwapon : Protein
{
    public override int PCode { get { return (int)P.TransSwapon; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();

        if(cv.proteins[PCode] >= 36 && cv.proteins[(int)P.Swapon] == 0)
        {
            cv.proteins[PCode] -= 36;
            cv.proteins[(int)P.Swapon] += 36;
        }
    }
}
