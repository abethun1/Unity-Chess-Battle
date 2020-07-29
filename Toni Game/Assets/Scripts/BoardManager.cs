using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BoardManager : MonoBehaviour
{

    public static BoardManager Instance { set; get; }
    private bool[,] allowedMoves { set; get; }

    public Characters[,] Characters { set; get; }
    public int[] spawnLocationX;
    public int[] spawnLocationY;
    public Characters selectedCharacter;


    private const float TILE_SIZE = 1.0f;
    private const float TILE_OFFSET = 0.5f;

    private int selectionX = -1;
    private int selectionY = -1;

    public List<GameObject> characters;

    public List<GameObject> PlayerCharacters;
    public List<GameObject> EnemyCharacters;
    private List<GameObject> activeCharacters = new List<GameObject>(); 

    static Quaternion playerOrientation = Quaternion.Euler(0, 0, 0);
    static Quaternion enemyOrientation = Quaternion.Euler(0, 180, 0);

    public bool isPlayerTurn;

    public int boardSizeX;
    public int boardSizeY;

    private bool battleSequence;

    //Character Directions for movement
    private bool movingUp;
    private bool movingDown;
    private bool movingLeft;
    private bool movingRight;
    private Vector3 movingDirection;
    private Vector3 turningDirection;

    //Arrays/List of opponents and players
    private GameObject[] enemies;
    private GameObject[] players;
    private GameAI AI;

    public bool localGame;

    public Camera gameCamera;

    private int playersPoints;
    private int enemyPoints;
    private bool gameOver;

    public Canvas winScreen;
    public Text winText;





    private void Start()
    {
        winScreen.enabled = false;
        gameOver = false;
        Instance = this;
        AI = GameAI.Instance;
        isPlayerTurn = true;
        localGame = true;
        SpawnAllCharacters();
        playersPoints = 0;
        enemyPoints = 0;

    }
    public void Update()
    {

        if (playersPoints >= 10)
        {
            gameOver = true;
            winScreen.enabled = true;
            winText.text = "Player One Wins";
            Debug.Log("player wins");
        }
        else if (enemyPoints >= 10)
        {
            gameOver = true;
            winScreen.enabled = true;
            winText.text = "Player Two Wins";
            Debug.Log("enemy wins");
        }
        DrawChessBoard();
        gameCamera.GetComponent<Animator>().SetBool("PlayersTurn", isPlayerTurn);

        if (localGame && !gameOver)
        {
            if (!movingUp && !movingDown && !movingLeft && !movingRight & !battleSequence)
            {
                UpdateSelection();
            }

            if (Input.GetMouseButtonDown(0) && !movingUp && !movingDown && !movingLeft && !movingRight && !battleSequence)
            {
                if (selectionX >= 0 && selectionY >= 0)
                {
                    if (selectedCharacter == null)
                    {
                        //Select Chess Piece
                        SelectCharacter(selectionX, selectionY);
                    }
                    else
                    {
                        //move piece
                        startMoveCharacter(selectionX, selectionY);
                    }
                }
            }
        }

        else
        {
            if (isPlayerTurn && !movingUp && !movingDown && !movingLeft && !movingRight & !battleSequence)
            {
                UpdateSelection();
            }

            if (Input.GetMouseButtonDown(0) && !movingUp && !movingDown && !movingLeft && !movingRight && isPlayerTurn && !battleSequence)
            {
                if (selectionX >= 0 && selectionY >= 0)
                {
                    if (selectedCharacter == null)
                    {
                        //Select Chess Piece
                        SelectCharacter(selectionX, selectionY);
                    }
                    else
                    {
                        //move piece
                        startMoveCharacter(selectionX, selectionY);
                    }
                }
            }

            if (!isPlayerTurn && !movingUp && !movingDown && !movingLeft && !movingRight && !battleSequence)
            {
                GameAI.Instance.movePiece();
                startMoveCharacter(getSelectionX(), getSelectionY());
            }
        }

    }

    private void FixedUpdate()
    {
        if (movingLeft || movingRight || movingUp || movingDown)
        {

            float tempPosX = selectedCharacter.transform.position.x;
            float tempPosY = selectedCharacter.transform.position.z;
            float tempSelectionX = (float)selectionX + .5f;
            float tempSelectionY = (float)selectionY + .5f;

            Vector3 newPosition = new Vector3(selectedCharacter.transform.position.x, selectedCharacter.transform.position.y, selectedCharacter.transform.position.z);
            Vector3 newDirection = new Vector3(0, 0, 0);

            if (movingLeft)
            {
                if (tempPosX > tempSelectionX)
                {
                    newPosition.x = newPosition.x - 1;
                    newDirection.x = -1;
                }
                else
                {
                    newPosition.x = newPosition.x + 1;
                    newDirection.x = 0;
                    movingLeft = false;
                }

            }

            if (movingRight)
            {
                if (tempPosX < tempSelectionX)
                {
                    newPosition.x = newPosition.x + 1;
                    newDirection.x = 1;
                }
                else
                {
                    newPosition.x = newPosition.x - 1;
                    newDirection.x = 0;
                    movingRight = false;
                }

            }

            if (movingUp)
            {
                if (tempPosY < tempSelectionY)
                {
                    newPosition.z = newPosition.z + 1;
                    newDirection.z = 1;
                }
                else
                {
                    newPosition.z = newPosition.z - 1;
                    newDirection.z = 0;
                    movingUp = false;
                }
            }

            if (movingDown)
            {
                if (tempPosY > tempSelectionY)
                {
                    newPosition.z = newPosition.z - 1;
                    newDirection.z = -1;
                }
                else
                {
                    newPosition.z = newPosition.z + 1;
                    newDirection.z = 0;
                    movingDown = false;
                }
            }

            setMovingDirection(newDirection);
            //running
            if (Mathf.Abs(tempSelectionX - tempPosX) > 2 || Mathf.Abs(tempSelectionY - tempPosY) > 2)
            {
                selectedCharacter.GetComponent<Characters>().movement(true, false, true);
                selectedCharacter.transform.position = Vector3.Lerp(selectedCharacter.transform.position, newPosition, 1.5f * Time.deltaTime);
            }
            //walking
            else
            {
                selectedCharacter.GetComponent<Characters>().movement(true, true, false);
                selectedCharacter.transform.position = Vector3.Lerp(selectedCharacter.transform.position, newPosition, 1f * Time.deltaTime);
            }
            //stopped
            if (movingLeft == false && movingRight == false && movingUp == false && movingDown == false)
            {
                selectedCharacter.GetComponent<Characters>().movement(false, false, false);
                MoveCharacter(selectionX, selectionY);
            }
        }
    }

    private void UpdateSelection()
    {

        if (!Camera.main)
        {
            return;
        }
        

        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 25.0f, LayerMask.GetMask("GamePlane")))
        {
            selectionX = (int)hit.point.x;
            selectionY = (int)hit.point.z;
        }
        else
        {
            selectionX = -1;
            selectionY = -1;
        }
    }

    private void DrawChessBoard()
    {
        
        Vector3 widthLine = Vector3.right * boardSizeX;
        Vector3 heightLine = Vector3.forward * boardSizeY;

        for(int i = 0; i <= boardSizeX; i++)
        {
            Vector3 start = Vector3.forward * i;
            Debug.DrawLine(start, start + widthLine);
            for(int j = 0; j <= boardSizeY; j++)
            {
                start = Vector3.right * j;
                Debug.DrawLine(start, start + heightLine);
            }
        }
    }

    private void SpawnCharacters(int index, int x, int y, bool isEnemy)
    {
        if (isEnemy)
        {
            GameObject go = Instantiate(EnemyCharacters[index], GetTileCenter(x, y), Quaternion.identity) as GameObject;
            go.transform.SetParent(transform);
            Characters[x, y] = go.GetComponent<Characters>();
            Characters[x, y].SetPosition(x, y);
            activeCharacters.Add(go);
        }
        else
        {
            GameObject go = Instantiate(PlayerCharacters[index], GetTileCenter(x, y), Quaternion.identity) as GameObject;
            go.transform.SetParent(transform);
            Characters[x, y] = go.GetComponent<Characters>();
            Characters[x, y].SetPosition(x, y);
            activeCharacters.Add(go);
        }

    }

    private void SpawnAllCharacters()
    {

        activeCharacters = new List<GameObject>();
        Characters = new Characters[boardSizeX, boardSizeY];

        SpawnPlayerFormation(1);
        SpawnEnemyFormation(1);

        players = GameObject.FindGameObjectsWithTag("Player");
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    private void SpawnPlayerFormation(int f)
    {
        if(f == 1)
        {
            
            SpawnCharacters(PlayerPrefs.GetInt("PP1"), 2, 0, false);
            SpawnCharacters(PlayerPrefs.GetInt("PP2"), 2, 1, false);
            SpawnCharacters(PlayerPrefs.GetInt("PP3"), 3, 0, false);//king
            SpawnCharacters(PlayerPrefs.GetInt("PP4"), 3, 1, false);
            SpawnCharacters(PlayerPrefs.GetInt("PP5"), 4, 0, false);
            SpawnCharacters(PlayerPrefs.GetInt("PP6"), 4, 1, false);
        }
        else if (f == 2)
        {
            SpawnCharacters(PlayerPrefs.GetInt("PP1"), 0, 0, false);
            SpawnCharacters(PlayerPrefs.GetInt("PP2"), 0, 1, false);
            SpawnCharacters(PlayerPrefs.GetInt("PP3"), 3, 0, false);//king
            SpawnCharacters(PlayerPrefs.GetInt("PP4"), 3, 1, false);
            SpawnCharacters(PlayerPrefs.GetInt("PP5"), 6, 0, false);
            SpawnCharacters(PlayerPrefs.GetInt("PP6"), 6, 1, false);
        }
    }

    private void SpawnEnemyFormation(int f)
    {
        if (f == 1)
        {
            SpawnCharacters(PlayerPrefs.GetInt("EP1"), 4, 7, true);
            SpawnCharacters(PlayerPrefs.GetInt("EP2"), 4, 6, true);
            SpawnCharacters(PlayerPrefs.GetInt("EP3"), 3, 7, true);//king
            SpawnCharacters(PlayerPrefs.GetInt("EP4"), 3, 6, true);
            SpawnCharacters(PlayerPrefs.GetInt("EP5"), 2, 7, true);
            SpawnCharacters(PlayerPrefs.GetInt("EP6"), 2, 6, true);

        }
        else if (f == 2)
        {
            //needs to be edited for new formation
            SpawnCharacters(PlayerPrefs.GetInt("EP1"), 4, 7, true);
            SpawnCharacters(PlayerPrefs.GetInt("EP2"), 4, 6, true);
            SpawnCharacters(PlayerPrefs.GetInt("EP3"), 3, 7, true);//king
            SpawnCharacters(PlayerPrefs.GetInt("EP4"), 3, 6, true);
            SpawnCharacters(PlayerPrefs.GetInt("EP5"), 2, 7, true);
            SpawnCharacters(PlayerPrefs.GetInt("EP6"), 2, 6, true);
        }
    }

    private Vector3 GetTileCenter(int x, int y)
    {
        Vector3 origin = Vector3.zero;
        origin.x += (TILE_SIZE * x) + TILE_OFFSET;
        origin.z += (TILE_SIZE * y) + TILE_OFFSET;

        return origin;

    }
   
    private void SelectCharacter(int x, int y)
    {
        if(Characters[x,y] == null)
        {
            return;
        }
        if(Characters[x,y].isPlayer != isPlayerTurn)
        {
            return;
        }

        allowedMoves = Characters[x, y].PossibleMove();
        selectedCharacter = Characters[x, y];
        BoardHighlights.Instance.HighlightAllowedMoves(allowedMoves);
    }

    private void MoveCharacter(int x, int y)
    {
        if (allowedMoves[x,y])
        {
            
            if (selectedCharacter.GetComponent<Pawn>() != null)
            {
                if (selectedCharacter.GetComponent<Pawn>().getFirstMove())
                {
                    selectedCharacter.GetComponent<Pawn>().setFirstMove(false);
                }
                if ((isPlayerTurn && y == getBoardSizeY() - 1) || (!isPlayerTurn && y == 0))
                {
                    selectedCharacter.GetComponent<Pawn>().Promotion();
                }
               
            }
            //sets position in the cool array of characters to null for that position
            Characters[selectedCharacter.CurrentX, selectedCharacter.CurrentY] = null;
            selectedCharacter.transform.position = GetTileCenter(x, y);
            selectedCharacter.SetPosition(x, y);
            Characters[x, y] = selectedCharacter;

            //Change the turn
            isPlayerTurn = !isPlayerTurn;

        }
        BoardHighlights.Instance.HideHighlights();
        selectedCharacter = null;
    }

    public void startMoveCharacter(int x, int y)
    {
        //Don't attack the piece just move
        if (allowedMoves[x, y] && getCharacter(x, y) == null)
        {
            //Move Left
            movingLeft = true;

            //Move Right
            movingRight = true;

            //Move Up
            movingUp = true;

            //Move Down
            movingDown = true;
        }

        //Attack and Move
        else if (selectedCharacter.getAttackPower() >= getCharacter(x, y).getCurrentHealth() && allowedMoves[x, y])
        {
            battleSequence = true;
            StartCoroutine(attackAndMove(selectedCharacter, getCharacter(x, y)));

            if (isPlayerTurn)
            {
                playersPoints += getCharacter(x, y).getPointValue();
                Debug.Log(playersPoints);
            }
            else
            {
                enemyPoints += getCharacter(x, y).getPointValue();
                Debug.Log(enemyPoints);
            }
        }
        //Don't move the piece just attack
        else if (allowedMoves[x, y])
        {
            battleSequence = true;
            StartCoroutine(attack(selectedCharacter, getCharacter(x, y)));
            if(enemies.Length > 0)
                isPlayerTurn = !isPlayerTurn;
            BoardHighlights.Instance.HideHighlights();
            selectedCharacter = null;
        }
        else
        {
            BoardHighlights.Instance.HideHighlights();
            selectedCharacter = null;
        }
    }

    private IEnumerator attack(Characters a, Characters b)
    {
        b.turnColliderOn();
        StartCoroutine(a.attacking(0, b));//Close attack
        yield return new WaitForSeconds(5);
        battleSequence = false;
    }

    private IEnumerator attackAndMove(Characters a, Characters b)
    {
        b.turnColliderOn();
        if (!isPlayerTurn)
            yield return new WaitForSeconds(1);
        int nextX = b.CurrentX;
        int nextY = b.CurrentY;
        StartCoroutine(b.Death());
        StartCoroutine(a.attacking(0, b));//Close attack
        yield return new WaitForSeconds(5);
        battleSequence = false;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        selectedCharacter = a;
        startMoveCharacter(nextX, nextY);
    }


    public Vector3 getMovingDirection()
    {
        return movingDirection;
    }

    private void setMovingDirection(Vector3 d)
    {
        movingDirection = d;
    }

    public Characters getCharacter(int x, int y)
    {
        Characters c = Characters[x, y];
        return c;
    }

    public int getBoardSizeX()
    {
        return boardSizeX;
    }

    public int getBoardSizeY()
    {
        return boardSizeY;
    }

    public void setSelectionX(int x)
    {
        selectionX = x;
    }

    public void setSelectionY(int y)
    {
        selectionY = y;
    }
    public int getSelectionX()
    {
        return selectionX;
    }

    public int getSelectionY()
    {
        return selectionY;
    }

    public GameObject[] getPlayers()
    {
        return players;
    }

    public void setBattleSequence(bool b)
    {
        battleSequence = b;
    }

    public void Restart()
    {
        SceneManager.LoadScene("TG battle Local");
    }
    public void Home()
    {
        SceneManager.LoadScene("PlayerSelect");
    }
}
