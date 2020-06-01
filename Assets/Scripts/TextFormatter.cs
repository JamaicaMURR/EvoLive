using UnityEngine;
using System.Collections;

public class TextFormatter : MonoBehaviour
{
    public static string Format(int num, int symbols)
    {
        string res = "";
        int symb = 0;

        while(num>0)
        {
            res = num % 10 + res;
            num /= 10;
            symb++;
        }

        while(res.Length < symbols)
            res = "0" + res;

        return res;
    }

    public static string Format(ulong num, int symbols)
    {
        return Format((int)num, symbols);
    }
}
