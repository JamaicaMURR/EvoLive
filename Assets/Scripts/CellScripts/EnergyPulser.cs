using UnityEngine;
using System.Collections;
using System;

public class EnergyPulser : MonoBehaviour
{
    //public CellsOptions co;

    public float maximalScale = 1f;
    public float minimalScale = 0.8f;
    public float scalespeedCap = 0.01f;

    private float _maximalScale;
    private float _minimalScale;

    public float targetScale = 0;

    public CellVars energySource;

    private TNOptions tno;

    public bool isg = false;

    void Awake()
    {
        tno = GameObject.Find("Master").GetComponent<TNOptions>();
        if(isg)
        {
            _maximalScale = tno.gap;
            _minimalScale = tno.gap * 0.4f;
        }
        else
        {
            _maximalScale = maximalScale;
            _minimalScale = minimalScale;
        }
    }

    void Update()
    {
        targetScale = energySource.Energy * (_maximalScale - _minimalScale) + _minimalScale;

        float dif = targetScale - GetComponent<Transform>().transform.localScale.x;

        //if(Math.Abs(dif) > scalespeedCap)
        //    dif = scalespeedCap * Math.Sign(dif);

        if(GetComponent<SpriteRenderer>() != null)
            GetComponent<Transform>().transform.localScale += new Vector3(dif, dif, 0);
        else
            GetComponent<Transform>().transform.localScale += new Vector3(dif, 0, dif);
    }
}
