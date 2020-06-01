using UnityEngine;
using System.Collections;

public class NavRestartonAB : Protein
{
    public override int PCode { get { return (int)P.NavRestartonAB; } }

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
            else if(cell.GetComponent<TNC>().Dir == TNC.NormalizeDir(cv.bornDir + 3))
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
