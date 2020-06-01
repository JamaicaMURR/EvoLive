using UnityEngine;
using System.Collections;

public class ImidfromFCFuson : Protein
{
    public override int PCode { get { return (int)P.ImidfromFCFuson; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[PCode] >= 6)
        {
            cv.proteins[PCode]--;
            cv.Energy += 0.5f * nop.proteinCost;
            cv.lifeResource += 0.25f * nop.proteinCost;

            if(cv.proteins[(int)P.FreeConsumon] >= 12)
            {
                cv.proteins[(int)P.FreeConsumon] -= 12;

                if(!cell.GetComponent<PMFuser>().RelFuse(0))
                {
                    cv.proteins[(int)P.FusFabricaton] += 11;
                    cv.lifeResource += 0.75f * nop.proteinCost;
                }
            }
        }
    }
}
