using UnityEngine;
using System.Collections;

public class Knight : Characters {

	public override void Start(){
		base.Start ();
        pointValue = 2;
	}

	public override bool[,] PossibleMove(){

        bool[,] r = new bool[BoardManager.Instance.getBoardSizeX(), BoardManager.Instance.getBoardSizeY()];

        //Up Left
        knightMove(CurrentX - 1, CurrentY + 2, ref r);

		//Up Right
		knightMove(CurrentX + 1, CurrentY + 2, ref r);

		//Right Up
		knightMove(CurrentX + 2, CurrentY + 1, ref r);

		//Right Down
		knightMove(CurrentX + 2, CurrentY - 1, ref r);

		//Down Left
		knightMove(CurrentX - 1, CurrentY - 2, ref r);

		//Down Right
		knightMove(CurrentX + 1, CurrentY - 2, ref r);

		//Left Up
		knightMove(CurrentX - 2, CurrentY + 1, ref r);

		//Left Down
		knightMove(CurrentX - 2, CurrentY - 1, ref r);


		return r;


	}

	public void knightMove(int x, int y, ref bool[,] r){

		Characters c;
		if (x >= 0 && x < BoardManager.Instance.getBoardSizeX() && y >= 0 && y < BoardManager.Instance.getBoardSizeY()) {
			c = BoardManager.Instance.Characters [x, y];
			if (c == null) {
				r [x, y] = true;
			}
			else if (isPlayer != c.isPlayer) {
				r [x, y] = true;
			}
		}
	}
		

}
