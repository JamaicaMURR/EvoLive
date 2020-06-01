using UnityEngine;
using System.Collections;

public class PopCornon : Protein
{
    public override int PCode { get { return (int)P.PopCornon; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[PCode] >= 36)
        {
            cv.proteins[(int)P.Spamon] += 32;
        }
    }
}
