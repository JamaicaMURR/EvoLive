using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MasterSpawner : MonoBehaviour
{
    static System.Random r = new System.Random();

    public int[] coms;

    public int spawnLine = 0;
    public int spawnPos = 0;

    public int genomLength = 3;

    public GameObject sample;

    private int comsTotal = 0;
    private int comsIter = 0;

    NeoOptions nop;
    MapMaster mm;

    void Awake()
    {
        nop = GetComponent<NeoOptions>();
        mm = GetComponent<MapMaster>();
    }

    //=============================================================================================================================

    public GameObject Spawn()
    {
        GameObject newbie = mm.SpawnCell(spawnLine, spawnPos, r.Next(0, 6));

        comsIter = 0;
        comsTotal = GenomeReader.pkeys.Length;

        newbie.GetComponent<GNM>().Genome = GenerateRNDGenome(genomLength);
        newbie.GetComponent<GenColorer>().ReColor();
        newbie.GetComponent<CellVars>().Energy = 1;
        newbie.GetComponent<CellVars>().bornDir = newbie.GetComponent<TNC>().Dir;
        newbie.GetComponent<CellVars>().lifeResource = GetComponent<NeoOptions>().lifeResource;

        return newbie;
    }

    //=============================================================================================================================

    List<float> GenerateRNDGenome(int length)
    {
        List<float> generatedGenome = new List<float>();

        for(int i = 0; i < length; i++)
        {
            if(comsIter < coms.Length && nop.specialSpawn)
            {
                generatedGenome.Add(GNM.Encode(coms[comsIter], comsTotal));
                comsIter++;
            }
            else
                generatedGenome.Add((float)r.NextDouble());
        }

        return generatedGenome;
    }
}
