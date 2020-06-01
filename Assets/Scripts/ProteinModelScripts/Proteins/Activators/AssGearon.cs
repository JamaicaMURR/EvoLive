using UnityEngine;
using System.Collections;

public class AssGearon : Protein
{
    public override int PCode { get { return (int)P.AssGearon; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[PCode] < 12 && cv.proteins[PCode] + cv.proteins[(int)P.TransRotaton] >= 12)
        {
            cv.proteins[(int)P.TransRotaton] -= 12 - cv.proteins[PCode];
            cv.proteins[PCode] += 12 - cv.proteins[PCode];
        }

        if(cv.proteins[PCode] >= 12)
        {
            if(cell.GetComponent<PMGearer>().AbsGear(cell.GetComponent<TNC>().Dir))
            {
                cv.proteins[PCode] -= 12;
            }
            else
            {
                cv.proteins[PCode]--;
                cv.lifeResource += 0.5f * nop.proteinCost;
                cv.Energy += 0.25f * nop.proteinCost;
            }
        }
    }
}
