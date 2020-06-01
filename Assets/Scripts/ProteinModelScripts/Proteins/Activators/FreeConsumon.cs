using UnityEngine;
using System.Collections;

public class FreeConsumon : Protein
{
    public override int PCode { get { return (int)P.FreeConsumon; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(cv.proteins[(int)P.FreeconsumExplodon] >= 12)
        {
            cell.GetComponent<PMExploder>().Explode();
        }
        else if(cv.proteins[(int)P.FCPlaguon] >= 18)
        {
            cv.proteins[(int)P.FCPlaguon] -= 12;
            cell.GetComponent<PMSprayer>().Spray();
        }
        else if(cv.proteins[(int)P.FCPlaguon] > 0)
        {
            cv.proteins[(int)P.FCPlaguon]++;
            cv.Energy -= 2 * nop.proteinCost;
        }
        else if(cv.proteins[(int)P.FCWaston] >= 78)
        {
            cv.proteins[(int)P.FCWaston] -= 78;
            cell.GetComponent<PMSprayer>().CustomSpray((int)P.FCWaston, 72);
        }
        else if(cv.proteins[PCode] >= 12)
        {
            cv.proteins[PCode] -= 12;
            cell.GetComponent<PMFreeConsumer>().FreeConsume();
            cv.proteins[(int)P.FCWaston] += 3;
            cv.proteins[(int)P.JCeenon]++;
        }
    }
}
