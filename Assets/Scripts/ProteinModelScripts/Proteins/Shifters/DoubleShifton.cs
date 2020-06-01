using UnityEngine;
using System.Collections;

public class DoubleShifton : Protein
{
    public override int PCode { get { return (int)P.DoubleShifton; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.DSLabel < 0)
            cv.DSLabel = cell.GetComponent<GNM>().Gci;

        if(cv.proteins[PCode] > 0)
        {
            if(cv.proteins[(int)P.ShiftIngibiton] > 0)
            {
                cv.proteins[(int)P.ShiftIngibiton]--;
                cv.proteins[PCode]--;
                cv.Energy += 1.5f * nop.proteinCost;
            }
            else
            {
                cv.proteins[PCode]--;
                cell.GetComponent<PMShifter>().Point(cv.DSLabel);
            }
        }
    }
}
