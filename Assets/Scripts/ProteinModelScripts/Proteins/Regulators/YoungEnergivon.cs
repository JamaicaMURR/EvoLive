using UnityEngine;
using System.Collections;

public class YoungEnergivon : Protein
{
    public override int PCode { get { return (int)P.YoungEnergivon; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[PCode] >= 6 && cv.Age < 0.5)
        {
            cv.proteins[PCode] -= 6;
            cv.Energy += 5 * nop.proteinCost;
        }
    }
}
