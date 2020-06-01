using UnityEngine;
using System.Collections;

public class UniEffectScript : MonoBehaviour
{
    float timeRem;

    NeoOptions nop;
    TNOptions tno;

    SpriteRenderer sr;
    Lifter l;

    [HideInInspector]
    public bool atWork;

    void Awake()
    {
        nop = GameObject.Find("Master").GetComponent<NeoOptions>();
        tno = GameObject.Find("Master").GetComponent<TNOptions>();

        sr = GetComponent<SpriteRenderer>();
        l = GetComponent<Lifter>();

        float p = tno.gap / 0.305f * 0.1f;
        GetComponent<Transform>().transform.localScale = new Vector3(p, p, 0);

        atWork = false;
    }

    void Update()
    {
        if(atWork)
        {
            timeRem -= Time.deltaTime;

            if(timeRem > 0)
            {
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, timeRem / nop.effectTime);
            }
            else
                Hide();
        }
    }

    public void Show(Sprite s, int dir)
    {
        if(!atWork)
        {
            GetComponent<TNC>().Dir = dir;
            sr.sprite = s;
            l.ToUp();
            atWork = true;
            timeRem = nop.effectTime;
        }
        else
            throw new System.Exception("effect already at work");
    }

    void Hide()
    {
        if(atWork)
        {
            l.ToDown();
            atWork = false;
            timeRem = 0;
        }
        else
            throw new System.Exception("effect already not at work");
    }
}
