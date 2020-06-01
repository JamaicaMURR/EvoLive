using UnityEngine;
using System.Collections;

public class HighEnSPRegulon : Protein
{
    public override int PCode { get { return (int)P.HighEnSPRegulon; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[PCode] >= 6 && cv.Energy > 0.75)
        {
            cv.proteins[PCode] -= 6;
            cv.proteins[(int)P.SplitPrion] += 12;
            cv.Energy -= 8 * nop.proteinCost;
        }
    }
}
