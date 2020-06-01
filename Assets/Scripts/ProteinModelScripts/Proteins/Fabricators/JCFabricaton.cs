using UnityEngine;
using System.Collections;

public class JCFabricaton : Protein
{
    public override int PCode { get { return (int)P.JCFabricaton; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[PCode] >= 3 && cv.proteins[(int)P.VoidConsumon] > 0 && cv.Energy > 24 * nop.proteinCost)
        {
            cv.proteins[PCode]--;
            cv.proteins[(int)P.VoidConsumon]--;
            cv.proteins[(int)P.JCeenon] += 24;
            cv.Energy -= 24 * nop.proteinCost;
        }

        if(cv.proteins[PCode] >= 18 && cv.Energy > 6 * nop.proteinCost)
        {
            cv.proteins[PCode] -= 18;
            cv.proteins[(int)P.JCeenon] += 12;
            cv.proteins[(int)P.MHungeron] += 4;
            cv.proteins[(int)P.InjDeathon] += 6;
            cv.Energy -= 6 * nop.proteinCost;
        }
    }
}
