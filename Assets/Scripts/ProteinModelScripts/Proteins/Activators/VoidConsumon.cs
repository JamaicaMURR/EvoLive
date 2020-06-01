using UnityEngine;
using System.Collections;

public class VoidConsumon : Protein
{
    public override int PCode { get { return (int)P.VoidConsumon; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[PCode] < 12 && cv.proteins[PCode] + cv.proteins[(int)P.FCPlagStarton] >= 12)
        {
            cv.proteins[(int)P.FCPlagStarton] -= 12 - cv.proteins[PCode];
            cv.proteins[PCode] += 12 - cv.proteins[PCode];
        }

        if(cv.proteins[PCode] >= 12)
        {
            if(cell.GetComponent<PMVoidConsumer>().RelConsume(0))
            {
                cv.proteins[PCode] -= 12;
                cv.proteins[(int)P.FreConUtiliton]++;
            }
            else
            {
                cv.proteins[PCode]--;
                cv.lifeResource += 0.5f * nop.proteinCost;
            }
        }
    }
}
