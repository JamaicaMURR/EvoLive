using UnityEngine;
using System.Collections;

public class EffectScript : MonoBehaviour
{
    static System.Random rnd = new System.Random();

    public float timeRem = 0;

    private NeoOptions nop;
    private TNOptions tno;

    void Awake()
    {
        nop = GameObject.Find("Master").GetComponent<NeoOptions>();
        tno = GameObject.Find("Master").GetComponent<TNOptions>();
        timeRem = nop.effectTime + 0.25f * (rnd.NextDouble() < 0.5 ? (float)-rnd.NextDouble() : (float)rnd.NextDouble()) * nop.effectTime;
        float p = tno.gap / 0.305f * 0.1f;
        GetComponent<Transform>().transform.localScale = new Vector3(p, p, 0);
    }

    void Update()
    {
        timeRem -= Time.deltaTime;

        if(timeRem > 0)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, timeRem / nop.effectTime);
        }
        else
            Destroy(gameObject);
    }
}
