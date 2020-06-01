using UnityEngine;
using System.Collections;

public class PExchangon : Protein
{
    public override int PCode { get { return (int)P.PExchangon; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        Convert(cell, P.FCPlaguon, P.PExchangon, 12);

        if(cv.proteins[PCode] >= 12)
        {
            cv.proteins[PCode] -= 12;

            if(!cell.GetComponent<PMSprayer>().RelProteinExchange(0))
            {
                cv.proteins[PCode] += 6;
                cv.Energy += 5.5f * nop.proteinCost;
            }
            else if (cv.proteins[(int)P.KissGearon]>=6)
            {
                cv.proteins[(int)P.KissGearon] -= 6;
                cv.proteins[PCode] += 12;
            }
            else
            {
                cv.proteins[(int)P.TransRotaton] += 6;
            }
        }
    }
}
