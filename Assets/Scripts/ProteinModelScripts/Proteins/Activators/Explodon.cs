using UnityEngine;
using System.Collections;

public class Explodon : Protein
{
    public override int PCode { get { return (int)P.Explodon; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[PCode] > 0 && cv.proteins[(int)P.SpaceConsumon] > 0)
        {
            cv.proteins[(int)P.SpaceConsumon]++;
            cv.Energy -= 1.25f * nop.proteinCost;
        }

        if(cv.proteins[PCode] >= 3 && cv.proteins[(int)P.FCPlaguon] >= 4)
        {
            cv.proteins[PCode] -= 3;
            cv.proteins[(int)P.FCPlaguon] -= 4;
            cv.proteins[(int)P.Spliton] += 6;
        }

        if(cv.proteins[PCode] >= 12)
        {
            cell.GetComponent<PMExploder>().Explode();
        }
    }
}
