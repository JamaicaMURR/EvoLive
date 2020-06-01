using UnityEngine;
using System.Collections;

public class PMGearer : Organoid
{
    public Sprite effect;

    private MapMaster mm;

    void Awake()
    {
        mm = GameObject.Find("Master").GetComponent<MapMaster>();
    }

    //=============================================================================================================================

    public bool AbsGear(int direction)
    {
        bool isSuccess = false;

        GameObject target = GetComponent<Observer>().GetCellInFront();

        if(target != null)
        {
            target.GetComponent<PMRotator>().AbsRotate(direction, false);

            ShowUniEffect(effect, true);

            isSuccess = true;
        }

        return isSuccess;
    }
}
