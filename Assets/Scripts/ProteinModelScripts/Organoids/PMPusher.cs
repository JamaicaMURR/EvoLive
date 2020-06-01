using UnityEngine;
using System.Collections;

public class PMPusher : Organoid
{
    public Sprite effect;

    private MapMaster mm;

    void Awake()
    {
        mm = GameObject.Find("Master").GetComponent<MapMaster>();
    }

    public bool AbsPush(int direction)
    {
        bool isSuccess = false;

        GameObject target = GetComponent<Observer>().GetCellFromDir(direction);

        if(target != null)
        {
            isSuccess = target.GetComponent<PMMover>().AbsMove(direction, false);
        }

        if(isSuccess)
            ShowUniEffect(effect, true);

        return isSuccess;
    }

    public bool RelPush(int direction)
    {
        return AbsPush(TNC.NormalizeDir(GetComponent<TNC>().Dir + direction));
    }
}
