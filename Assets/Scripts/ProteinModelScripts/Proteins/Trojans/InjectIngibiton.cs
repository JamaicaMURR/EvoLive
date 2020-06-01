using UnityEngine;
using System.Collections;

public class InjectIngibiton : Protein
{
    public override int PCode { get { return (int)P.InjectIngibiton; } }

    public override void ReactIn(GameObject cell) { }
}
