using UnityEngine;
using System.Collections;

public class PMRotator : Organoid
{
    Sprite currentEffect;
    public Sprite relEffect;
    public Sprite absEffect;

    //=============================================================================================================================

    public void AbsRotate(int direction, bool withEffect)
    {
        currentEffect = absEffect;
        ExecRotate(direction, withEffect);
    }

    //=============================================================================================================================

    public void ExecRotate(int direction, bool withEffect)
    {
        GetComponent<TNC>().Dir = direction;

        if(withEffect)
            ShowUniEffect(currentEffect, true);
    }

    //=============================================================================================================================

    public void RelRotate(int direction, bool withEffect)
    {
        currentEffect = relEffect;
        ExecRotate(GetComponent<TNC>().Dir + direction, withEffect);
    }
}
