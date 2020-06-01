using UnityEngine;
using System.Collections;

public class FCDeshifton : Protein
{
    public override int PCode { get { return (int)P.FCDeshifton; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[PCode] > 0 && cv.proteins[(int)P.FreeConsumon] > 0)
        {
            cv.proteins[PCode]--;
            cv.proteins[(int)P.ShiftIngibiton]++;
        }

        if(cv.proteins[PCode] >= 36)
        {
            cv.proteins[PCode] -= 36;
            cv.proteins[(int)P.SuiNExplUtiliton]++;
            cv.lifeResource += 34 * nop.proteinCost;
        }
    }
}
