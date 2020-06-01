using UnityEngine;
using System.Collections;

public class Sprayon : Protein
{
    public override int PCode { get { return (int)P.Sprayon; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[PCode] >= 12)
        {
            cv.proteins[PCode] -= 12;
            cell.GetComponent<PMSprayer>().Spray();
        }

        if(cv.proteins[PCode] >= 3 && cv.proteins[(int)P.SPrPrion] > 0)
        {
            cv.proteins[PCode] -= 2;
            cv.Energy -= nop.proteinCost;
            cv.proteins[(int)P.SPrPrion]++;
            cv.proteins[(int)P.SplitDeenergon]++;
        }
    }
}
