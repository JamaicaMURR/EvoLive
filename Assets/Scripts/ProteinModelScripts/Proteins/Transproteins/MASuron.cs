using UnityEngine;
using System.Collections;

public class MASuron : Protein
{
    public override int PCode { get { return (int)P.MASuron; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        int sur = cell.GetComponent<Observer>().GetSurrounding();

        if(cv.proteins[PCode] >= 12)
        {
            if(sur == 6)
            {
                cv.proteins[PCode] -= 12;
                cv.proteins[(int)P.LowEnRestarton] += 12;
            }
            else
            {
                cv.proteins[PCode] -= 6;
                cv.Energy -= 13 * nop.proteinCost;
                cv.proteins[(int)P.MoveAcceleron] += 6;
                cv.proteins[(int)P.Conservon] += 12;
            }
        }

        if(cv.proteins[(int)P.LowEnRestarton]>=24)
        {
            cv.proteins[(int)P.LowEnRestarton] -= 24;
            cv.lifeResource += 23.5f * nop.proteinCost;
        }
    }
}
