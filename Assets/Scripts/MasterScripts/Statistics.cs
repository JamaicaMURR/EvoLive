using UnityEngine;
using System.Collections;

public class Statistics : MonoBehaviour
{
    public float energyTotal = 0;
    public ulong cycles = 0;
    public ulong dead = 0;
    public int alive = 0;
    public int shortestgnm = int.MaxValue;
    public int longestgnm = 0;

    public void Wipe()
    {
        energyTotal = 0;
        cycles = 0;
        dead = 0;
        alive = 0;
    }
}
