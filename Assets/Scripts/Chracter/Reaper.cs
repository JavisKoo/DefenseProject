using UnityEngine;

namespace Chracter
{
    public class Reaper : BaseCharacter
    {
        public override void Spawn()
        {
            base.Spawn();
            SetCharacterSettings(200, 60, 0, 1.6f, AttackRangeMeleeLong, true, true, MoveDefault, 120, 40);
            healthBar.SetHealth(MaxHealth, MaxHealth);
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
                        if (currentHealth <= maxHealth / 3)
                        {
                            enemy.Die();
                        }
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
