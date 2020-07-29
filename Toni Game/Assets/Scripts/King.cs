using UnityEngine;
using System.Collections;

public class King : Characters {

	public override void Start(){
		base.Start ();
        pointValue = 5;
	}

	public override bool[,] PossibleMove()
	{
        bool[,] r = new bool[BoardManager.Instance.getBoardSizeX(), BoardManager.Instance.getBoardSizeY()];

        KingMove(CurrentX + 1, CurrentY, ref r); // up
		KingMove(CurrentX - 1, CurrentY, ref r); // down
		KingMove(CurrentX, CurrentY - 1, ref r); // left
		KingMove(CurrentX, CurrentY + 1, ref r); // right
		KingMove(CurrentX + 1, CurrentY -1, ref r); // up left
		KingMove(CurrentX - 1, CurrentY -1, ref r); // down left
		KingMove(CurrentX +1, CurrentY + 1, ref r); // up right
		KingMove(CurrentX - 1, CurrentY + 1, ref r); // down right

		return r;
	}

	public void KingMove(int x, int y, ref bool[,] r)
	{
		Characters c;
		if (x >= 0 && x < BoardManager.Instance.getBoardSizeX() && y >= 0 && y < BoardManager.Instance.getBoardSizeY())
		{
			c = BoardManager.Instance.Characters[x, y];
			if (c == null)
				r[x, y] = true;
			else if (isPlayer != c.isPlayer)
				r[x, y] = true;
		}
	}
}﻿

