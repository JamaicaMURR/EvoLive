using UnityEngine;
using System.Collections;

public class NeoDeathCounter : MonoBehaviour
{
    Statistics st;
    MapMaster mm;

    void Awake()
    {
        st = GameObject.Find("Master").GetComponent<Statistics>();
        mm = GameObject.Find("Master").GetComponent<MapMaster>();
    }

    public void DeathControl()
    {
        if(GetComponent<CellVars>().Energy <= 0 || GetComponent<CellVars>().lifeResource <= 0)
            InstantDeath();

        GetComponent<Grizzler>().Grizzle();
    }

    public void InstantDeath()
    {
        if(mm.IsAlive(gameObject))
        {
            mm.DeleteCell(gameObject);

            st.alive--;
            st.dead++;
        }
    }
}
