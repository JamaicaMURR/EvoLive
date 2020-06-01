using UnityEngine;
using System.Collections;

public class CellConsumon : Protein
{
    public override int PCode { get { return (int)P.CellConsumon; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[PCode] >= 12)
        {
            if(cell.GetComponent<PMCellConsumer>().RelConsume(0))
            {
                cv.proteins[PCode] -= 12;
            }
            else
            {
                cv.proteins[PCode]--;
                cv.lifeResource += 0.75f * nop.lifeResource;
            }
        }
    }
}
