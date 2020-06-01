using UnityEngine;
using System.Collections;

public class SuiNExplUtiliton : Protein
{
    public override int PCode { get { return (int)P.SuiNExplUtiliton; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[PCode] >= 6 && cv.proteins[(int)P.Suicidon] >= 6)
        {
            cv.proteins[PCode] -= 6;
            cv.proteins[(int)P.Suicidon] -= 3;
            cv.proteins[(int)P.Explodon] += 3;
            cv.Energy += 5 * nop.proteinCost;
        }

        if(cv.proteins[PCode] >= 3 && cv.proteins[(int)P.Explodon] >= 6)
        {
            cv.proteins[PCode] -= 3;
            cv.proteins[(int)P.Explodon] -= 6;
            cv.Energy += 8 * nop.proteinCost;
        }

        if(cv.proteins[PCode] >=18)
        {
            cv.proteins[PCode] -= 12;
            cv.proteins[(int)P.ShiftIngibiton] += 4;
            cv.Energy += 6 * nop.proteinCost;
        }
    }
}
