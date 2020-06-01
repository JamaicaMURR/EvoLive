using UnityEngine;
using System.Collections;

public class MaklUtiliton : Protein
{
    public override int PCode { get { return (int)P.MaklUtiliton; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[PCode] >= 2 && cv.proteins[(int)P.Maklayon] >= 2)
        {
            cv.proteins[PCode] -= 2;
            cv.proteins[(int)P.Maklayon] -= 2;
            cv.proteins[(int)P.FreeconsumExplodon] += 3;
        }

        if(cv.proteins[PCode] >= 18)
        {
            cv.proteins[PCode] -= 12;
            cv.proteins[(int)P.MoveAcceleron] += 9;
            cv.Energy += 2 * nop.proteinCost;
        }
    }
}
