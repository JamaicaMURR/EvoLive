using UnityEngine;
using System.Collections;

public class PMSwaper : Organoid
{
    public Sprite effect;

    private MapMaster mm;

    //=============================================================================================================================

    void Awake()
    {
        mm = GameObject.Find("Master").GetComponent<MapMaster>();
    }

    public bool AbsSwap(int direction)
    {
        bool isSuccess = false;

        direction = TNC.NormalizeDir(direction);

        GameObject target = GetComponent<Observer>().GetCellFromDir(direction);

        if(target != null)
        {
            TNC tnc = GetComponent<TNC>();
            TNC ttnc = target.GetComponent<TNC>();

            int sl = tnc.Line;
            int sp = tnc.Pos;

            ShowUniEffect(effect, false, direction);

            mm.ToPocket(target);
            mm.ReplaceCell(gameObject, ttnc.Line, ttnc.Pos);
            mm.FromPocket(sl, sp);

            isSuccess = true;
        }

        return isSuccess;
    }

    //=============================================================================================================================

    public bool RelSwap(int direction)
    {
        return AbsSwap(TNC.NormalizeDir(GetComponent<TNC>().Dir + direction));
    }
}
