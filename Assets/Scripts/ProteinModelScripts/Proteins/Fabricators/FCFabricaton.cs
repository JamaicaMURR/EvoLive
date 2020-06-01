using UnityEngine;
using System.Collections;

public class FCFabricaton : Protein
{
    public override int PCode { get { return (int)P.FCFabricaton; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[PCode] >= 6 && cv.Energy > 8 * nop.proteinCost)
        {
            cv.proteins[PCode] -= 6;
            cv.proteins[(int)P.FreeConsumon] += 12;
            cv.Energy -= 8 * nop.proteinCost;
        }
    }
}
