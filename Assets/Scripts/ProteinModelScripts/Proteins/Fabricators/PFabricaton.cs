using UnityEngine;
using System.Collections;

public class PFabricaton : Protein
{
    public override int PCode { get { return (int)P.PFabricaton; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[PCode] >= 36 && cv.Energy > 36 * nop.proteinCost)
        {
            cv.proteins[PCode] -= 36;
            cv.proteins[(int)P.Pushon] += 72;
            cv.Energy -= 36.5f * nop.proteinCost;
        }
    }
}
