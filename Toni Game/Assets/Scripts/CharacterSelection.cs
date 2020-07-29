using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour {

    private int pp1;
    private int pp2;
    private int pp3;
    private int pp4;
    private int pp5;
    private int pp6;

    private int ep1;
    private int ep2;
    private int ep3;
    private int ep4;
    private int ep5;
    private int ep6;

    public Text pp1Text;
    public Text pp2Text;
    public Text pp3Text;
    public Text pp4Text;
    public Text pp5Text;
    public Text pp6Text;

    public Text ep1Text;
    public Text ep2Text;
    public Text ep3Text;
    public Text ep4Text;
    public Text ep5Text;
    public Text ep6Text;

    // Use this for initialization
    //Pawn = 0
    //Knight = 1
    //Bishop = 2
    //Rook = 3
    //King = 4

    void Start () {
        pp1 = 0;
        pp2 = 0;
        pp3 = 4;
        pp4 = 0;
        pp5 = 0;
        pp6 = 0;

        ep1 = 0;
        ep2 = 0;
        ep3 = 4;
        ep4 = 0;
        ep5 = 0;
        ep6 = 0;

    }
	
	// Update is called once per frame
	void Update () {
        
        
        
        
    }

    public void leftArrowPlayerPosition1()
    {
        if(pp1 <= 0)
            pp1 = 3;
        else
            pp1 -= 1;

        switch (pp1)
        {
            case 0:
                pp1Text.text = "Pawn";
                break;
            case 1:
                pp1Text.text = "Knight";
                break;
            case 2:
                pp1Text.text = "Bishop";
                break;
            case 3:
                pp1Text.text = "Rook";
                break;
            case 4:
                pp1Text.text = "King";
                break;
        }
    }
    public void leftArrowPlayerPosition2()
    {
        if (pp2 <= 0)
            pp2 = 3;
        else
            pp2 -= 1;

        switch (pp2)
        {
            case 0:
                pp2Text.text = "Pawn";
                break;
            case 1:
                pp2Text.text = "Knight";
                break;
            case 2:
                pp2Text.text = "Bishop";
                break;
            case 3:
                pp2Text.text = "Rook";
                break;
            case 4:
                pp2Text.text = "King";
                break;
        }
    }
    public void leftArrowPlayerPosition3()
    {
        if (pp3 <= 0)
            pp3 = 3;
        else
            pp3 -= 1;

        switch (pp3)
        {
            case 0:
                pp3Text.text = "Pawn";
                break;
            case 1:
                pp3Text.text = "Knight";
                break;
            case 2:
                pp3Text.text = "Bishop";
                break;
            case 3:
                pp3Text.text = "Rook";
                break;
            case 4:
                pp3Text.text = "King";
                break;
        }
    }
    public void leftArrowPlayerPosition4()
    {
        if (pp4 <= 0)
            pp4 = 3;
        else
            pp4 -= 1;

        switch (pp4)
        {
            case 0:
                pp4Text.text = "Pawn";
                break;
            case 1:
                pp4Text.text = "Knight";
                break;
            case 2:
                pp4Text.text = "Bishop";
                break;
            case 3:
                pp4Text.text = "Rook";
                break;
            case 4:
                pp4Text.text = "King";
                break;
        }
    }
    public void leftArrowPlayerPosition5()
    {
        if (pp5 <= 0)
            pp5 = 3;
        else
            pp5 -= 1;

        switch (pp5)
        {
            case 0:
                pp5Text.text = "Pawn";
                break;
            case 1:
                pp5Text.text = "Knight";
                break;
            case 2:
                pp5Text.text = "Bishop";
                break;
            case 3:
                pp5Text.text = "Rook";
                break;
            case 4:
                pp5Text.text = "King";
                break;
        }
    }
    public void leftArrowPlayerPosition6()
    {
        if (pp6 <= 0)
            pp6 = 3;
        else
            pp6 -= 1;

        switch (pp6)
        {
            case 0:
                pp6Text.text = "Pawn";
                break;
            case 1:
                pp6Text.text = "Knight";
                break;
            case 2:
                pp6Text.text = "Bishop";
                break;
            case 3:
                pp6Text.text = "Rook";
                break;
            case 4:
                pp6Text.text = "King";
                break;
        }
    }

    public void rightArrowPlayerPosition1()
    {
        if (pp1 >= 3)
            pp1 = 0;
        else
            pp1 += 1;

        switch (pp1)
        {
            case 0:
                pp1Text.text = "Pawn";
                break;
            case 1:
                pp1Text.text = "Knight";
                break;
            case 2:
                pp1Text.text = "Bishop";
                break;
            case 3:
                pp1Text.text = "Rook";
                break;
            case 4:
                pp1Text.text = "King";
                break;
        }
    }
    public void rightArrowPlayerPosition2()
    {
        if (pp2 >= 3)
            pp2 = 0;
        else
            pp2 += 1;

        switch (pp2)
        {
            case 0:
                pp2Text.text = "Pawn";
                break;
            case 1:
                pp2Text.text = "Knight";
                break;
            case 2:
                pp2Text.text = "Bishop";
                break;
            case 3:
                pp2Text.text = "Rook";
                break;
            case 4:
                pp2Text.text = "King";
                break;
        }
    }
    public void rightArrowPlayerPosition3()
    {
        if (pp3 >= 3)
            pp3 = 0;
        else
            pp3 += 1;

        switch (pp3)
        {
            case 0:
                pp3Text.text = "Pawn";
                break;
            case 1:
                pp3Text.text = "Knight";
                break;
            case 2:
                pp3Text.text = "Bishop";
                break;
            case 3:
                pp3Text.text = "Rook";
                break;
            case 4:
                pp3Text.text = "King";
                break;
        }
    }
    public void rightArrowPlayerPosition4()
    {
        if (pp4 >= 3)
            pp4 = 0;
        else
            pp4 += 1;

        switch (pp4)
        {
            case 0:
                pp4Text.text = "Pawn";
                break;
            case 1:
                pp4Text.text = "Knight";
                break;
            case 2:
                pp4Text.text = "Bishop";
                break;
            case 3:
                pp4Text.text = "Rook";
                break;
            case 4:
                pp4Text.text = "King";
                break;
        }
    }
    public void rightArrowPlayerPosition5()
    {
        if (pp5 >= 3)
            pp5 = 0;
        else
            pp5 += 1;

        switch (pp5)
        {
            case 0:
                pp5Text.text = "Pawn";
                break;
            case 1:
                pp5Text.text = "Knight";
                break;
            case 2:
                pp5Text.text = "Bishop";
                break;
            case 3:
                pp5Text.text = "Rook";
                break;
            case 4:
                pp5Text.text = "King";
                break;
        }
    }
    public void rightArrowPlayerPosition6()
    {
        if (pp6 >= 3)
            pp6 = 0;
        else
            pp6 += 1;

        switch (pp6)
        {
            case 0:
                pp6Text.text = "Pawn";
                break;
            case 1:
                pp6Text.text = "Knight";
                break;
            case 2:
                pp6Text.text = "Bishop";
                break;
            case 3:
                pp6Text.text = "Rook";
                break;
            case 4:
                pp6Text.text = "King";
                break;
        }
    }


    public void leftArrowEnemyPosition1()
    {
        if (ep1 <= 0)
            ep1 = 3;
        else
            ep1 -= 1;

        switch (ep1)
        {
            case 0:
                ep1Text.text = "Pawn";
                break;
            case 1:
                ep1Text.text = "Knight";
                break;
            case 2:
                ep1Text.text = "Bishop";
                break;
            case 3:
                ep1Text.text = "Rook";
                break;
            case 4:
                ep1Text.text = "King";
                break;
        }
    }
    public void leftArrowEnemyPosition2()
    {
        if (ep2 <= 0)
            ep2 = 3;
        else
            ep2 -= 1;

        switch (ep2)
        {
            case 0:
                ep2Text.text = "Pawn";
                break;
            case 1:
                ep2Text.text = "Knight";
                break;
            case 2:
                ep2Text.text = "Bishop";
                break;
            case 3:
                ep2Text.text = "Rook";
                break;
            case 4:
                ep2Text.text = "King";
                break;
        }
    }
    public void leftArrowEnemyPosition3()
    {
        if (ep3 <= 0)
            ep3 = 3;
        else
            ep3 -= 1;

        switch (ep3)
        {
            case 0:
                ep3Text.text = "Pawn";
                break;
            case 1:
                ep3Text.text = "Knight";
                break;
            case 2:
                ep3Text.text = "Bishop";
                break;
            case 3:
                ep3Text.text = "Rook";
                break;
            case 4:
                ep3Text.text = "King";
                break;
        }
    }
    public void leftArrowEnemyPosition4()
    {
        if (ep4 <= 0)
            ep4 = 3;
        else
            ep4 -= 1;

        switch (ep4)
        {
            case 0:
                ep4Text.text = "Pawn";
                break;
            case 1:
                ep4Text.text = "Knight";
                break;
            case 2:
                ep4Text.text = "Bishop";
                break;
            case 3:
                ep4Text.text = "Rook";
                break;
            case 4:
                ep4Text.text = "King";
                break;
        }
    }
    public void leftArrowEnemyPosition5()
    {
        if (ep5 <= 0)
            ep5 = 3;
        else
            ep5 -= 1;

        switch (ep5)
        {
            case 0:
                ep5Text.text = "Pawn";
                break;
            case 1:
                ep5Text.text = "Knight";
                break;
            case 2:
                ep5Text.text = "Bishop";
                break;
            case 3:
                ep5Text.text = "Rook";
                break;
            case 4:
                ep5Text.text = "King";
                break;
        }
    }
    public void leftArrowEnemyPosition6()
    {
        if (ep6 <= 0)
            ep6 = 3;
        else
            ep6 -= 1;

        switch (ep6)
        {
            case 0:
                ep6Text.text = "Pawn";
                break;
            case 1:
                ep6Text.text = "Knight";
                break;
            case 2:
                ep6Text.text = "Bishop";
                break;
            case 3:
                ep6Text.text = "Rook";
                break;
            case 4:
                ep6Text.text = "King";
                break;
        }
    }

    public void rightArrowEnemyPosition1()
    {
        if (ep1 >= 3)
            ep1 = 0;
        else
            ep1 += 1;

        switch (ep1)
        {
            case 0:
                ep1Text.text = "Pawn";
                break;
            case 1:
                ep1Text.text = "Knight";
                break;
            case 2:
                ep1Text.text = "Bishop";
                break;
            case 3:
                ep1Text.text = "Rook";
                break;
            case 4:
                ep1Text.text = "King";
                break;
        }
    }
    public void rightArrowEnemyPosition2()
    {
        if (ep2 >= 3)
            ep2 = 0;
        else
            ep2 += 1;

        switch (ep2)
        {
            case 0:
                ep2Text.text = "Pawn";
                break;
            case 1:
                ep2Text.text = "Knight";
                break;
            case 2:
                ep2Text.text = "Bishop";
                break;
            case 3:
                ep2Text.text = "Rook";
                break;
            case 4:
                ep2Text.text = "King";
                break;
        }
    }
    public void rightArrowEnemyPosition3()
    {
        if (ep3 >= 3)
            ep3 = 0;
        else
            ep3 += 1;

        switch (ep3)
        {
            case 0:
                ep3Text.text = "Pawn";
                break;
            case 1:
                ep3Text.text = "Knight";
                break;
            case 2:
                ep3Text.text = "Bishop";
                break;
            case 3:
                ep3Text.text = "Rook";
                break;
            case 4:
                ep3Text.text = "King";
                break;
        }
    }
    public void rightArrowEnemyPosition4()
    {
        if (ep4 >= 3)
            ep4 = 0;
        else
            ep4 += 1;

        switch (ep4)
        {
            case 0:
                ep4Text.text = "Pawn";
                break;
            case 1:
                ep4Text.text = "Knight";
                break;
            case 2:
                ep4Text.text = "Bishop";
                break;
            case 3:
                ep4Text.text = "Rook";
                break;
            case 4:
                ep4Text.text = "King";
                break;
        }
    }
    public void rightArrowEnemyPosition5()
    {
        if (ep5 >= 3)
            ep5 = 0;
        else
            ep5 += 1;
        switch (ep5)
        {
            case 0:
                ep5Text.text = "Pawn";
                break;
            case 1:
                ep5Text.text = "Knight";
                break;
            case 2:
                ep5Text.text = "Bishop";
                break;
            case 3:
                ep5Text.text = "Rook";
                break;
            case 4:
                ep5Text.text = "King";
                break;
        }
    }
    public void rightArrowEnemyPosition6()
    {
        if (ep6 >= 3)
            ep6 = 0;
        else
            ep6 += 1;

        switch (ep6)
        {
            case 0:
                ep6Text.text = "Pawn";
                break;
            case 1:
                ep6Text.text = "Knight";
                break;
            case 2:
                ep6Text.text = "Bishop";
                break;
            case 3:
                ep6Text.text = "Rook";
                break;
            case 4:
                ep6Text.text = "King";
                break;
        }
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("PP1", pp1);
        PlayerPrefs.SetInt("PP2", pp2);
        PlayerPrefs.SetInt("PP3", pp3);
        PlayerPrefs.SetInt("PP4", pp4);
        PlayerPrefs.SetInt("PP5", pp5);
        PlayerPrefs.SetInt("PP6", pp6);

        PlayerPrefs.SetInt("EP1", ep1);
        PlayerPrefs.SetInt("EP2", ep2);
        PlayerPrefs.SetInt("EP3", ep3);
        PlayerPrefs.SetInt("EP4", ep4);
        PlayerPrefs.SetInt("EP5", ep5);
        PlayerPrefs.SetInt("EP6", ep6);

        SceneManager.LoadScene("TG battle Local");
    }








}
