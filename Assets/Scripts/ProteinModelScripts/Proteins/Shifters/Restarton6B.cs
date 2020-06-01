using UnityEngine;
using System.Collections;

public class Restarton6B : Protein
{
    public override int PCode { get { return (int)P.Restarton6B; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[(int)P.ShiftIngibiton] > 0)
        {
            cv.proteins[(int)P.ShiftIngibiton]--;
            cv.proteins[PCode]--;
            cv.Energy += 1.5f * nop.proteinCost;
        }
        else if(cv.proteins[PCode] >= 6)
        {
            cv.proteins[PCode]--;
            cv.Energy += 0.5f * nop.proteinCost;
            cell.GetComponent<PMShifter>().Restart();
        }
    }
}
