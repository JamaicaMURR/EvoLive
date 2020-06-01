using UnityEngine;
using System.Collections;

public class FreConUtiliton : Protein
{
    public override int PCode { get { return (int)P.FreConUtiliton; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[PCode] >= 2 && cv.proteins[(int)P.FreeConsumon]>=4)
        {
            cv.proteins[PCode] -= 2;
            cv.proteins[(int)P.FreeConsumon] -= 4;
            cv.Energy += 5.75f * nop.proteinCost;
        }
    }
}
