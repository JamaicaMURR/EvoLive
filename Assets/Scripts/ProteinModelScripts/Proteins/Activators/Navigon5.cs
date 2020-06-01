using UnityEngine;
using System.Collections;

public class Navigon5 : Protein
{
    public override int PCode { get { return (int)P.Navigon5; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();

        if(cv.proteins[(int)P.TransRotaton] >= 12)
        {
            cv.proteins[(int)P.TransRotaton] -= 12;
            cv.proteins[PCode] += 12;
        }

        if(cv.proteins[PCode] >= 12 && cv.GetComponent<TNC>().Dir != 5)
        {
            cv.proteins[PCode] -= 12;
            cell.GetComponent<PMRotator>().AbsRotate(5, true);
        }
    }
}
