using UnityEngine;
using System.Collections;

public class SurRoton : Protein
{
    public override int PCode { get { return (int)P.SurRoton; } }

    public override void ReactIn(GameObject cell)
    {
        CellVars cv = cell.GetComponent<CellVars>();
        NeoOptions nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        int sur = cell.GetComponent<Observer>().GetSurrounding();

        if(cv.proteins[PCode] >= 12)
        {
            if(sur != 6)
            {
                PMRotator r = cell.GetComponent<PMRotator>();

                switch(sur)
                {
                    case 5:
                        r.RelRotate(1, true);
                        cv.proteins[PCode] -= 4;
                        break;
                    case 4:
                        r.RelRotate(4, true);
                        cv.proteins[PCode] -= 6;
                        break;
                    case 3:
                    case 2:
                    case 1:
                    case 0:
                        r.RelRotate(5, true);
                        cv.proteins[PCode] -= 3;
                        break;
                }
            }
            else
            {
                cv.proteins[PCode] -= 12;
                cell.GetComponent<PMSprayer>().Spray();
            }
        }
    }
}
