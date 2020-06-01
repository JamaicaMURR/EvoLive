using UnityEngine;
using System.Collections;
using System;

public class TNC : MonoBehaviour
{
    TNOptions tno;
    MapMaster mm;

    private int line = int.MaxValue;

    public int Line
    {
        get { return line; }
        set
        {
            if(value != line)
            {
                line = value;
                SetAccordingTNC();
            }
        }
    }

    private int pos = int.MaxValue;

    public int Pos
    {
        get { return pos; }
        set
        {
            if(value != pos)
            {
                pos = value;
                SetAccordingTNC();
            }
        }
    }

    private int dir;

    public int Dir
    {
        get { return dir; }
        set
        {
            dir = NormalizeDir(value);
            SetAccordingDir();
        }
    }

    public void SetTNC(int l, int p)
    {
        line = l;
        pos = p;
        SetAccordingTNC();
    }
    //=============================================================================================================================

    void Awake()
    {
        tno = GameObject.Find("Master").GetComponent<TNOptions>();
        mm = GameObject.Find("Master").GetComponent<MapMaster>();
    }

    //=============================================================================================================================

    public bool TNCAtDir(int d, out int l, out int p)
    {
        bool isSuccess = false;

        l = Line;
        p = Pos;

        switch(NormalizeDir(d))
        {
            case 0:
                p++;

                isSuccess = tno.IsAtTN(l, p);

                break;
            case 1:
                l--;

                if(l % 2 == 0)
                    p++;

                isSuccess = tno.IsAtTN(l, p);

                break;
            case 2:
                l--;

                if(Math.Abs(l % 2) == 1)
                    p--;

                isSuccess = tno.IsAtTN(l, p);

                break;
            case 3:
                p--;

                isSuccess = tno.IsAtTN(l, p);

                break;
            case 4:
                l++;

                if(Math.Abs(l % 2) == 1)
                    p--;

                isSuccess = tno.IsAtTN(l, p);

                break;
            case 5:
                l++;

                if(l % 2 == 0)
                    p++;

                isSuccess = tno.IsAtTN(l, p);

                break;
            default:
                break;
        }

        if(isSuccess)
            NormalizeLinePos(l, p, out l, out p);

        return isSuccess;
    }

    //=============================================================================================================================

    public static int NormalizeDir(int direction)
    {
        while(direction < 0 || direction > 5)
            direction = (6 + direction) % 6;

        return direction;
    }

    //=============================================================================================================================

    public static int DirShortBow(int dir1, int dir2)
    {
        int shortBow = 0;

        dir1 = NormalizeDir(dir1);
        dir2 = NormalizeDir(dir2);

        shortBow = NormalizeDir(dir1 - dir2);

        if(shortBow > 3)
            shortBow = 6 - shortBow;

        return shortBow;
    }

    //=============================================================================================================================

    public bool NormalizeLinePos(int l, int p, out int ol, out int op)
    {
        bool isSuccess = false;

        ol = l;
        op = p;

        if(tno.IsAtTN(l, p))
        {
            if(l > tno.uLine)
            {
                ol = tno.dLine + (l % tno.uLine - 1);

                if(tno.netHeight % 2 == 1)
                    op++;
            }

            if(l < tno.dLine)
                ol = tno.uLine + (l % tno.dLine + 1);

            if(p > tno.rPos)
                op = tno.lPos + (p % tno.rPos - 1);

            if(p < tno.lPos)
                op = tno.rPos + (p % tno.lPos + 1);

            isSuccess = true;
        }

        return isSuccess;
    }

    //=============================================================================================================================

    void GetDecartsFromTNC(int line, int pos, out float x, out float y)
    {
        if(line % 2 == 0)
            x = pos * tno.gap + tno.pillarX;
        else
            x = pos * tno.gap + 0.5f * tno.gap + tno.pillarX;

        y = line * tno.gap * 0.866f + tno.pillarY;
    }

    //=============================================================================================================================

    void SetAccordingTNC()
    {
        float x;
        float y;

        GetDecartsFromTNC(line, pos, out x, out y);

        GetComponent<Transform>().position = new Vector3(x, y, GetComponent<Transform>().position.z);
    }

    //=============================================================================================================================

    bool IsCoordinatesComplain()
    {
        bool result = false;

        float ax = GetComponent<Transform>().position.x;
        float ay = GetComponent<Transform>().position.y;

        float x;
        float y;

        GetDecartsFromTNC(line, pos, out x, out y);

        if(Math.Round(x, 5) == Math.Round(ax, 5) && Math.Round(y, 5) == Math.Round(ay, 5))
            result = true;

        return result;
    }

    //=============================================================================================================================

    void SetAccordingDir()
    {
        GetComponent<Transform>().rotation = new Quaternion(0, 0, 0, 1.0f);
        GetComponent<Transform>().Rotate(Vector3.back, 60 * dir);
    }
}
