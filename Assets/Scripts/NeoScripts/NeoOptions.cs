using UnityEngine;
using System.Collections.Generic;

public class NeoOptions : MonoBehaviour
{
    private Statistics st;
    private TNOptions tno;

    void Awake()
    {
        st = GetComponent<Statistics>();
        tno = GetComponent<TNOptions>();
    }

    public int popCap = 0;

    public int colorScheme = 1;
    public int speedFormat = 0;

    [HideInInspector]
    public bool effects = true;
    [HideInInspector]
    public bool shiftEffects = false;
    [HideInInspector]
    public bool specialSpawn = true;

    // Cell Options
    public int lifeTimePerGen = 0;
    public int lifeTime = 0;
    public float lifeResource = 0;

    // Effects Options
    public float effectTime= 0;
    public float disapFactor = 0;

    // Energy Options
    public float proteinCost = 0;
    public float lifeCost = 0;
    public float genCost = 0;
    public float fCEnerProfit = 0;
    public float vCEnerProfit = 0;

    // Genome Options
    public int sizeCap = 0;
    public double codonMutFreq = 0;
    public double resizeMutFreq = 0;
    public int codonMutPer1Cap = 0;
    public int resizeMutPer1Cap = 0;

    // Energy Profit Calcs 

    public float GetFCEnerProfit(GameObject ob)
    {
        return 1f - (float)st.alive / (tno.netHeight * tno.netWidth);
    }

    public float GetVCEnerProfit(GameObject ob)
    {
        return vCEnerProfit;
    }

    // Action Energy Costs
    //public float rotC = 0;
    //public float movC = 0;
    //public float splitC = 0;
    //public float swapC = 0;
    //public float rebC = 0;
    //public float givC = 0;
    //public float injC = 0;
    //public float killC = 0;
    //public float pushC = 0;
    //public float expC = 0;
    //public float eqC = 0;
    //public float funcshC = 0;

    //
}
