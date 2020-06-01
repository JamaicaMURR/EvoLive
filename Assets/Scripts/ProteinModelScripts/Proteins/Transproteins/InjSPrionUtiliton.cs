using UnityEngine;
using System.Collections;

public class InjSPrionUtiliton : Protein
{
    public override int PCode { get { return (int)P.InjSPrionUtiliton; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[PCode] >= 6 && cv.proteins[(int)P.InjSPrion] >= 3)
        {
            cv.proteins[PCode] -= 6;
            cv.proteins[(int)P.InjSPrion] -= 3;
            cv.proteins[(int)P.InjectIngibiton] += 4;
            cv.Energy += 4 * nop.proteinCost;
        }

        if(cv.proteins[(int)P.InjectIngibiton] >= 12)
        {
            cv.proteins[(int)P.InjectIngibiton] -= 12;
            cv.proteins[PCode] += 9;
            cv.Energy += 2 * nop.proteinCost;
        }

        if(cv.proteins[PCode] >= 36)
        {
            cv.proteins[PCode] -= 30;
            cv.Energy += 24 * nop.proteinCost;
        }
    }
}
