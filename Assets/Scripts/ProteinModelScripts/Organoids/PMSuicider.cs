using UnityEngine;
using System.Collections;

public class PMSuicider : Organoid
{
    public Sprite effect;

    public void Suicide()
    {
        ShowUniEffect(effect, false);
        GetComponent<CellVars>().Energy = 0;
    }
}
