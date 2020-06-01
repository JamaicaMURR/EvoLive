using UnityEngine;
using System.Collections;

public class SCSinkon : Protein
{
    public override int PCode { get { return (int)P.SCSinkon; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        int sur = cell.GetComponent<Observer>().GetSurrounding();

        if(cv.proteins[PCode] >= 12 && cv.proteins[(int)P.SpaceConsumon] >= 6 && sur == 6)
        {
            cv.proteins[PCode] -= 3;
            cv.proteins[(int)P.SpaceConsumon] -= 6;

            if(!cell.GetComponent<PMSprayer>().RelProteinGive(0, P.SpaceConsumon, 6))
            {
                cv.proteins[(int)P.SpaceConsumon] += 8;
                cv.lifeResource += 0.5f * nop.proteinCost;
            }
        }
    }
}
