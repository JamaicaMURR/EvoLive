using UnityEngine;
using System.Collections;

public class EqBomberon : Protein
{
    public override int PCode { get { return (int)P.EqBomberon; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[PCode] >= 18)
        {
            if(cell.GetComponent<PMEqualizer>().RelEqualize(0))
            {
                cv.proteins[PCode] -= 12;
                cv.proteins[(int)P.FreeconsumExplodon] += 4;
            }
            else if(cv.proteins[(int)P.FreeConsumon] > 0)
            {
                cv.proteins[PCode]--;
                cv.Energy -= 4 * nop.proteinCost;
                cv.proteins[(int)P.Suicidon] += 4;
            }
            else
            {
                cv.proteins[PCode] -= 2;
                cv.Energy += 1.75f * nop.proteinCost;
            }
        }
    }
}
