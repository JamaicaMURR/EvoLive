using UnityEngine;
using System.Collections;

public class FcWVcoon : Protein
{
    public override int PCode { get { return (int)P.FcWVcoon; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[PCode] > 0)
        {
            cv.proteins[PCode]--;
            cv.lifeResource += 0.75f * nop.proteinCost;

            if(cv.proteins[(int)P.VoidConsumon] >= 6 && cv.Energy > 6 * nop.proteinCost)
            {
                cv.proteins[(int)P.VoidConsumon] -= 6;
                cv.Energy -= 6 * nop.proteinCost;

                cell.GetComponent<PMFreeConsumer>().FreeConsume();
            }
        }
    }
}
