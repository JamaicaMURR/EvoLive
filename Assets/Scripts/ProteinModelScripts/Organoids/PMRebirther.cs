using UnityEngine;
using System.Collections;

public class PMRebirther : Organoid
{
    public GameObject sample;
    public Sprite effect;

    NeoOptions nop;
    Statistics st;
    MapMaster mm;

    //=============================================================================================================================

    void Awake()
    {
        nop = GameObject.Find("Master").GetComponent<NeoOptions>();
        st = GameObject.Find("Master").GetComponent<Statistics>();
        mm = GameObject.Find("Master").GetComponent<MapMaster>();
    }

    //=============================================================================================================================

    public void Rebirth()
    {
        GetComponent<GNM>().Genome = GetComponent<GNM>().GetReplicatedGenome();
        GetComponent<GenColorer>().ReColor();

        GetComponent<CellVars>().lifeResource = nop.lifeResource;

        ShowUniEffect(effect, false);

        st.dead++;
    }
}
