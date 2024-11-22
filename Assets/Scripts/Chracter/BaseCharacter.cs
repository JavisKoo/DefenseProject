using System.Collections;
using UnityEngine;

namespace Chracter
{
    public class BaseCharacter : MonoBehaviour
    {
        protected ClassType UnitType;
        protected int MaxHealth = 100;
        protected int CurrentHealth;
        protected int AttackDammage = 10;
        protected int Armor = 5;
        protected int AttackSpeed = 1;
        protected float AttackRange = 0.5f;
        public Animator animator;
        public float moveSpeed = 1f;
        public HealthBar healthBar;

        protected static readonly int DoMove = Animator.StringToHash("doMove");
        protected static readonly int DoAttack = Animator.StringToHash("doAttack");
        protected static readonly int DoHit = Animator.StringToHash("doHit");
        protected static readonly int DODie = Animator.StringToHash("doDie");

        protected bool isAttacking = false;
        protected bool isMoving = false;



        protected Vector3 RightLeft;
        protected string Enemy;
        protected string Team;
    
        private bool firstHit = false;
        private bool secondHit = false;
    
    

        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            if (Enemy != null)
                CheckAnimatorState();
        }

        private void FixedUpdate()
        {
            if (Enemy != null)
                CheckEnemy();
        }


        public virtual void SetCharacterSettings(int HP = 100, int Attack = 10, int armor = 0, int attackSpeed = 1,
            float attackRange = 0.5f)
        {
            MaxHealth = HP;
            CurrentHealth = MaxHealth;
            AttackDammage = Attack;
            Armor = armor;
            AttackSpeed = attackSpeed;
            AttackRange = attackRange;
        }


        private void CheckEnemy()
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, RightLeft, AttackRange, LayerMask.GetMask(Enemy));
            //draw the ray in the scene view with distance 
            Debug.DrawRay(transform.position, RightLeft * AttackRange, Color.red);
            if (hit.collider != null)
            {
                if (hit.collider.CompareTag(Enemy) && isAttacking == false)
                {
                    isAttacking = true;
                    isMoving = false;
                    StartCoroutine(Attack(hit));
                }
            }
            else if (isAttacking == false && isMoving == false)
            {
                isMoving = true;
                animator.SetTrigger(DoMove);
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



        // virtual method for attack

        protected virtual IEnumerator Attack(RaycastHit2D hit)
        {
            animator.SetTrigger(DoAttack);
            hit.collider.GetComponent<BaseCharacter>().TakeDamage(AttackDammage);
            yield return new WaitForSeconds(0.5f);
            isAttacking = false;
        }


        public void TakeDamage(int damage)
        {
            // int finalDamage = damage - Armor;
            //  if (finalDamage < 0)
            //  {
            //      finalDamage = 0;
            // }
            // CurrentHealth -= finalDamage;
            CurrentHealth -= damage;
            if (healthBar != null)
            {
                healthBar.SetHealth(CurrentHealth, MaxHealth);    
            }

            if (CurrentHealth <= 0)
            {
                Die();
            }
            else if(CurrentHealth <= MaxHealth *0.6f && firstHit == false)
            {
                firstHit = true;
                animator.SetTrigger(DoHit);
            }
            else if(CurrentHealth <= MaxHealth *0.3f && secondHit == false)
            {
                secondHit = true;
                animator.SetTrigger(DoHit);
            }
        }

        private void Die()
        {
            Destroy(gameObject);
        }



        public void CheckTeam()
        {
            if (CompareTag("Enemy"))
            {
                RightLeft = Vector3.left;
                Enemy = "Team";
                Team = "Enemy";
            }
            else
            {
                RightLeft = Vector3.right;
                Enemy = "Enemy";
                Team = "Team";
            }

            animator.SetTrigger(DoMove);
        }
    }
}
