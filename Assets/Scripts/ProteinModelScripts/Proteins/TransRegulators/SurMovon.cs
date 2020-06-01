using UnityEngine;
using System.Collections;

public class SurMovon : Protein
{
    public override int PCode { get { return (int)P.SurMovon; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[PCode] >= 6)
        {
            int sur = cell.GetComponent<Observer>().GetSurrounding();

            cv.proteins[PCode] -= 6;

            if(sur < 3)
                cv.proteins[(int)P.Movon] += 6;
            else
                cv.lifeResource += 5.75f * nop.proteinCost;
        }
    }
}
