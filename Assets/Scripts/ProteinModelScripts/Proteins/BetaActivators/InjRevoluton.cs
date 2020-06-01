using UnityEngine;
using System.Collections;

public class InjRevoluton : Protein
{
    public override int PCode { get { return (int)P.InjRevoluton; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[PCode] >= 3 && cv.proteins[(int)P.TransSwapon] >= 9)
        {
            if(cell.GetComponent<PMInjector>().RelInject(3, 3))
            {
                cv.proteins[PCode] -= 3;
                cv.proteins[(int)P.TransSwapon] -= 9;
            }
            else
                cv.proteins[(int)P.TransSwapon]--;
        }
        else if(cv.proteins[PCode] >= 18)
        {
            cv.proteins[PCode] -= 12;
            cell.GetComponent<PMSprayer>().CustomSpray(PCode, 6);
        }
    }
}
