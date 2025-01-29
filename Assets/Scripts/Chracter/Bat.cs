using UnityEngine;

namespace Chracter
{
    public class Bat : BaseCharacter
    {
        public override void Spawn()
        {
            base.Spawn();
            SetCharacterSettings(200, 60, 0, 1.6f, AttackRangeMeleeLong, true, true, MoveDefault, 120, 40);
            healthBar.SetHealth(MaxHealth, MaxHealth);
        }


        public override void TakeDamage(float damage, float enemyAccuracy = 60, bool pierce = false, string weak="없음")
        {
            float HitPercent = enemyAccuracy - Avoid*2 + 50;
            if (HitPercent >= 100)
            {
                HitPercent = 100;
            }
            else if (HitPercent <= 5)
            {
                HitPercent = 5;
            }
            int HitCalculate = UnityEngine.Random.Range(0, 100);
            if (HitCalculate > HitPercent)
            {
                return;
            }
            if (pierce)
            {
                float finalDamage = damage;
                if (finalDamage <= 0)
                {
                    finalDamage = 1;
                }
                CurrentHealth -= finalDamage;
                if (healthBar != null)
                {
                    healthBar.SetHealth(CurrentHealth, MaxHealth);
                }

            }
            else
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
            }

            if (CurrentHealth <= 0)
            {
                this.GetComponent<BoxCollider2D>().enabled = false;
                isDead = true;
                Die();
            }
            else if (CurrentHealth <= MaxHealth * 0.6f && firstHit == false)
            {
                firstHit = true;
                Hit();
            }
            else if (CurrentHealth <= MaxHealth * 0.3f && secondHit == false)
            {
                secondHit = true;
                Hit();
            }
        }


        protected override void CheckEnemy()
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position + raycastHeight, RightLeft, AttackRange, LayerMask.GetMask(Enemy));
            //draw the ray in the scene view with distance 
            Debug.DrawRay(transform.position + raycastHeight, RightLeft * AttackRange, Color.red);
            if (hit.collider != null)
            {
                if (hit.collider.CompareTag(Enemy) && isAttacking == false)
                {
                    BaseCharacter enemy = hit.collider.GetComponent<BaseCharacter>();
                    float maxHealth = enemy.MaxHealth;
                    float currentHealth = enemy.CurrentHealth;
                    isAttacking = true;
                    IsMoving = false;
                    if (IsMelee)
                    {
                        StartCoroutine(Attack(hit));
                        BatDebuff();
                    }
                    else
                    {
                        StartCoroutine(RangedAttack(hit));
                    }

                }
            }
            else if (isAttacking == false && IsMoving == false)
            {

                IsMoving = true;
                animator.SetTrigger(DoMove);
            }

        }


    }
}
