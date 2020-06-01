using UnityEngine;
using System.Collections;

public class FC6Restarton : Protein
{
    public override int PCode { get { return (int)P.FC6Restarton; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[PCode] > 0)
        {
            if(cv.proteins[(int)P.ShiftIngibiton] > 0)
            {
                cv.proteins[(int)P.ShiftIngibiton]--;
                cv.proteins[PCode]--;
                cv.Energy += 1.5f * nop.proteinCost;
            }
            else if(cv.proteins[(int)P.FreeConsumon] > 6)
            {
                cv.proteins[PCode]--;
                cell.GetComponent<PMShifter>().Restart();
            }
            else
            {
                cv.proteins[PCode]--;
                cv.lifeResource += 1.25f * nop.proteinCost;
                cv.Energy -= 2 * nop.proteinCost;
            }
        }
    }
}
