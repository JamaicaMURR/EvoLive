using UnityEngine;
using System.Collections;

public class KSurVCon : Protein
{
    public override int PCode { get { return (int)P.KSurVCon; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[PCode] >= 6)
        {
            int sur = cell.GetComponent<Observer>().GetSurrounding();

            cv.proteins[PCode] -= 6;

            if(sur > 3)
                cv.proteins[(int)P.Killon] += 6;
            else
            {
                cv.proteins[(int)P.VoidConsumon] += 5;
                cv.lifeResource += 0.75f * nop.proteinCost;
            }
        }
    }
}
