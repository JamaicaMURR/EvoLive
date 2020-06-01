using UnityEngine;
using System.Collections;

public class Navigon2 : Protein
{
    public override int PCode { get { return (int)P.Navigon2; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();

        if(cv.proteins[(int)P.TransRotaton] >= 12)
        {
            cv.proteins[(int)P.TransRotaton] -= 12;
            cv.proteins[PCode] += 12;
        }

        if(cv.proteins[PCode] >= 12 && cv.GetComponent<TNC>().Dir != 2)
        {
            cv.proteins[PCode] -= 12;
            cell.GetComponent<PMRotator>().AbsRotate(2, true);
        }
    }
}
