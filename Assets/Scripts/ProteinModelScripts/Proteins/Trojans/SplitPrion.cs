using UnityEngine;
using System.Collections;

public class SplitPrion : Protein
{
    public override int PCode { get { return (int)P.SplitPrion; } }

    public override void ReactIn(GameObject cell) { }
}
