using UnityEngine;
using System.Collections;

public class PMFreeConsumer : Organoid
{
    public Sprite fceffect;
    public Sprite sceffect;

    NeoOptions nop;
    CellVars cv;
    Observer o;

    //=============================================================================================================================

    void Awake()
    {
        nop = GameObject.Find("Master").GetComponent<NeoOptions>();
        cv = GetComponent<CellVars>();
        o = GetComponent<Observer>();
    }

    //=============================================================================================================================

    public bool FreeConsume()
    {
        cv.Energy += nop.GetFCEnerProfit(gameObject);
        ShowUniEffect(fceffect, false);
        return true;
    }

    //=============================================================================================================================

    public bool SpaceConsume()
    {
        int sur = o.GetSurrounding();
        cv.Energy += 1f / 6 * (6 - sur);
        ShowUniEffect(sceffect, false);
        return true;
    }
}
