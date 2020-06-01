using UnityEngine;
using System.Collections;

public class KilOldExTranson : Protein
{
    public override int PCode { get { return (int)P.KilOldExTranson; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[PCode] >= 4)
        {
            if(cv.Age < 0.25)
            {
                cv.proteins[PCode] -= 4;
                cv.proteins[(int)P.Killon] += 3;
                cv.Energy += 0.75f * nop.proteinCost;
            }

            if(cv.Age > 0.5)
            {
                cv.proteins[PCode] -= 4;
                cv.proteins[(int)P.Explodon] += 4;
            }
        }
    }
}
