using UnityEngine;
using System.Collections;

public class Conservon : Protein
{
    public override int PCode { get { return (int)P.Conservon; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();
        
        if(cv.proteins[PCode] >= 16 && cv.Age > 0.25)
        {
            cv.proteins[PCode] -= 16;
            cv.lifeResource += 15.5f * nop.proteinCost;
        }
    }
}
