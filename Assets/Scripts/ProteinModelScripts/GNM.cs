using UnityEngine;
using System.Collections.Generic;
using System;

public class GNM : MonoBehaviour
{
    static System.Random rnd = new System.Random();

    private List<float> genome;

    public List<float> Genome
    {
        get { return genome; }
        set
        {
            genome = value;
            genome.TrimExcess();
            gci = 0;
        }
    }

    public int Length { get { return genome.Count; } }

    private int gci = 0;

    public int Gci
    {
        get { return gci; }
        set
        {
            gci = value;

            while(gci < 0)
                gci += genome.Count;

            while(gci > genome.Count - 1)
                gci -= genome.Count;
        }
    }

    public float Gen { get { return genome[gci]; } }
    public float GenNShift
    {
        get
        {
            float result = Gen;
            ShiftGen();
            return result;
        }
    }

    private NeoOptions nop;

    //============================================================================================================================= Awake

    void Awake()
    {
        nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        genome = new List<float>();
    }

    //=============================================================================================================================

    public List<float> GetReplicatedGenome()
    {
        List<float> result = new List<float>(genome);

        int muts = 0;


        while(rnd.NextDouble() < nop.resizeMutFreq && muts < nop.resizeMutPer1Cap) // Genome resizing
        {
            double coin = rnd.NextDouble();

            if(coin >= 0.5 && result.Count < nop.sizeCap)
            {
                result.Insert(rnd.Next(0, result.Count), result[rnd.Next(0, result.Count)]);
            }
            else if(coin < 0.5 && result.Count > 1)
            {
                result.RemoveAt(rnd.Next(0, result.Count));
            }

            muts++;
        }

        double realCodonMutFreq = 1 - Math.Pow(1 - nop.codonMutFreq, result.Count);

        muts = 0;

        while(rnd.NextDouble() < realCodonMutFreq && muts < nop.codonMutPer1Cap) // Codons mutating
        {
            result[rnd.Next(0, result.Count)] = (float)rnd.NextDouble();
            muts++;
        }

        return result;
    }

    //============================================================================================================================= Gen Getter

    public void ShiftGen()
    {
        gci++;

        if(gci >= genome.Count)
            gci = 0;
    }

    //============================================================================================================================= Decoders

    public static int Decode(float s, int p)
    {
        return (int)(s / (1f / p));
    }

    public static int DirDecode(float s)
    {
        return Decode(s, 6);
    }

    public static bool BoolDecode(float s)
    {
        return Decode(s, 2) < 0.5f ? true : false;
    }

    //============================================================================================================================= Encoder

    public static float Encode(int a, int t)
    {
        return 1.0f / t * a + 1.0f / t / 2;
    }
}
