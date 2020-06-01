using UnityEngine;
using System.Collections;

public class EcKillon : Protein
{
    public override int PCode { get { return (int)P.EcKillon; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        Convert(cell, P.Killon, P.EcKillon, 6);

        if(cv.proteins[PCode] >= 6)
        {
            if(cell.GetComponent<PMKiller>().RelKill(0))
            {
                cv.proteins[PCode] -= 6;
            }
            else
            {
                cv.proteins[PCode] -= 3;
                cv.Energy += 2.5f * nop.proteinCost;
            }
        }
    }
}
