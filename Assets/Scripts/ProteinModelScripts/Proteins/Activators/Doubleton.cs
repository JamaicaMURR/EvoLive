using UnityEngine;
using System.Collections;

public class Doubleton : Protein
{
    public override int PCode { get { return (int)P.Doubleton; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();

        if(cv.proteins[PCode] >= 12)
        {
            cv.proteins[PCode] -= 12;

            if(!cell.GetComponent<PMSpamer>().Double())
            {
                cv.proteins[PCode] += 11;
                cv.proteins[(int)P.FCExpUtiliton]++;
            }
        }
    }
}
