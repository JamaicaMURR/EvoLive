using UnityEngine;
using System.Collections;

public class Accumuton : Protein
{
    public override int PCode { get { return (int)P.Accumuton; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[(int)P.BetaHolyGrailon] >= 18)
        {
            cv.proteins[(int)P.BetaHolyGrailon] -= 18;
            cv.Energy += 8 * nop.proteinCost;
            cv.lifeResource += 8 * nop.proteinCost;
        }

        if(cv.proteins[PCode] >= 12)
        {
            GameObject target = cell.GetComponent<Observer>().GetCellInFront();

            if(target != null)
            {
                float nep = 1 - target.GetComponent<CellVars>().Energy;
                int portionsNeed = (int)(nep / 10 * nop.proteinCost);
                int portionsHave = cv.proteins[PCode] / 12;

                if(portionsHave > portionsNeed)
                    portionsHave = portionsNeed;

                if(portionsHave > 0)
                {
                    cell.GetComponent<PMEnergiver>().RelGive(0, 10 * nop.proteinCost * portionsHave);
                    cv.proteins[PCode] -= 12 * portionsHave;
                }
            }
        }
    }
}
