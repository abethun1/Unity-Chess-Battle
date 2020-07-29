using UnityEngine;
using System.Collections;

public class Pawn : Characters {

    private bool firstMove;
    private bool promoted;

    public override void Start(){
		base.Start ();
        firstMove = true;
        promoted = false;
        pointValue = 1;
	}

	public override bool[,] PossibleMove(){
		bool[,] r = new bool[BoardManager.Instance.getBoardSizeX(), BoardManager.Instance.getBoardSizeY()];

		Characters c, c2;

        if (!promoted)
        {
            //Diagonal upleft 
            if (CurrentX != 0 && CurrentY != BoardManager.Instance.getBoardSizeY() - 1)
            {
                c = BoardManager.Instance.Characters[CurrentX - 1, CurrentY + 1];
                if (c != null)
                {
                    if ((isPlayer && !c.isPlayer) || (!isPlayer && c.isPlayer))
                    {
                        r[CurrentX - 1, CurrentY + 1] = true;
                    }
                }
            }
            //Diagonal upright
            if (CurrentX != BoardManager.Instance.getBoardSizeX() - 1 && CurrentY != BoardManager.Instance.getBoardSizeY() - 1)
            {
                c = BoardManager.Instance.Characters[CurrentX + 1, CurrentY + 1];
                if (c != null)
                {
                    if ((isPlayer && !c.isPlayer) || (!isPlayer && c.isPlayer))
                    {
                        r[CurrentX + 1, CurrentY + 1] = true;
                    }

                }
            }
            //Diagonal downleft
            if (CurrentX != 0 && CurrentY != 0)
            {
                c = BoardManager.Instance.Characters[CurrentX - 1, CurrentY - 1];
                if (c != null)
                {
                    if ((isPlayer && !c.isPlayer) || (!isPlayer && c.isPlayer))
                    {
                        r[CurrentX - 1, CurrentY - 1] = true;
                    }

                }
            }
            //Diagonal downright
            if (CurrentX != BoardManager.Instance.getBoardSizeX() - 1 && CurrentY != 0)
            {
                c = BoardManager.Instance.Characters[CurrentX + 1, CurrentY - 1];
                if (c != null)
                {
                    if ((isPlayer && !c.isPlayer) || (!isPlayer && c.isPlayer))
                    {
                        r[CurrentX + 1, CurrentY - 1] = true;
                    }

                }
            }
            //Move 1
            if (CurrentY != BoardManager.Instance.getBoardSizeY() - 1)
            {
                c = BoardManager.Instance.Characters[CurrentX, CurrentY + 1];
                if (c == null)
                {
                    r[CurrentX, CurrentY + 1] = true;
                }
            }
            if (CurrentY != 0)
            {
                c = BoardManager.Instance.Characters[CurrentX, CurrentY - 1];
                if (c == null)
                {
                    r[CurrentX, CurrentY - 1] = true;
                }
            }
            if (CurrentX < BoardManager.Instance.getBoardSizeX() - 1)
            {
                c = BoardManager.Instance.Characters[CurrentX + 1, CurrentY];
                if (c == null)
                {
                    r[CurrentX + 1, CurrentY] = true;
                }
            }
            if (CurrentX != 0)
            {
                c = BoardManager.Instance.Characters[CurrentX - 1, CurrentY];
                if (c == null)
                {
                    r[CurrentX - 1, CurrentY] = true;
                }
            }

            //first move
            if (CurrentY == 1 && firstMove)
            {
                c = BoardManager.Instance.Characters[CurrentX, CurrentY + 1];
                c2 = BoardManager.Instance.Characters[CurrentX, CurrentY + 2];

                if (c == null && c2 == null)
                {
                    r[CurrentX, CurrentY + 2] = true;
                }
            }

            else if (CurrentY == 0 && firstMove)
            {
                c = BoardManager.Instance.Characters[CurrentX, CurrentY + 1];
                c2 = BoardManager.Instance.Characters[CurrentX, CurrentY + 2];

                if (c == null && c2 == null)
                {
                    r[CurrentX, CurrentY + 2] = true;
                }
            }

            else if (CurrentY == BoardManager.Instance.getBoardSizeY() - 2 && firstMove)
            {
                c = BoardManager.Instance.Characters[CurrentX, CurrentY - 1];
                c2 = BoardManager.Instance.Characters[CurrentX, CurrentY - 2];

                if (c == null && c2 == null)
                {
                    r[CurrentX, CurrentY - 2] = true;
                }
            }
            else if (CurrentY == BoardManager.Instance.getBoardSizeY() - 1 && firstMove)
            {
                c = BoardManager.Instance.Characters[CurrentX, CurrentY - 1];
                c2 = BoardManager.Instance.Characters[CurrentX, CurrentY - 2];

                if (c == null && c2 == null)
                {
                    r[CurrentX, CurrentY - 2] = true;
                }
            }
        }

        else
        {
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

            //Right
            i = CurrentX;

            while (true)
            {
                i++;
                if (i >= BoardManager.Instance.getBoardSizeX())
                    break;

                c = BoardManager.Instance.Characters[i, CurrentY];
                if (c == null)
                {
                    r[i, CurrentY] = true;
                }
                else
                {
                    if (c.isPlayer != isPlayer)
                    {
                        r[i, CurrentY] = true;
                    }
                    break;
                }
            }

            //Left
            i = CurrentX;

            while (true)
            {
                i--;
                if (i < 0)
                    break;

                c = BoardManager.Instance.Characters[i, CurrentY];
                if (c == null)
                {
                    r[i, CurrentY] = true;
                }
                else
                {
                    if (c.isPlayer != isPlayer)
                    {
                        r[i, CurrentY] = true;
                    }
                    break;
                }
            }

            //Up
            i = CurrentY;

            while (true)
            {
                i++;
                if (i >= BoardManager.Instance.getBoardSizeY())
                    break;

                c = BoardManager.Instance.Characters[CurrentX, i];
                if (c == null)
                {
                    r[CurrentX, i] = true;
                }
                else
                {
                    if (c.isPlayer != isPlayer)
                    {
                        r[CurrentX, i] = true;
                    }
                    break;
                }
            }

            //Down
            i = CurrentY;

            while (true)
            {
                i--;
                if (i < 0)
                    break;

                c = BoardManager.Instance.Characters[CurrentX, i];
                if (c == null)
                {
                    r[CurrentX, i] = true;
                }
                else
                {
                    if (c.isPlayer != isPlayer)
                    {
                        r[CurrentX, i] = true;
                    }
                    break;
                }
            }
        }

            return r;
	}	

    public void setFirstMove(bool m)
    {
        firstMove = m;
    }

    public bool getFirstMove()
    {
        return firstMove;
    }

    public void Promotion()
    {
        promoted = true;
    }
}
