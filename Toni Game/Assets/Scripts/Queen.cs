using UnityEngine;
using System.Collections;

public class Queen : Characters
{
    public override void Start()
    {
        base.Start();
    }

    public override bool[,] PossibleMove()
    {
        bool[,] r = new bool[BoardManager.Instance.getBoardSizeX(), BoardManager.Instance.getBoardSizeY()];

        Characters c;
        int i, j;

        //Top Left
        i = CurrentX;
        j = CurrentY;

        while (true)
        {
            i--;
            j++;

            if (i < 0 || j >= BoardManager.Instance.getBoardSizeY())
            {
                break;
            }

            c = BoardManager.Instance.Characters[i, j];

            if (c == null)
            {
                r[i, j] = true;
            }
            else
            {
                if (isPlayer != c.isPlayer)
                {
                    r[i, j] = true;
                }
                break;
            }

        }

        //Top Right
        i = CurrentX;
        j = CurrentY;

        while (true)
        {
            i++;
            j++;

            if (i >= BoardManager.Instance.getBoardSizeX() || j >= BoardManager.Instance.getBoardSizeY())
            {
                break;
            }

            c = BoardManager.Instance.Characters[i, j];

            if (c == null)
            {
                r[i, j] = true;
            }
            else
            {
                if (isPlayer != c.isPlayer)
                {
                    r[i, j] = true;
                }
                break;
            }

        }

        //Down Left
        i = CurrentX;
        j = CurrentY;

        while (true)
        {
            i--;
            j--;

            if (i < 0 || j < 0)
            {
                break;
            }

            c = BoardManager.Instance.Characters[i, j];

            if (c == null)
            {
                r[i, j] = true;
            }
            else
            {
                if (isPlayer != c.isPlayer)
                {
                    r[i, j] = true;
                }
                break;
            }

        }

        //Down Right
        i = CurrentX;
        j = CurrentY;

        while (true)
        {
            i++;
            j--;

            if (i >= BoardManager.Instance.getBoardSizeX() || j < 0)
            {
                break;
            }

            c = BoardManager.Instance.Characters[i, j];

            if (c == null)
            {
                r[i, j] = true;
            }
            else
            {
                if (isPlayer != c.isPlayer)
                {
                    r[i, j] = true;
                }
                break;
            }

        }

        return r;
    }
}
