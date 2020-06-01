using UnityEngine;
using System.Collections;

public class PMKiller : Organoid
{
    public Sprite effect;

    private MapMaster mm;

    void Awake()
    {
        mm = GameObject.Find("Master").GetComponent<MapMaster>();
    }

    public bool AbsKill(int direction)
    {
        bool isSuccess = false;

        GameObject target = GetComponent<Observer>().GetCellFromDir(direction);

        if(target != null)
        {
            target.GetComponent<NeoDeathCounter>().InstantDeath();

            ShowUniEffect(effect, false, direction);

            isSuccess = true;
        }

        return isSuccess;
    }

    public bool RelKill(int direction)
    {
        return AbsKill(TNC.NormalizeDir(GetComponent<TNC>().Dir + direction));
    }
}
