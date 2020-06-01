using UnityEngine;
using System.Collections;

public class OnceRestarton : Protein
{
    public override int PCode { get { return (int)P.OnceRestarton; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[PCode] > 0 && !cv.ORLabel)
        {
            if(cv.proteins[(int)P.ShiftIngibiton] > 0)
            {
                cv.proteins[(int)P.ShiftIngibiton]--;
                cv.proteins[PCode]--;
                cv.Energy += 1.5f * nop.proteinCost;
            }
            else if(!cv.ORLabel)
            {
                cv.proteins[PCode]--;
                cell.GetComponent<PMShifter>().Restart();
                cv.ORLabel = true;
            }
            else
            {
                cv.proteins[PCode]--;
                cv.Energy += 0.75f * nop.proteinCost;
            }
        }
    }
}
