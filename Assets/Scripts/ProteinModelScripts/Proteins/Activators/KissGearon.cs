using UnityEngine;
using System.Collections;

public class KissGearon : Protein
{
    public override int PCode { get { return (int)P.KissGearon; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[PCode] < 12 && cv.proteins[PCode] + cv.proteins[(int)P.TransRotaton] >= 12)
        {
            cv.proteins[(int)P.TransRotaton] -= 12 - cv.proteins[PCode];
            cv.proteins[PCode] += 12 - cv.proteins[PCode];
        }

        if(cv.proteins[PCode] >= 12)
        {
            if(cell.GetComponent<PMGearer>().AbsGear(TNC.NormalizeDir(cell.GetComponent<TNC>().Dir + 3)))
            {
                cv.proteins[PCode] -= 12;
                cv.proteins[(int)P.InjectIngibiton] += 2;
                cv.proteins[(int)P.Equalon]++;
            }
            else
            {
                cv.proteins[PCode]--;
                cv.Energy += 0.5f * nop.proteinCost;
            }
        }
    }
}
