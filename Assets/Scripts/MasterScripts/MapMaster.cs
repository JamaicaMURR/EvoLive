using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapMaster : MonoBehaviour
{
    [HideInInspector]
    public List<GameObject> deadstack;

    [HideInInspector]
    public GameObject[,] cells;

    [HideInInspector]
    public GameObject pocket;

    TNOptions tno;

    void Awake()
    {
        tno = GetComponent<TNOptions>();

        deadstack = new List<GameObject>();
        cells = new GameObject[tno.netHeight, tno.netWidth];
    }

    void RegIn(GameObject g)
    {
        TNC gtnc = g.GetComponent<TNC>();

        int pl = gtnc.Line - tno.dLine;
        int pp = gtnc.Pos - tno.lPos;

        if(cells[pl, pp] == null)
            cells[pl, pp] = g;
        else
            throw new System.Exception("Cell is already registered!");
    }

    void RegOut(int line, int pos)
    {
        if(GetFrom(line, pos) != null)
        {
            int pl = line - tno.dLine;
            int pp = pos - tno.lPos;

            cells[pl, pp] = null;
        }
        else
            throw new System.Exception("Obect is not registred!");
    }

    void RegOut(GameObject g)
    {
        RegOut(g.GetComponent<TNC>().Line, g.GetComponent<TNC>().Pos);
    }

    public GameObject SpawnCell(int line, int pos, int dir)
    {
        GameObject result = null;

        if(!IsOccupied(line, pos))
        {
            result = deadstack[deadstack.Count - 1];
            deadstack.RemoveAt(deadstack.Count - 1);
            result.GetComponent<TNC>().SetTNC(line, pos);
            result.GetComponent<TNC>().Dir = dir;
            result.GetComponent<CellVars>().IsOnscene = true;

            result.GetComponent<EnergyPulser>().enabled = true;
            EnergyPulser[] ep = result.GetComponentsInChildren<EnergyPulser>();

            foreach(EnergyPulser e in ep)
                e.enabled = true;

            RegIn(result);
        }
        else
            throw new System.Exception("Place is occupied!");

        return result;
    }

    public void DeleteCell(GameObject cll)
    {
        RegOut(cll);
        deadstack.Add(cll);
        cll.GetComponent<CellVars>().IsOnscene = false;

        cll.GetComponent<EnergyPulser>().enabled = false;
        EnergyPulser[] ep = cll.GetComponentsInChildren<EnergyPulser>();

        foreach(EnergyPulser e in ep)
            e.enabled = false;
    }

    public void ReplaceCell(GameObject cell, int l, int p)
    {
        RegOut(cell);
        cell.GetComponent<TNC>().SetTNC(l, p);
        RegIn(cell);
    }

    public void ToPocket(GameObject cell)
    {
        pocket = cell;
        RegOut(cell);
    }

    public GameObject FromPocket(int line, int pos)
    {
        GameObject result = pocket;

        if(result != null)
        {
            pocket = null;
            result.GetComponent<TNC>().SetTNC(line, pos);
            RegIn(result);
        }
        else
            throw new System.Exception("Pocket is empty!");

        return result;
    }

    public bool IsOccupied(int l, int p)
    {
        bool result = false;

        if(GetFrom(l, p) != null)
            result = true;

        return result;
    }

    public bool IsAlive(GameObject g)
    {
        return g.GetComponent<CellVars>().IsOnscene;
    }

    public GameObject GetFrom(int l, int p)
    {
        int pl = l - tno.dLine;
        int pp = p - tno.lPos;

        return cells[pl, pp];
    }

    public List<GameObject> GetAll()
    {
        List<GameObject> result = new List<GameObject>();

        for(int i = 0; i < cells.GetLength(0); i++)
            for(int j = 0; j < cells.GetLength(1); j++)
                if(cells[i, j] != null)
                    result.Add(cells[i, j]);

        result.TrimExcess();

        return result;
    }
}

