using UnityEngine;
using System.Collections;

public class Restarton12 : Protein
{
    public override int PCode { get { return (int)P.Restarton12; } }

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
        else if(cv.proteins[PCode] >= 12)
        {
            cv.proteins[PCode]-=12;
            cv.Energy += 11.5f * nop.proteinCost;
            cell.GetComponent<PMShifter>().Restart();
        }
    }
}
