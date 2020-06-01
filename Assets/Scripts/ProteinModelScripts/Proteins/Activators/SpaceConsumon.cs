using UnityEngine;
using System.Collections;

public class SpaceConsumon : Protein
{
    public override int PCode { get { return (int)P.SpaceConsumon; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[PCode] >= 3 && cv.proteins[(int)P.FreeConsumon] >= 6)
        {
            cv.proteins[PCode] -= 3;
            cv.proteins[(int)P.FreeConsumon] += 2;
            cv.lifeResource += 0.75f * nop.proteinCost;
        }

        if(cv.proteins[PCode] >= 12)
        {
            cell.GetComponent<PMFreeConsumer>().SpaceConsume();
            cv.proteins[PCode] -= 12;
        }
    }
}
