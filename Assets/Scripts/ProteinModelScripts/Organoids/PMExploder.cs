using UnityEngine;
using System.Collections;

public class PMExploder : Organoid
{
    private Observer o;
    private TNC tnc;

    public Sprite effect;

    private MapMaster mm;

    void Awake()
    {
        o = GetComponent<Observer>();
        tnc = GetComponent<TNC>();

        mm = GameObject.Find("Master").GetComponent<MapMaster>();
    }

    public void Explode()
    {
        for(int i = 0; i < 6; i++)
        {
            GameObject target = o.GetCellFromDir(i);

            if(target != null)
                target.GetComponent<NeoDeathCounter>().InstantDeath();
        }

        ShowUniEffect(effect, false);

        GetComponent<CellVars>().Energy = 0;
    }
}
