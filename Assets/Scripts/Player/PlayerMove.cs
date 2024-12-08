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
    private void Start()
    {
        SetPlayer();
        CheckTeam();
        SetCharacterSettings(50000,10, 0,1.4f, 3f,true,true,1.5f,200,120);
        healthBar.SetHealth(MaxHealth, MaxHealth);
    }
    
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            Skill1();
        }
        if(Input.GetKey(KeyCode.S))
        {
            Skill2();
        }
        
        if (isSkillMotion)
        {
            return;
        }
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (!ismoving)
            {
                ismoving = true;
                animator.SetTrigger(DoMove);
            }
            this.GetComponent<SpriteRenderer>().flipX = false;
            RightLeft=Vector3.right;
            StartCoroutine(Move());
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (!ismoving)
            {
                ismoving = true;
                animator.SetTrigger(DoMove);
            }
            this.GetComponent<SpriteRenderer>().flipX = true;
            RightLeft=Vector3.left;
            StartCoroutine(Move());
        }
        else if(!isAttacking)
        {
            ismoving = false;
            animator.SetTrigger("doStop");
        }
        
        
    }
    private IEnumerator Move()
    {
        transform.position += MoveSpeed * Time.deltaTime * RightLeft;
        yield return null;
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
        isSkillMotion = true;
        animator.SetTrigger("doSkill1");
        StartCoroutine(SkillMotion());
    }
    public void Skill2()
    {
        isSkillMotion = true;
        animator.SetTrigger("doSkill2");
        StartCoroutine(SkillMotion());
    }
    
    protected IEnumerator SkillMotion()
    {
        yield return new WaitForSeconds(1.0f);
        isSkillMotion = false;
    }

}
