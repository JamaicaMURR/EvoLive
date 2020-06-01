using UnityEngine;
using System.Collections;

public class PMJCeener : Organoid
{
    public Sprite effect;

    private MapMaster mm;

    void Awake()
    {
        mm = GameObject.Find("Master").GetComponent<MapMaster>();
    }

    public bool AbsJCeen(int direction)
    {
        bool isSuccess = false;

        int hLine = 0;
        int hPos = 0;

        TNC tnc = GetComponent<TNC>();

        if(tnc.TNCAtDir(TNC.NormalizeDir(direction + 3), out hLine, out hPos))
        {
            GameObject target = GetComponent<Observer>().GetCellFromDir(direction);

            if(target != null && !mm.IsOccupied(hLine, hPos))
            {
                mm.ReplaceCell(target, hLine, hPos);

                ShowUniEffect(effect, true);

                isSuccess = true;
            }
        }

        return isSuccess;
    }

    public bool RelJCeen(int direction)
    {
        return AbsJCeen(TNC.NormalizeDir(GetComponent<TNC>().Dir + direction));
    }
}
