using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWarrior : BaseCharacter
{
    public ParticleSystem moveParticle;
    public Animator animator;
    public float moveSpeed = 1f;
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
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, 0.5f);
        if(hit.collider != null)
        {
            if(hit.collider.CompareTag("Team")&& isAttacking == false)
            {
                isAttacking = true;
                StartCoroutine( Attack());
            }
        }
        
    }

    private IEnumerator Attack()
    {
        animator.SetTrigger(DoAttack);
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
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        yield return null;

    }
}
