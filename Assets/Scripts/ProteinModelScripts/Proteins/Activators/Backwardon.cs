using UnityEngine;
using System.Collections;

public class Backwardon : Protein
{
    public override int PCode { get { return (int)P.Backwardon; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        Convert(cell, P.Movon, P.Backwardon, 12);

        if(cv.proteins[PCode] >= 12)
        {
            if(cell.GetComponent<PMMover>().RelMove(3, true, 3))
            {
                cv.proteins[PCode] -= 12;
            }
            else
            {
                cv.proteins[PCode]--;
                cv.proteins[(int)P.AlphaHolyGrailon]++;
            }
        }

        if(cv.proteins[(int)P.SPrPrion] > 0)
        {
            cv.proteins[(int)P.SPrPrion]--;
            cv.Energy += nop.proteinCost;
        }
    }
}
