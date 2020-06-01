using UnityEngine;
using System.Collections;

public class Suicidon : Protein
{
    public override int PCode { get { return (int)P.Suicidon; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();

        if(cv.proteins[PCode] >= 3 && cv.proteins[(int)P.FCFabricaton] >= 3)
        {
            cv.proteins[PCode] -= 3;
            cv.proteins[(int)P.FCFabricaton] -= 3;
            cv.proteins[(int)P.TransRotaton] += 5;
        }

        if(cv.proteins[PCode] >= 12)
        {
            cell.GetComponent<PMSuicider>().Suicide();
        }
    }
}
