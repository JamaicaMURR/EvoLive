using UnityEngine;
using System.Collections;

public class Grizzler : MonoBehaviour
{
    public SpriteRenderer sprite;
    public Color fullGrizzle;

    private NeoOptions nop;

    void Awake()
    {
        nop = GameObject.Find("Master").GetComponent<NeoOptions>();
    }

    void Start()
    {
        sprite.color = Color.black;
    }

    public void Grizzle()
    {
        if(sprite != null)
        {
            CellVars cv = GetComponent<CellVars>();
            sprite.color = Color.black + fullGrizzle * cv.Age;
        }
    }
}
