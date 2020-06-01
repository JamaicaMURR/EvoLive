using UnityEngine;
using System.Collections;

public class Energivon : Protein
{
    public override int PCode { get { return (int)P.EnerGivon; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[PCode] >= 12)
        {
            if(cell.GetComponent<PMEnergiver>().RelGive(0, 10 * nop.proteinCost))
                cv.proteins[PCode] -= 12;
            else
            {
                cv.proteins[PCode]--;
                cv.proteins[(int)P.KilOldExTranson]++;
            }
        }
    }
}
