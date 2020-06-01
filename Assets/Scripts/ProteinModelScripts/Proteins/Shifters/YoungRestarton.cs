using UnityEngine;
using System.Collections;

public class YoungRestarton : Protein
{
    public override int PCode { get { return (int)P.YoungRestarton; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[PCode] > 0 && cv.Age < 0.5)
        {
            if(cv.Age < 0.5)
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
