using UnityEngine;
using System.Collections;

public class FCExpUtiliton : Protein
{
    public override int PCode { get { return (int)P.FCExpUtiliton; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[PCode] >= 2 && cv.proteins[(int)P.FreeconsumExplodon] >= 2)
        {
            cv.proteins[PCode] -= 2;
            cv.proteins[(int)P.FreeconsumExplodon] -= 2;
            cv.proteins[(int)P.KissGearon]++;
            cv.Energy += 2 * nop.proteinCost;
        }

        if(cv.proteins[PCode] > 0 && cv.proteins[(int)P.AlphaHolyGrailon] >= 12)
        {
            cv.proteins[(int)P.AlphaHolyGrailon] += 6;
            cv.Energy -= 6 * nop.proteinCost;
            cv.lifeResource -= 6 * nop.proteinCost;
        }
    }
}
