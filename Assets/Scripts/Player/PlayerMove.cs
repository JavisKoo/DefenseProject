using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : BaseCharacter
{
    //player move
    public float moveSpeed = 2f;
    private bool moveLeft = false;
    private bool moveRight = false;


    SpriteRenderer spriteRenderer; //플레이어 flip하기 위해서 선언
    //animation
    public Animator animator;
    //attack
    public LayerMask EnemyLayer; //레이어 선택
    float FindRange = 4f; //범위

    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // when button is pressed, move camera to the left smoothly
    private void Update()
    {
        Move();
    }

    private void FixedUpdate()
    {
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
        //범위 그리기
        void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, FindRange);
        }
        var EnemyObj = Physics2D.OverlapCircle(transform.position, FindRange, EnemyLayer);
        print(EnemyObj); //결과 출력
        //use physics2d raycast to check if there is an enemy in front of the warrior
        RaycastHit2D hit = Physics2D.Raycast(transform.position,Vector3.left,.5f);
        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Team") && isAttacking == false)
            {
                isAttacking = true;
                StartCoroutine(Attack());
            }
        }
    }

    private IEnumerator Attack() //이동할때도 공격
    {
        animator.SetTrigger(DoAttack);
        yield return new WaitForSeconds(0.5f);
        isAttacking = false;
    }
}
