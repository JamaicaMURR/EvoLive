using UnityEngine;
using System.Collections;

public class PMVoidConsumer : Organoid
{
    public Sprite effect;

    private NeoOptions nop;
    private MapMaster mm;

    void Awake()
    {
        nop = GameObject.Find("Master").GetComponent<NeoOptions>();
        mm = GameObject.Find("Master").GetComponent<MapMaster>();
    }

    //=============================================================================================================================

    public bool AbsConsume(int direction)
    {
        bool isSuccess = false;

        int tL = 0;
        int tP = 0;

        if(GetComponent<TNC>().TNCAtDir(direction, out tL, out tP))
            if(!mm.IsOccupied(tL, tP))
            {
                GetComponent<CellVars>().Energy += nop.vCEnerProfit;

                ShowUniEffect(effect, true);

                isSuccess = true;
            }

        return isSuccess;
    }

    //=============================================================================================================================

    public bool RelConsume(int direction)
    {
        return AbsConsume(GetComponent<TNC>().Dir + direction);
    }
}
