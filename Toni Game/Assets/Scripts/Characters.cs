using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Characters : MonoBehaviour {

    public int CurrentX { set; get; }
    public int CurrentY { set; get; }

    public bool isPlayer;
    public bool isEnemy;

    public Animator animatorController;
    public Rigidbody rigidBody;
    public CapsuleCollider capsuleCollider;

    public bool walking { set; get; }
    public bool running { set; get; }
    public bool canJump { set; get; }
    public bool turning;
    private bool isMoving;


    public static Quaternion playerOrientation = Quaternion.Euler(0, 0, 0);
    static Quaternion enemyOreintation = Quaternion.Euler(0, 180, 0);

    //Unique character variables
    public int baseAttackPower;
    public int attackPower;
    public int maxHealth;
    private int currentHealth;
    public int pointValue;

    public virtual void Start()
    {
        animatorController = gameObject.GetComponent<Animator>();
        rigidBody = gameObject.GetComponent<Rigidbody>();
        capsuleCollider = gameObject.GetComponent<CapsuleCollider>();

        capsuleCollider.enabled = true;

    }

    public virtual void FixedUpdate()
    {
        if (getIsMoving())
        {
            if (walking)
                animatorController.SetBool("Walk", true);
            else if (running)
                animatorController.SetBool("Run", true);
            Vector3 movement = BoardManager.Instance.getMovingDirection();
            Quaternion targetRotation = Quaternion.LookRotation(movement, Vector3.up);
            Quaternion newRotation = Quaternion.Lerp(rigidBody.rotation, targetRotation, 10 * Time.deltaTime);
            rigidBody.MoveRotation(newRotation);
        }
        else if (!turning)
        {
            if (isPlayer)
                rigidBody.MoveRotation(playerOrientation);
            else if (isEnemy)
                rigidBody.MoveRotation(enemyOreintation);

            animatorController.SetBool("Walk", false);
            animatorController.SetBool("Run", false);
        }
    }

    public void SetPosition(int x, int y)
    {
        CurrentX = x;
        CurrentY = y;
    }

    public IEnumerator attacking(int n, Characters t)
    {

        turning = true;
        var targetRotation = Quaternion.LookRotation(t.transform.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 5 * Time.deltaTime);

        if (n == 0)
        {
            animatorController.SetBool("Attack1", true);
            yield return new WaitForSeconds(1.5f);
            animatorController.SetBool("Attack1", false);
        }
        else if (n == 1)
        {
            animatorController.SetBool("Attack2", true);
            yield return new WaitForSeconds(0.5f);
            animatorController.SetBool("Attack2", false);
        }
        turning = false;
        //Other kinds of attacks beside close and range
    }

    public virtual IEnumerator Death()
    {
        animatorController.SetBool("Alive", false);
        yield return new WaitForEndOfFrame();
        yield return new WaitForSeconds(animatorController.GetCurrentAnimatorStateInfo(0).length * 1);
        Destroy(gameObject);
    }

    public virtual bool[,] PossibleMove()
    {
        return new bool[BoardManager.Instance.getBoardSizeX(), BoardManager.Instance.getBoardSizeY()];
    }

    private void setIsMoving(bool m)
    {
        isMoving = m;
    }

    public bool getIsMoving()
    {
        return isMoving;
    }
    public void movement(bool m, bool w, bool r)
    {
        setIsMoving(m);
        walking = w;
        running = r;
    }

    public int getCurrentHealth()
    {
        return currentHealth;
    }

    public int getMaxHealth()
    {
        return maxHealth;
    }

    public virtual void setCurrentHealth(int h)
    {
        currentHealth = h;
    }

    public virtual void setAttackPower(int h)
    {
        attackPower = h;
    }

    public int getAttackPower()
    {
        return attackPower;
    }

    public int getPointValue()
    {
        return pointValue;
    }

    public void turnColliderOn()
    {
        capsuleCollider.enabled = true;
    }
}
