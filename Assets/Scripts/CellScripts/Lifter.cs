using UnityEngine;
using System.Collections;

public class Lifter : MonoBehaviour
{
    Transform t;
    CellVars cv;

    void Awake()
    {
        t = GetComponent<Transform>();
        cv = GetComponent<CellVars>();
    }

    public void ToUp()
    {
        t.position += new Vector3(0, 0, -2);
    }

    public void ToDown()
    {
        t.position += new Vector3(0, 0, 2);
    }
}
