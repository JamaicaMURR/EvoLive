using UnityEngine;
using System.Collections;

public class TransBetaRestarton12 : Protein
{
    public override int PCode { get { return (int)P.TransBetaRestarton12; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[PCode] > 0)
        {
            cv.proteins[PCode] --;
            cv.proteins[(int)P.Restarton12] ++;
        }

        if(cv.proteins[(int)P.Restarton12] >=36)
        {
            cv.proteins[(int)P.Restarton12] -= 36;
            cv.proteins[(int)P.Explodon] += 24;
            cv.Energy += 11.5f * nop.proteinCost;
        }
    }
}
