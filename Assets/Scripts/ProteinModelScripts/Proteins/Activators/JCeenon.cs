using UnityEngine;
using System.Collections;

public class JCeenon : Protein
{
    public override int PCode { get { return (int)P.JCeenon; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[PCode] >= 12)
        {
            if(cell.GetComponent<PMJCeener>().RelJCeen(0))
            {
                cv.proteins[PCode] -= 12;

                int i = 0;

                while(i < 6 && (cv.proteins[(int)P.TransRotaton] > 0 || cv.proteins[(int)P.Explodon] > 0))
                {
                    if(cv.proteins[(int)P.TransRotaton] > 0)
                    {
                        cv.proteins[(int)P.TransRotaton]--;
                        i++;
                    }

                    if(cv.proteins[(int)P.Explodon] > 0)
                    {
                        cv.proteins[(int)P.Explodon]--;
                        i++;
                    }
                }

                cv.Energy -= (6 - i) * nop.proteinCost;
            }
            else
                cv.proteins[PCode]--;
        }
    }
}
