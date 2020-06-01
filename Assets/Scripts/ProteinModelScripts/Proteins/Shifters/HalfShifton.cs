using UnityEngine;
using System.Collections;

public class HalfShifton : Protein
{
    public override int PCode { get { return (int)P.HalfShifton; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[(int)P.ShiftIngibiton] >= 2)
        {
            cv.proteins[(int)P.ShiftIngibiton] -= 2;
            cv.proteins[PCode]--;
            cv.Energy += 2.75f * nop.proteinCost;
        }
        else if(cv.proteins[PCode] > 0)
        {
            cv.proteins[PCode]--;

            GNM g = cell.GetComponent<GNM>();

            int s = g.Length / 2;

            cell.GetComponent<PMShifter>().Shift(s);
        }
    }
}
