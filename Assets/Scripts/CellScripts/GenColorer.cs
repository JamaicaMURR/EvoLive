using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenColorer : MonoBehaviour
{
    //public Genome g;
    public SpriteRenderer s;
    private NeoOptions nop;

    private Color c0;
    private Color c1;
    private Color c2;

    bool bc0 = false;
    bool bc1 = false;
    bool bc2 = false;

    void Awake()
    {
        nop = GameObject.Find("Master").GetComponent<NeoOptions>();
    }

    public void ReColor()
    {
        ReColor(true);
    }

    public void ReColor(bool r)
    {
        if(GetComponent<GNM>().Genome != null)
        {
            if(r || (!bc0 && nop.colorScheme == 0) || (!bc1 && nop.colorScheme == 1) || (!bc2 && nop.colorScheme == 2))
            {
                if(GetComponent<GNM>().Genome.Count > 0)
                {
                    float red = 0;
                    float green = 0;
                    float blue = 0;

                    int rc = 0;
                    int gc = 0;
                    int bc = 0;

                    List<float> genome = GetComponent<GNM>().Genome;

                    for(int i = 0; i < genome.Count; i++)
                    {
                        if(nop.colorScheme == 2)
                        {
                            if(genome[i] < 0.33333f)
                            {
                                red += genome[i] * 3;
                                rc++;
                            }
                            else if(genome[i] < 0.66666f)
                            {
                                green += (genome[i] - 0.33333f) * 3;
                                gc++;
                            }
                            else
                            {
                                blue += (genome[i] - 0.66666f) * 3;
                                bc++;
                            }
                        }
                        else
                            switch(i % 3)
                            {
                                case 0:
                                    red += genome[i];
                                    rc++;
                                    break;
                                case 1:
                                    green += genome[i];
                                    gc++;
                                    break;
                                case 2:
                                    blue += genome[i];
                                    bc++;
                                    break;
                            }
                    }

                    if(rc != 0)
                        red /= rc;

                    if(gc != 0)
                        green /= gc;

                    if(bc != 0)
                        blue /= bc;

                    if(nop.colorScheme == 1)
                    {
                        red = 1 - MinDistance(0.5f, blue) * 2;
                        green = 1 - MinDistance(0.5f, red) * 2;
                        blue = 1 - MinDistance(0.5f, green) * 2;
                    }

                    switch(nop.colorScheme)
                    {
                        case 0:
                            c0 = new Color(red, green, blue);
                            bc0 = true;
                            break;
                        case 1:
                            c1 = new Color(red, green, blue);
                            bc1 = true;
                            break;
                        case 2:
                            c2 = new Color(red, green, blue);
                            bc2 = true;
                            break;
                    }
                }
            }

            switch(nop.colorScheme)
            {
                case 0:
                    s.color = c0;
                    break;
                case 1:
                    s.color = c1;
                    break;
                case 2:
                    s.color = c2;
                    break;
            }

            GetComponent<SpriteColorSwitcher>().Switch();
        }
    }

    float MinDistance(float p1, float p2)
    {
        float result = Mathf.Abs(p1 - p2);

        if(result > 0.5)
            result = 1 - result;

        return result;
    }
}
