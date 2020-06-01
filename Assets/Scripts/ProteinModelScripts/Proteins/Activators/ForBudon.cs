using UnityEngine;
using System.Collections;

public class ForBudon : Protein
{
    public override int PCode { get { return (int)P.ForBudon; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[PCode] >= 6 && cv.Energy > 0.25)
        {
            int dir = cell.GetComponent<TNC>().Dir;

            if(cell.GetComponent<PMSpamer>().SetBud(dir, 0.25f))
            {
                cv.proteins[PCode] -= 6;
                cv.Energy -= 0.25f;
                cv.lifeResource += 4 * nop.proteinCost;
            }
            else
            {
                cv.proteins[PCode]--;
                cv.lifeResource += 0.75f * nop.proteinCost;
            }
        }
    }
}
