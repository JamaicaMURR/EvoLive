using UnityEngine;
using System.Collections;

public abstract class Organoid : MonoBehaviour
{
    NeoOptions neop;
    EffectsMaster em;
    //=============================================================================================================================
    public void ShowEffect(GameObject effect, bool isDirected, int dirF)
    {
        neop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(effect != null && neop.effects)
        {
            GameObject mEf = Instantiate(effect);
            TNC ctnc = mEf.GetComponent<TNC>();
            TNC tnc = GetComponent<TNC>();
            ctnc.SetTNC(tnc.Line, tnc.Pos);

            if(isDirected)
                ctnc.Dir = TNC.NormalizeDir(tnc.Dir + dirF);
            else
                ctnc.Dir = dirF;
        }
    }

    public void ShowEffect(GameObject effect, bool isDirected)
    {
        ShowEffect(effect, isDirected, 0);
    }

    public void ShowUniEffect(Sprite s, bool isDirected, int efrot)
    {
        neop = GameObject.Find("Master").GetComponent<NeoOptions>();

        if(neop.effects)
        {
            em = GameObject.Find("Master").GetComponent<EffectsMaster>();

            TNC tnc = GetComponent<TNC>();

            int dir;

            if(isDirected)
                dir = TNC.NormalizeDir(tnc.Dir + efrot);
            else
                dir = efrot;

            em.ShowAt(s, tnc.Line, tnc.Pos, dir);
        }
    }

    public void ShowUniEffect(Sprite s, bool isDirected)
    {
        ShowUniEffect(s, isDirected, 0);
    }
}
