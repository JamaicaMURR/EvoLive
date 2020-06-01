using UnityEngine;
using System.Collections;

public class Fuson : Protein
{
    public override int PCode { get { return (int)P.Fuson; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[PCode] > 0 && cv.proteins[(int)P.SpaceConsumon] > 0)
        {
            cv.proteins[(int)P.SpaceConsumon] += 3;
            cv.Energy -= 4.25f * nop.proteinCost;
        }

        if(cv.proteins[PCode] > 0 && cv.proteins[(int)P.MHungeron] >= 3)
        {
            cv.proteins[(int)P.MHungeron] -= 3;
            cv.Energy += 2.75f * nop.proteinCost;
        }

        if(cv.proteins[PCode] >= 12)
        {
            if(cv.proteins[(int)P.Nothingon] > 0)
                cell.GetComponent<PMSuicider>().Suicide();
            else
            {
                cv.proteins[PCode] -= 12;

                if(!cell.GetComponent<PMFuser>().RelFuse(0))
                    cv.proteins[PCode] += 11;
            }
        }


    }
}
