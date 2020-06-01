using UnityEngine;
using System.Collections;

public class SurInjAHGon : Protein
{
    public override int PCode { get { return (int)P.SurInjAHGon; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[PCode] >= 24)
        {
            cv.proteins[PCode] -= 24;

            int sur = cell.GetComponent<Observer>().GetSurrounding();

            cv.proteins[(int)P.FreeconsumExplodon] += 5;
            cv.proteins[(int)P.Injecton] += 3 * sur;
            cv.proteins[(int)P.AlphaHolyGrailon] += 3 * (6 - sur);
        }

        if(cv.proteins[PCode] > 0 && cv.proteins[(int)P.TransSwapon] > 0)
        {
            cv.proteins[(int)P.TransSwapon]--;
            cv.proteins[(int)P.FCFabricaton]++;
        }
    }
}
