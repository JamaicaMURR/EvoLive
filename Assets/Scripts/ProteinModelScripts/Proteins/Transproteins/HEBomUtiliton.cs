using UnityEngine;
using System.Collections;

public class HEBomUtiliton : Protein
{
    public override int PCode { get { return (int)P.HEBomUtiliton; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[PCode] >= 2 && cv.proteins[(int)P.HighEnBomberon] >= 2)
        {
            cv.proteins[PCode] -= 2;
            cv.proteins[(int)P.HighEnBomberon] -= 2;
            cv.proteins[(int)P.TransRotaton] += 3;
        }

        if(cv.proteins[PCode]>=12)
        {
            cv.proteins[PCode] -= 12;
            cv.proteins[(int)P.TransRotaton] += 10;
        }
    }
}
