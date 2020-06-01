using UnityEngine;
using System.Collections;

public class HighEnDeathon : Protein
{
    public override int PCode { get { return (int)P.HighEnDeathon; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();
        GNM g = cell.GetComponent<GNM>();

        float a = (float)g.Gci / g.Length;

        if(cv.proteins[PCode] >= 16 && cv.Energy > a)
        {
            cv.proteins[PCode] -= 16;
            cv.proteins[(int)P.Suicidon] += 8;
            cv.lifeResource -= 8 * nop.proteinCost;
            cv.Energy += 8 * nop.proteinCost;
        }
    }
}
