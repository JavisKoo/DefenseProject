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


    SpriteRenderer spriteRenderer; //�÷��̾� flip�ϱ� ���ؼ� ����

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
        if (moveLeft) //�����̵�
        {
            if (transform.position.x <= -3.8f) //�ִ� �����̵� �Ÿ�
            {
                StopMoving();
                return;
            }
            animator.SetTrigger("doMove");
            spriteRenderer.flipX = true;

            //�÷��̾� �̵�
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }
        if (moveRight)
        {
            if (transform.position.x >= 4.5f) //�ִ� �������̵� �Ÿ�
            {
                StopMoving();
                return;
            }
            animator.SetTrigger("doMove");
            spriteRenderer.flipX = false;

            //�÷��̾� �̵�
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

    private IEnumerator Attack() //�̵��Ҷ��� ����
    {
        animator.SetTrigger(DoAttack);
        yield return new WaitForSeconds(0.5f);
        isAttacking = false;
    }
}
