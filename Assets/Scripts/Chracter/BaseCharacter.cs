using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : MonoBehaviour
{
    protected ClassType unitType;
    protected int Health=100;
    protected int AttackDammage=10;
    protected int Armor=5;
    protected int AttackSpeed=1;
    public Animator animator;
    public float moveSpeed = 1f;

    protected static readonly int DoMove = Animator.StringToHash("doMove");
    protected static readonly int DoAttack = Animator.StringToHash("doAttack");
    protected static readonly int DoHit = Animator.StringToHash("doHit");
    protected static readonly int DODie = Animator.StringToHash("doDie");

    protected bool isAttacking = false;
    protected bool isMoving = false;



    private Vector3 RightLeft;
    private string Enemy;
    private string Team;



    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Enemy!=null) 
            CheckAnimatorState();
    }

    private void FixedUpdate()
    {
        if (Enemy != null)
            CheckEnemy();
    }


    public virtual void SetCharacterSettings(int HP=100,int Attack=10, int armor=0, int attackSpeed=1)
    {
        Health = HP;
        AttackDammage = Attack;
        Armor = armor;
        AttackSpeed = attackSpeed;
    }


    private void CheckEnemy()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, RightLeft, 0.5f);
        //draw the ray in the scene view with distance 
        Debug.DrawRay(transform.position, RightLeft * 0.5f, Color.red);
        if (hit.collider != null)
        {
            if (hit.collider.CompareTag(Enemy) && isAttacking == false)
            {
                isAttacking = true;
                isMoving = false;
                StartCoroutine(Attack(hit));
            }
            if(hit.collider.CompareTag(Team) && isAttacking == false&& isMoving == false)
            {
                isMoving = true;
                animator.SetTrigger(DoMove);
            }
        }

    }

    private void CheckAnimatorState()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Move"))
        {
            StartCoroutine(MoveCharacter());
        }
    }

    private IEnumerator MoveCharacter()
    {
        transform.position += moveSpeed * Time.deltaTime * RightLeft;
        yield return null;
    }



    public IEnumerator Attack(RaycastHit2D hit)
    {
        animator.SetTrigger(DoAttack);
        hit.collider.GetComponent<BaseCharacter>().TakeDamage(AttackDammage);
        yield return new WaitForSeconds(0.5f);
        isAttacking = false;
    }


    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }



    public void CheckTeam()
    {
        Debug.Log("Asdfasefasdfasefa");
        if (this.tag == "Enemy")
        {
            Debug.Log("Team");
           RightLeft = Vector3.left;
            Enemy = "Team";
            Team = "Enemy";
        }
        else
        {
            Debug.Log("Enemy");
            RightLeft = Vector3.right;
            Enemy = "Enemy";
            Team = "Team";
        }
        animator.SetTrigger(DoMove);
    }
}
