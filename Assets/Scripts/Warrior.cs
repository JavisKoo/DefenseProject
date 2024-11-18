using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : BaseCharacter
{
    public ParticleSystem moveParticle;
    public Animator animator;
    public float moveSpeed = 1f;
    
    ClassType.UnitType unitType = ClassType.UnitType.Warrior;
    
    // Start is called before the first frame update
    void Start()
    {
        if(moveParticle != null)
        {
            moveParticle.Play();
        }
        animator.SetTrigger(DoMove);
    }

    // Update is called once per frame
    void Update()
    {
        CheckAnimatorState();
    }

    private void FixedUpdate()
    {
        CheckEnemy();
    }

    private void CheckEnemy()
    {
        //use physics2d raycast to check if there is an enemy in front of the warrior
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 0.5f);
        if(hit.collider != null)
        {
            if(hit.collider.CompareTag("Enemy")&& isAttacking == false)
            {
                isAttacking = true;
                isMoving = false;
                StartCoroutine( Attack(hit));
            }
        }
        else if(hit.collider == null && isMoving == false)
        {
            isMoving = true;
            animator.SetTrigger(DoMove);
        }
        
    }

    private IEnumerator Attack( RaycastHit2D hit)
    {
        animator.SetTrigger(DoAttack);
        hit.collider.GetComponent<BaseCharacter>().TakeDamage(AttackDammage);
        yield return new WaitForSeconds(0.5f);
        isAttacking = false;
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
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        yield return null;
    }
}
