using UnityEngine;
using System.Collections;

public class LowEnRestarton : Protein
{
    public override int PCode { get { return (int)P.LowEnRestarton; } }

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
            else if(cv.Energy < 0.5)
            {
                cv.proteins[PCode]--;
                cell.GetComponent<PMShifter>().Restart();
            }
            else
            {
                cv.proteins[PCode]--;
                cv.Energy += 0.5f * nop.proteinCost;
            }
        }
    }
}
