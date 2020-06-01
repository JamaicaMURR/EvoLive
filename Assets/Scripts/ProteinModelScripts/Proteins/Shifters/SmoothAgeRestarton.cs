using UnityEngine;
using System.Collections;

public class SmoothAgeRestarton : Protein
{
    public override int PCode { get { return (int)P.SmoothAgeRestarton; } }

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
        else if(cv.proteins[PCode] > 0)
        {
            GNM gnm = cell.GetComponent<GNM>();

            float p = (float)gnm.Gci / gnm.Length;

            cv.proteins[PCode]--;

            if(cv.Age >= p)
            {
                cell.GetComponent<PMShifter>().Restart();
            }
            else
            {
                cv.Energy += 0.75f * nop.proteinCost;
            }
        }
    }
}
