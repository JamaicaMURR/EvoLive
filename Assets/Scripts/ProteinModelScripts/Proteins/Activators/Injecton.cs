using UnityEngine;
using System.Collections;

public class Injecton : Protein
{
    public override int PCode { get { return (int)P.Injecton; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[PCode] > 0 && cv.proteins[(int)P.InjRevoluton] > 0 && cv.Energy > nop.proteinCost)
        {
            cv.proteins[PCode]--;
            cv.proteins[(int)P.TransSwapon] += 2;
            cv.Energy -= nop.proteinCost;
        }

        if(cv.proteins[PCode] > 0 && cv.proteins[(int)P.InjSPrion] > 0)
        {
            cv.proteins[PCode]--;
            cv.proteins[(int)P.InjSPrion]++;
        }

        if(cv.proteins[PCode] >= 12)
        {
            if(cv.proteins[(int)P.InjectIngibiton] > 0)
            {
                cv.proteins[(int)P.InjectIngibiton]--;
                cv.proteins[PCode] -= 6;
                cv.Energy += 6 * nop.proteinCost;
            }
            else if(cell.GetComponent<PMInjector>().RelInject(0))
            {
                cv.proteins[PCode] -= 12;
            }
            else
                cv.proteins[PCode]--;
        }

        if(cv.proteins[(int)P.InjDeathon] >= 3)
        {
            cv.proteins[(int)P.InjDeathon] -= 3;
            cv.lifeResource -= 3 * nop.proteinCost;
            cv.Energy += 3 * nop.proteinCost * 0.95f;
        }
    }
}
