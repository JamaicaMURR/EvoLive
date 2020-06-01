using UnityEngine;
using System.Collections;

public class AnothDoubleton : Protein
{
    public override int PCode { get { return (int)P.AnothDoubleton; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        Convert(cell, P.EnerGivon, P.AnothDoubleton, 24);

        if(cv.proteins[PCode] >= 24)
        {
            cv.proteins[PCode] -= 24;

            if(cv.Energy > 0.75)
            {
                if(!cell.GetComponent<PMSpamer>().Double())
                {
                    cv.proteins[PCode] += 12;
                    cv.Energy += 6 * nop.proteinCost;
                    cv.lifeResource += 5 * nop.proteinCost;
                }
            }
            else
            {
                cv.proteins[PCode] -= 12;
                cv.Energy += 11.5f * nop.proteinCost;
            }
        }
    }
}
