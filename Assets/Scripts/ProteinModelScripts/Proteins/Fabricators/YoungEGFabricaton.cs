using UnityEngine;
using System.Collections;

public class YoungEGFabricaton : Protein
{
    public override int PCode { get { return (int)P.YoungEGFabricaton; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[PCode] >= 12)
        {
            cv.proteins[PCode] -= 12;
            cv.proteins[(int)P.YoungEnergivon] += 18;
            cv.Energy -= 9 * nop.proteinCost;
        }
    }
}
