using UnityEngine;
using System.Collections;

public class MAFon : Protein
{
    public override int PCode { get { return (int)P.MAFon; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[PCode] >= 3 && cv.proteins[(int)P.GammaHolyGrailon] == 0)
        {
            cv.proteins[PCode] -= 3;
            cv.proteins[(int)P.Movon]++;
            cv.proteins[(int)P.MoveAcceleron]++;
            cv.proteins[(int)P.Fuson]++;
        }
        else if(cv.proteins[(int)P.FusFabricaton] >= 9)
        {
            if(cell.GetComponent<PMMover>().RelMove(0, true))
            {
                cv.proteins[(int)P.FusFabricaton] -= 9;
                cv.proteins[PCode] -= 3;
                cv.Energy += 8 * nop.proteinCost;
            }
        }
    }
}
