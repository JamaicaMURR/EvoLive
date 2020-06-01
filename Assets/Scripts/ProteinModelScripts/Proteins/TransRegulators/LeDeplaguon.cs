using UnityEngine;
using System.Collections;

public class LeDeplaguon : Protein
{
    public override int PCode { get { return (int)P.LeDeplaguon; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[PCode] > 0 && cv.proteins[(int)P.FCPlaguon] > 0 && cv.Energy < 0.25)
        {
            cv.proteins[PCode]--;
            cv.proteins[(int)P.FCPlaguon]--;
            cv.proteins[(int)P.Doubleton]++;
        }

        if(cv.proteins[PCode] >= 36)
        {
            cv.proteins[PCode] -= 24;
            cv.proteins[(int)P.TransRestarton12] += 12;
            cv.Energy += 11.5f * nop.proteinCost;
        }

        if(cv.proteins[(int)P.FCPlaguon] > 0 && cv.proteins[(int)P.TransRestarton12] >= 12)
        {
            cell.GetComponent<PMExploder>().Explode();
        }
    }
}
