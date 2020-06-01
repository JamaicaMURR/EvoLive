using UnityEngine;
using System.Collections;

public class HighEnBomberon : Protein
{
    public override int PCode { get { return (int)P.HighEnBomberon; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();

        if(cv.proteins[PCode] >= 4 && cv.Energy > 0.5)
        {
            cv.proteins[PCode] -= 4;
            cv.proteins[(int)P.FreeconsumExplodon] += 3;
        }
    }
}
