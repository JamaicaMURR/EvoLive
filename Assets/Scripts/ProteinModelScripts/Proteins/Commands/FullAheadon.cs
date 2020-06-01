using UnityEngine;
using System.Collections;

public class FullAheadon : Protein
{
    public override int PCode { get { return (int)P.FullAheadon; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[PCode] > 0)
        {
            bool isMoved = false;

            if(cv.proteins[(int)P.Movon] >= 12)
            {
                if(cell.GetComponent<PMMover>().RelMove(0, true))
                {
                    cv.proteins[(int)P.Movon] -= 12;
                    isMoved = true;
                }
            }

            if(!isMoved && cv.proteins[(int)P.Swapon] >= 12)
            {
                if(cell.GetComponent<PMSwaper>().RelSwap(0))
                    cv.proteins[(int)P.Swapon] -= 12;
            }

            cv.proteins[PCode]--;
            cv.Energy += 0.5f * nop.proteinCost;
        }
    }
}
