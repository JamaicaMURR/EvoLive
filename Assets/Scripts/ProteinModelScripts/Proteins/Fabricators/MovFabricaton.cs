using UnityEngine;
using System.Collections;

public class MovFabricaton : Protein
{
    public override int PCode { get { return (int)P.MovFabricaton; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[PCode] >= 3)
        {
            cv.proteins[PCode] -= 3;
            cv.proteins[(int)P.Movon] += 18;
            cv.proteins[(int)P.Rebirthon]++;
            cv.Energy -= 18 * nop.proteinCost;
        }
    }
}
