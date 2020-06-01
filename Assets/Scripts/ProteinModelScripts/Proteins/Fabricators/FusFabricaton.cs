using UnityEngine;
using System.Collections;

public class FusFabricaton : Protein
{
    public override int PCode { get { return (int)P.FusFabricaton; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[PCode] >= 12 && cv.Energy > 30 * nop.proteinCost)
        {
            if(cv.proteins[(int)P.Fuson] > 0)
            {
                cv.proteins[PCode] -= 12;
                cv.proteins[(int)P.Fuson] += 36;
                cv.Energy -= 30 * nop.proteinCost;
            }
            else
            {
                cv.proteins[PCode] -= 12;
                cv.proteins[(int)P.Explodon] += 10;
                cv.lifeResource += nop.proteinCost;
            }
        }
    }
}
