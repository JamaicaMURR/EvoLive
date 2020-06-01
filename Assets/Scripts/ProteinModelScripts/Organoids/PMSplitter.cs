using UnityEngine;
using System;

public class PMSplitter : Organoid
{
    public Sprite effect;

    Statistics st;
    NeoOptions nop;
    MapMaster mm;

    //=============================================================================================================================

    void Awake()
    {
        st = GameObject.Find("Master").GetComponent<Statistics>();
        nop = GameObject.Find("Master").GetComponent<NeoOptions>();
        mm = GameObject.Find("Master").GetComponent<MapMaster>();
    }

    //=============================================================================================================================

    public bool AbsSplit(int direction)
    {
        bool isSuccess = false;

        int targetLine = 0;
        int targetPos = 0;

        if(GetComponent<TNC>().TNCAtDir(direction, out targetLine, out targetPos))
        {
            if(!mm.IsOccupied(targetLine, targetPos))
            {
                GameObject replic = mm.SpawnCell(targetLine, targetPos, direction);

                replic.GetComponent<GNM>().Genome = GetComponent<GNM>().GetReplicatedGenome();
                replic.GetComponent<GenColorer>().ReColor();

                CellVars cv = GetComponent<CellVars>();
                CellVars rcv = replic.GetComponent<CellVars>();

                rcv.lifeResource = nop.lifeResource;
                rcv.bornDir = GetComponent<TNC>().Dir;
                rcv.Energy = cv.Energy / 2;
                cv.Energy -= rcv.Energy;
                rcv.proteins = cv.DivideProteins();

                ShowUniEffect(effect, false, direction);

                st.alive++;

                isSuccess = true;
            }
        }

        return isSuccess;
    }

    //=============================================================================================================================

    public bool RelSplit(int dir)
    {
        return AbsSplit(TNC.NormalizeDir(GetComponent<TNC>().Dir + dir));
    }
}
