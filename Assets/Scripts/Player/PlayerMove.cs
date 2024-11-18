using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : BaseCharacter
{
    //player move
    public float moveSpeed = 2f;
    private bool moveLeft = false;
    private bool moveRight = false;


    SpriteRenderer spriteRenderer; //�÷��̾� flip�ϱ� ���ؼ� ����
    //animation
    public Animator animator;
    //attack
    public LayerMask EnemyLayer; //���̾� ����
    float FindRange = 4f; //����

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
        //���� �׸���
        void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, FindRange);
        }
        var EnemyObj = Physics2D.OverlapCircle(transform.position, FindRange, EnemyLayer);
        print(EnemyObj); //��� ���
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

    private IEnumerator Attack() //�̵��Ҷ��� ����
    {
        animator.SetTrigger(DoAttack);
        yield return new WaitForSeconds(0.5f);
        isAttacking = false;
    }
}
