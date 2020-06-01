using UnityEngine;
using System.Collections;

public class HeritShifton : Protein
{
    public override int PCode { get { return (int)P.HeritShifton; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[(int)P.ShiftIngibiton] >= 2)
        {
            cv.proteins[(int)P.ShiftIngibiton] -= 2;
            cv.proteins[PCode]--;
            cv.lifeResource += 1.75f * nop.proteinCost;
            cv.proteins[(int)P.PFabricaton]++;
        }
        else if(cv.Age > 0.125)
        {
            cv.proteins[PCode]--;

            cell.GetComponent<PMShifter>().Shift(cv.proteins[PCode]);
        }
    }
}
