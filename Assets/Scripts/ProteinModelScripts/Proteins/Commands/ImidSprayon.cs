using UnityEngine;
using System.Collections;

public class ImidSprayon : Protein
{
    public override int PCode { get { return (int)P.ImidSprayon; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[PCode] >= 4)
        {
            cv.proteins[PCode]--;
            cv.Energy -= 0.5f * nop.proteinCost;
            cv.proteins[(int)P.MovFabricaton]++;

            if(cv.proteins[(int)P.PBomberon] + cv.proteins[(int)P.LightSpeedon] + cv.proteins[(int)P.YoungEGFabricaton] >= 12)
            {
                int i = 0;

                while(i < 12)
                {
                    if(cv.proteins[(int)P.PBomberon] > 0)
                    {
                        i++;
                        cv.proteins[(int)P.PBomberon]--;
                    }

                    if(cv.proteins[(int)P.LightSpeedon] > 0)
                    {
                        i++;
                        cv.proteins[(int)P.LightSpeedon]--;
                    }

                    if(cv.proteins[(int)P.YoungEGFabricaton] > 0)
                    {
                        i++;
                        cv.proteins[(int)P.YoungEGFabricaton]--;
                    }
                }

                cell.GetComponent<PMSprayer>().Spray();
            }
        }
    }
}
