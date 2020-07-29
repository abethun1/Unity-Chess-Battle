using UnityEngine;
using System.Collections;

public class Rook : Characters {

	public override void Start(){
		base.Start ();
        pointValue = 4;
	}

	public override bool[,] PossibleMove(){
        bool[,] r = new bool[BoardManager.Instance.getBoardSizeX(), BoardManager.Instance.getBoardSizeY()];

        Characters c;
		int i;

		//Right
		i = CurrentX;

		while (true) {
			i++;
			if (i >= BoardManager.Instance.getBoardSizeX())
				break;

			c = BoardManager.Instance.Characters [i, CurrentY];
			if (c == null) {
				r [i, CurrentY] = true;
			}
			else {
				if (c.isPlayer != isPlayer) {
					r [i, CurrentY] = true;
				}
				break;
			}	
		}

		//Left
		i = CurrentX;

		while (true) {
			i--;
			if (i < 0)
				break;

			c = BoardManager.Instance.Characters [i, CurrentY];
			if (c == null) {
				r [i, CurrentY] = true;
			}
			else {
				if (c.isPlayer != isPlayer) {
					r [i, CurrentY] = true;
				}
				break;
			}	
		}

		//Up
		i = CurrentY;

		while (true) {
			i++;
			if (i >= BoardManager.Instance.getBoardSizeY())
				break;

			c = BoardManager.Instance.Characters [CurrentX, i];
			if (c == null) {
				r [CurrentX, i] = true;
			}
			else {
				if (c.isPlayer != isPlayer) {
					r [CurrentX, i] = true;
				}
				break;
			}	
		}

		//Down
		i = CurrentY;

		while (true) {
			i--;
			if (i < 0)
				break;

			c = BoardManager.Instance.Characters [CurrentX, i];
			if (c == null) {
				r [CurrentX, i] = true;
			}
			else {
				if (c.isPlayer != isPlayer) {
					r [CurrentX, i] = true;
				}
				break;
			}	
		}

		return r;


	}

}
