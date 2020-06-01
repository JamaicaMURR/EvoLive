using UnityEngine;
using System.Collections;

public class GForBudon : Protein
{
    public override int PCode { get { return (int)P.GForBudon; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[PCode] >= 12 && cv.Energy > 0.5)
        {
            int dir = cell.GetComponent<TNC>().Dir;

            if(cell.GetComponent<PMSpamer>().SetBud(dir, 0.5f * cv.Energy))
            {
                cv.proteins[PCode] -= 12;
                cv.Energy -= 0.5f * cv.Energy;
                cv.lifeResource += 9 * nop.proteinCost;
            }
            else
            {
                cv.proteins[PCode]--;
                cv.lifeResource += 0.75f * nop.proteinCost;
            }
        }
    }
}
