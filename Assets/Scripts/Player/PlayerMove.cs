using System.Collections;
using System.Collections.Generic;
using Chracter;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class PlayerMove : BaseCharacter
{
    
    private bool Attacking = false;
    private bool ismoving = false;
    private bool isSkillMotion = false;
    [SerializeField] protected GameObject rangedAttackPrefableft = null;
    
    void Update()
    {

        if (isSkillMotion)
        {

        }
        else
        {
            if (Input.GetKey(KeyCode.A))
            {
                this.GetComponent<SpriteRenderer>().flipX = false;
                Skill1();
            }
            if (Input.GetKey(KeyCode.S))
            {
                this.GetComponent<SpriteRenderer>().flipX = false;
                Skill2();
            }
        }
        if (ismoving)
        {
            transform.position += MoveSpeed * Time.deltaTime * RightLeft;
        }

    }

    private void FixedUpdate()
    {
        if (Enemy != null&& !isSkillMotion)
            CheckEnemy();
    }

    public override void Spawn()
    {

        SetPlayer();
        CheckTeam();
        healthBar.SetHealthBarColor("Player");
        SetCharacterSettings(50000, 10, 0, 1.4f, 3f, true, true, 1.5f, 200, 120);
        healthBar.SetHealth(MaxHealth, MaxHealth);
    }


    private IEnumerator Move()
    {
        transform.position += MoveSpeed * Time.deltaTime * RightLeft;
        yield return null;
    }
    public void MoveLeft()
    {
        if (!ismoving)
        {
            MoveSpeed = 1.0f;
            ismoving = true;
            animator.SetTrigger(DoMove);
        }
        this.GetComponent<SpriteRenderer>().flipX = true;
        RightLeft = Vector3.left;
    }
    public void MoveRight()
    {
        if (!ismoving)
        {
            MoveSpeed = 1.0f;
            ismoving = true;
            animator.SetTrigger(DoMove);
        }
        this.GetComponent<SpriteRenderer>().flipX = false;
        RightLeft = Vector3.right;
    }
    public void StopAndFlip()
    {
        ismoving = false;
        MoveSpeed = 0.0f;
        this.GetComponent<SpriteRenderer>().flipX = false;
        RightLeft = Vector3.right;
        animator.SetTrigger("doStop");
    }


    protected override void CheckEnemy()
    {
        if(ismoving) {return;}
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position+raycastHeight, RightLeft, AttackRange, LayerMask.GetMask(Enemy));
        //draw the ray in the scene view with distance 
        Debug.DrawRay(transform.position+ raycastHeight, RightLeft * AttackRange, Color.red);
        if (hit.collider != null)
        {
            if (hit.collider.CompareTag(Enemy) && isAttacking == false)
            {
                isAttacking = true;
                if (IsMelee)
                {
                    StartCoroutine(Attack(hit));
                }
            }
        }
    }
    
    public void Skill1()
    {
        this.GetComponent<SpriteRenderer>().flipX = false;
        isSkillMotion = true;
        animator.SetTrigger("doSkill1");
        StartCoroutine(Skill1Motion());
    }
    public void Skill2()
    {
        this.GetComponent<SpriteRenderer>().flipX = false;
        isSkillMotion = true;
        Debug.Log("Skill2");
        animator.SetTrigger("doSkill2");
        StartCoroutine(Skill2Motion());
    }
    
    protected IEnumerator Skill1Motion()
    {
        // check my team is around me
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 2f, LayerMask.GetMask("Team"));
        
        //1hitcollider is this
        if(hitColliders.Length == 0)
        {
            isSkillMotion = false;
            yield break;
        }
        foreach (var hitCollider in hitColliders)
        {
            hitCollider.GetComponent<BaseCharacter>().Buff();
        }
        yield return new WaitForSeconds(1.0f);
        isSkillMotion = false;
    }
    protected IEnumerator Skill2Motion()
    {
        yield return new WaitForSeconds(1.0f);
        Debug.Log("Skill2Fin");
        isSkillMotion = false;
    }


    public override IEnumerator RangedAttack(RaycastHit2D hit)
    {


        yield return new WaitForEndOfFrame();
    }

    protected override void RangedAttackShoot()
    {
            GameObject rangedAttack = Instantiate(rangedAttackPrefab, rangedAttackSpawnPoint.position - new Vector3(0, 0.5f, 0), Quaternion.identity);
            rangedAttack.GetComponent<PlayerRangeSkill>().SkillSetting();
    }

}
