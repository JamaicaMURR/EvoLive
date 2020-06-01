using UnityEngine;
using System.Collections;

public class PMShifter : Organoid
{
    public Sprite effect;
    private NeoOptions nop;

    //=============================================================================================================================

    void Awake()
    {
        nop = GameObject.Find("Master").GetComponent<NeoOptions>();
    }
    //=============================================================================================================================

    public void Restart()
    {
        GetComponent<GNM>().Gci = 0;

        if(nop.shiftEffects)
            ShowUniEffect(effect, false, 3);
    }

    //=============================================================================================================================

    public void Shift(int v)
    {
        GetComponent<GNM>().Gci += v;

        if(nop.shiftEffects)
            ShowUniEffect(effect, false);
    }

    //=============================================================================================================================

    public void Point(int v)
    {
        GetComponent<GNM>().Gci = v;

        if(nop.shiftEffects)
            ShowUniEffect(effect, false);
    }
}
