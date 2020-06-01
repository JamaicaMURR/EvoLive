using UnityEngine;
using System.Collections;

public class Spamon : Protein
{
    public override int PCode { get { return (int)P.Spamon; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[PCode] >= 36)
        {
            cell.GetComponent<PMSpamer>().Spam();            
        }
    }
}
