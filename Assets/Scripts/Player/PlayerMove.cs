using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class PlayerMove : BaseCharacter
{
    //player move
    public float moveSpeed = 2f;
    private bool moveLeft = false;
    private bool moveRight = false;


    SpriteRenderer spriteRenderer; //플레이어 flip하기 위해서 선언

    //attack
    [SerializeField] GameObject player;
    [SerializeField] LayerMask layer;
    [SerializeField] float radius;
    [SerializeField] Collider2D[] col;
    [SerializeField] Transform target;
    [SerializeField] float playerAttackRange = 2f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // when button is pressed, move camera to the left smoothly
    private void Update()
    {
        Move();
        CheckEnemy();
    }

    public void MoveLeft()
    {
        moveLeft = true;
    }
    public void MoveRight()
    {
        moveRight = true;
    }
    public void StopMoving()
    {
        moveLeft = false;
        moveRight = false;
    }

    public void Move()
    {
        if (moveLeft) //왼쪽이동
        {
            if (transform.position.x <= -3.8f) //최대 왼쪽이동 거리
            {
                StopMoving();
                return;
            }
            animator.SetTrigger("doMove");
            spriteRenderer.flipX = true;

            //플레이어 이동
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }
        if (moveRight)
        {
            if (transform.position.x >= 4.5f) //최대 오른쪽이동 거리
            {
                StopMoving();
                return;
            }
            animator.SetTrigger("doMove");
            spriteRenderer.flipX = false;

            //플레이어 이동
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
    }

    private void CheckEnemy()
    {
        col = Physics2D.OverlapCircleAll(player.transform.position, radius, layer);

        Transform nearEnemy = null;

        if (col.Length>0)
        {
            float nearDistance = Mathf.Infinity;

            foreach (Collider2D nCol in col)
            {
                float playerToEnemy = Vector3.SqrMagnitude(player.transform.position - nCol.transform.position);

                if (nearDistance > playerToEnemy)
                {
                    nearDistance = playerToEnemy;
                    nearEnemy = nCol.transform;
                }
            }

            target = nearEnemy;
            //attack
            if (nearDistance < playerAttackRange && isAttacking == false)
            {
                isAttacking = true;
                StartCoroutine(Attack());
                //rotate
                CheckEnemyRotate();
            }
        }
        

        
    }

    private void CheckEnemyRotate()
    {
        if(target == null || target.position.x >= player.transform.position.x)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
    }

    private IEnumerator Attack() //이동할때도 공격
    {
        animator.SetTrigger(DoAttack);
        yield return new WaitForSeconds(0.5f);
        isAttacking = false;
    }
}
