using UnityEngine;
using System.Collections;

public class ShiftIngibiton : Protein
{
    public override int PCode { get { return (int)P.ShiftIngibiton; } }

    public override void ReactIn(GameObject cell) { }
}
