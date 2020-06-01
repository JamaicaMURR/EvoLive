using UnityEngine;
using System.Collections;

public class PMMover : Organoid
{
    public Sprite effect;

    private MapMaster mm;

    void Awake()
    {
        mm = GameObject.Find("Master").GetComponent<MapMaster>();
    }

    //=============================================================================================================================

    public bool RelMove(int direction, bool withEffect)
    {
        return AbsMove(TNC.NormalizeDir(GetComponent<TNC>().Dir + direction), withEffect, 0);
    }

    //=============================================================================================================================

    public bool RelMove(int direction, bool withEffect, int effectRotation)
    {
        return AbsMove(TNC.NormalizeDir(GetComponent<TNC>().Dir + direction), withEffect, effectRotation);
    }

    //=============================================================================================================================

    public bool AbsMove(int direction, bool withEffect, int effectRotation)
    {
        direction = TNC.NormalizeDir(direction);

        bool isSuccess = false;

        int targetLine = 0;
        int targetPos = 0;

        TNC tnc = GetComponent<TNC>();

        if(tnc.TNCAtDir(direction, out targetLine, out targetPos))
            if(!mm.IsOccupied(targetLine, targetPos))
            {
                mm.ReplaceCell(gameObject, targetLine, targetPos);

                if(withEffect)
                    mm.GetFrom(targetLine, targetPos).GetComponent<PMMover>().ShowUniEffect(effect, true, effectRotation);

                isSuccess = true;
            }

        return isSuccess;
    }

    public bool AbsMove(int direction, bool withEffect)
    {
        return AbsMove(direction, withEffect, 0);
    }
}
