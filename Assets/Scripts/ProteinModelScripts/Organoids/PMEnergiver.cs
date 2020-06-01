using UnityEngine;
using System.Collections;

public class PMEnergiver : Organoid
{
    public Sprite effect;

    private MapMaster mm;

    void Awake()
    {
        mm = GameObject.Find("Master").GetComponent<MapMaster>();
    }

    public bool AbsGive(int direction, float amount)
    {
        bool isSuccess = false;

        GameObject target = GetComponent<Observer>().GetCellFromDir(direction);

        if(target != null)
        {
            target.GetComponent<CellVars>().Energy += amount;

            ShowUniEffect(effect, true);

            isSuccess = true;
        }

        return isSuccess;
    }

    public bool RelGive(int direction, float amount)
    {
        return AbsGive(TNC.NormalizeDir(GetComponent<TNC>().Dir + direction), amount);
    }
}
