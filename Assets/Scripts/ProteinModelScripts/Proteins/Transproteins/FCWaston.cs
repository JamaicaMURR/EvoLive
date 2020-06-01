using UnityEngine;
using System.Collections;

public class FCWaston : Protein
{
    public override int PCode { get { return (int)P.FCWaston; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[PCode] > 0)
        {
            cv.lifeResource += 0.95f * cv.proteins[PCode] * nop.proteinCost;
            cv.proteins[PCode] = 0;
            cv.Energy += 0.85f * cv.proteins[(int)P.FreeConsumon] * nop.proteinCost;
            cv.proteins[(int)P.FreeConsumon] = 0;
        }
    }
}
