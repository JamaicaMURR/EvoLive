using UnityEngine;
using System.Collections;

public class TransRestarton12 : Protein
{
    public override int PCode { get { return (int)P.TransRestarton12; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();

        if(cv.proteins[PCode] >0)
        {
            cv.proteins[PCode] --;
            cv.proteins[(int)P.Restarton12] ++;
        }

        if(cv.proteins[(int)P.Restarton12] >=36)
        {
            cv.proteins[(int)P.Restarton12] -= 36;
            cv.proteins[(int)P.Swapon] += 6;
            cv.proteins[(int)P.MHungeron] += 6;
            cv.proteins[(int)P.VoidConsumon] += 22;
        }
    }
}
