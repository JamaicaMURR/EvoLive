using UnityEngine;
using System.Collections;

public class Spliton : Protein
{
    public override int PCode { get { return (int)P.Spliton; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[(int)P.SplitPrion] > 0)
        {
            int problemsize = cv.proteins[(int)P.SplitPrion];

            if(cv.proteins[(int)P.SplitPrion] > cv.proteins[PCode])
                problemsize = cv.proteins[PCode];

            cv.proteins[PCode] -= problemsize;
            cv.proteins[(int)P.SplitPrion] += problemsize;
        }

        if(cv.proteins[(int)P.PopCornon] >= 18)
        {
            cv.proteins[(int)P.PopCornon] -= 18;
            cell.GetComponent<PMSprayer>().CustomSpray((int)P.PopCornon, 12);
        }
        else if(cv.proteins[PCode] >= 12)
        {
            cv.proteins[PCode] -= 12;

            if(cell.GetComponent<PMSplitter>().RelSplit(0))
            {
                cv.Energy -= cv.proteins[(int)P.SplitDeenergon] * nop.proteinCost;
                cv.proteins[(int)P.SplitDeenergon] = 0;
            }
            else
                cv.proteins[PCode] += 11;
        }
    }
}
