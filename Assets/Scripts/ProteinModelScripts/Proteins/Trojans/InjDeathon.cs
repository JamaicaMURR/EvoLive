using UnityEngine;
using System.Collections;

public class InjDeathon : Protein
{
    public override int PCode { get { return (int)P.InjDeathon; } }

    public override void ReactIn(GameObject cell) { }
}
