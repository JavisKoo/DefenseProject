using System;
using System.Collections;
using UnityEngine;

namespace Chracter
{
    public class BaseCharacter : MonoBehaviour
    {
        protected ClassType UnitType;
        protected float MaxHealth = 100;
        protected float CurrentHealth;
        protected float AttackDammage = 10;
        protected float Armor = 0;
        protected float AttackSpeed = 1;
        protected float AttackRange = 0.5f;
        protected bool IsPhysical = true;
        protected bool IsMelee = true;
        protected int UnitCost;
        public Animator animator;
        protected float MoveSpeed = 1f;

        public HealthBar healthBar;
        [SerializeField] GameObject rangedAttackPrefab=null;
        [SerializeField] Transform rangedAttackSpawnPoint=null;


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
        private bool isDead = false;
        private RaycastHit2D currentEnemy;
        

        //CharacterSpeed
        protected static readonly float MoveLow = 0.7f;
        protected static readonly float MoveDefault = 1.0f;
        protected static readonly float MoveFast = 1.2f;

        //CharacterAttackRange Melee
        protected static readonly float AttackRangeMeleeSmall=0.3f;
        protected static readonly float AttackRangeMeleeDefault=0.5f;
        protected static readonly float AttackRangeMeleeLong=1.0f;

        //CharacterAttackRange Ranged
        protected static readonly float AttackRangeRangeSmall=1.5f;
        protected static readonly float AttackRangeRangedDefault=2.0f;
        protected static readonly float AttackRangeRangedLong=3.0f;

        //ChcaracterAttackSpeed
        protected static readonly float AttackSpeedLow=0.7f;
        protected static readonly float AttackSpeedDefault=1.0f;
        protected static readonly float AttackSpeedFast=1.2f;




        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            if (Enemy != null&& !isDead)
                CheckAnimatorState();
        }

        private void FixedUpdate()
        {
            if (Enemy != null&& !isDead)
                CheckEnemy();
        }


        public virtual void SetCharacterSettings(float HP = 100, float Attack = 10, float armor = 0, float attackSpeed = 1,
            float attackRange = 0.5f,bool isPhysical=true, bool isMelle=true, float moveSpeed=1.0f)
        {
            MaxHealth = HP;
            CurrentHealth = MaxHealth;
            AttackDammage = Attack;
            Armor = armor;
            AttackSpeed = attackSpeed;
            AttackRange = attackRange;
            IsPhysical = isPhysical;
            IsMelee = isMelle;
            MoveSpeed = moveSpeed;

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
                    if (IsMelee)
                    {
                        StartCoroutine(Attack(hit));
                    }
                    else
                    {
                        StartCoroutine(RangedAttack(hit));
                    }
                   
                }
            }
            else if (isAttacking == false && isMoving == false)
            {
               animator.speed = MoveSpeed;
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
            transform.position += MoveSpeed * Time.deltaTime * RightLeft;
            yield return null;
        }



        // virtual method for attack

        protected virtual IEnumerator Attack(RaycastHit2D hit)
        {
            currentEnemy = hit;
            animator.SetTrigger(DoAttack);
            animator.speed = AttackSpeed;
            yield return new WaitForSeconds(1 / AttackSpeed);
            isAttacking = false;
        }
        private void AttackHIt()
        {
            if (currentEnemy)
            {
                currentEnemy.collider.GetComponent<BaseCharacter>().TakeDamage(AttackDammage);
            }
        }

        public virtual IEnumerator RangedAttack(RaycastHit2D hit)
        {
            animator.SetTrigger(DoAttack);
            currentEnemy = hit;
            animator.speed = AttackSpeed;
            yield return new WaitForSeconds(1/AttackSpeed);
            isAttacking = false;
        }

        private void RangedAttackShoot()
        {
            if(currentEnemy)
            {
                GameObject rangedAttack = Instantiate(rangedAttackPrefab, rangedAttackSpawnPoint.position, Quaternion.identity);
                rangedAttack.GetComponent<RangedAttack>().EnemySetting(currentEnemy, Enemy, AttackDammage, AttackRange);
            }

        }



        public void TakeDamage(float damage)
        {
             float finalDamage = damage - Armor;
              if (finalDamage <= 0)
              {
                  finalDamage = 1;
             }
            CurrentHealth -= finalDamage;
            if (healthBar != null)
            {
                healthBar.SetHealth(CurrentHealth, MaxHealth);    
            }

            if (CurrentHealth <= 0)
            {
                this.GetComponent<BoxCollider2D>().enabled = false;
                isDead = true;
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

        public virtual void Die()
        {
            StartCoroutine(DieAnim());
        }

        private IEnumerator DieAnim()
        {
            animator.SetTrigger(DODie);
            yield return new WaitForSeconds(1.0f);
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
