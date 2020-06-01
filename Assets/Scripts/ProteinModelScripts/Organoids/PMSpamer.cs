using UnityEngine;
using System.Collections;

public class PMSpamer : Organoid
{
    public Sprite budEffect;
    public Sprite doubleEffect;

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

    public void Spam()
    {
        CellVars cv = GetComponent<CellVars>();

        for(int i = 0; i < 6; i++)
            SetBud(i, cv.Energy / 6);

        cv.Energy = 0;
    }

    //=============================================================================================================================

    public bool Double()
    {
        bool result = false;

        TNC tnc = GetComponent<TNC>();

        int frontDir = tnc.Dir;

        int targetLine1 = 0;
        int targetPos1 = 0;
        int targetLine2 = 0;
        int targetPos2 = 0;

        if(tnc.TNCAtDir(frontDir + 1, out targetLine1, out targetPos1) && tnc.TNCAtDir(frontDir - 1, out targetLine2, out targetPos2))
            if(!mm.IsOccupied(targetLine1, targetPos1) && !mm.IsOccupied(targetLine2, targetPos2))
            {
                GameObject replic1 = mm.SpawnCell(targetLine1, targetPos1, tnc.Dir);
                GameObject replic2 = mm.SpawnCell(targetLine2, targetPos2, tnc.Dir);

                replic1.GetComponent<GNM>().Genome = GetComponent<GNM>().GetReplicatedGenome();
                replic1.GetComponent<GenColorer>().ReColor();

                replic2.GetComponent<GNM>().Genome = GetComponent<GNM>().GetReplicatedGenome();
                replic2.GetComponent<GenColorer>().ReColor();

                CellVars r1cv = replic1.GetComponent<CellVars>();
                CellVars r2cv = replic2.GetComponent<CellVars>();

                r1cv.lifeResource = nop.lifeResource;
                r1cv.Energy = GetComponent<CellVars>().Energy / 2;
                r1cv.bornDir = tnc.Dir;

                r2cv.lifeResource = nop.lifeResource;
                r2cv.Energy = GetComponent<CellVars>().Energy / 2;
                r2cv.bornDir = tnc.Dir;

                ShowUniEffect(doubleEffect, true);

                st.alive += 2;

                GetComponent<CellVars>().Energy = 0;

                result = true;
            }

        return result;
    }

    //=============================================================================================================================

    public bool SetBud(int dir, float energy, bool withGci)
    {
        bool result = false;

        int targetLine = 0;
        int targetPos = 0;

        if(GetComponent<TNC>().TNCAtDir(dir, out targetLine, out targetPos))
            if(!mm.IsOccupied(targetLine, targetPos))
            {
                GameObject replic = mm.SpawnCell(targetLine, targetPos, dir);

                replic.GetComponent<GNM>().Genome = GetComponent<GNM>().GetReplicatedGenome();

                if(withGci)
                    replic.GetComponent<GNM>().Gci = GetComponent<GNM>().Gci;

                replic.GetComponent<GenColorer>().ReColor();

                CellVars rcv = replic.GetComponent<CellVars>();

                rcv.lifeResource = nop.lifeResource;
                rcv.Energy = energy;
                rcv.bornDir = dir;

                ShowUniEffect(budEffect, false, dir);

                st.alive++;

                result = true;
            }

        return result;
    }

    public bool SetBud(int dir, float energy)
    {
        return SetBud(dir, energy, false);
    }
}
