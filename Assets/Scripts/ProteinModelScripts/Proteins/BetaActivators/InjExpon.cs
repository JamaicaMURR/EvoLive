using UnityEngine;
using System.Collections;

public class InjExpon : Protein
{
    public override int PCode { get { return (int)P.InjExpon; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[PCode] >= 12)
        {
            int sur = cell.GetComponent<Observer>().GetSurrounding();

            if(sur == 6)
            {
                cv.proteins[PCode] -= 12;
                cell.GetComponent<PMInjector>().RelInject(0);
                cv.proteins[(int)P.InjectIngibiton] += 3;
            }
            else
            {
                cv.proteins[PCode] -= 6;
                cv.proteins[(int)P.Explodon] += 4;
                cv.lifeResource += 1.5f * nop.proteinCost;
            }
        }
        else if(cv.proteins[(int)P.Explodon] >= 12)
            cell.GetComponent<PMExploder>().Explode();
    }
}
