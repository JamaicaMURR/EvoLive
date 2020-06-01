using UnityEngine;
using System.Collections;

public class HEnTMovon : Protein
{
    public override int PCode { get { return (int)P.HEnTMovon; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        cv.proteins[PCode]--;

        if(cv.Energy >=0.75)
        {
            cv.proteins[(int)P.Movon] += 4;
            cv.Energy -= 4 * nop.proteinCost;
        }
        else if(cv.Energy >= 0.5)
        {
            cv.proteins[(int)P.Movon] += 3;
            cv.Energy -= 3 * nop.proteinCost;
        }
        else if(cv.Energy >= 0.25)
        {
            cv.proteins[(int)P.Movon] += 2;
            cv.Energy -= 2 * nop.proteinCost;
        }
        else
        {
            cv.proteins[(int)P.SplitDeenergon]++;
        }
    }
}
