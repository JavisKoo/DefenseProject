using UnityEngine;

namespace Chracter
{
    public class SkeletonWarrior : BaseCharacter
    {


        [SerializeField] AnimatorOverrideController overrider;
        [SerializeField] Sprite RebornIdle;
        private bool isReborn = false;
    
        // Start is called before the first frame update
        public override void Spawn()
        {
            base.Spawn();
            SetCharacterSettings(20, 60, 0, 1.6f, AttackRangeMeleeLong, true, true, MoveDefault, 120, 40);
            healthBar.SetHealth(MaxHealth, MaxHealth);
        }



        public override void Die()
        {
            if(!isReborn)
            {
                this.GetComponent<BoxCollider2D>().enabled = true;
                isDead = false;
                animator.runtimeAnimatorController = overrider;
                isReborn = true;
                SetCharacterSettings(200, 60, 0, 1.6f, AttackRangeMeleeLong, true, true, MoveDefault, 120, 40);
                healthBar.SetHealth(MaxHealth, MaxHealth);
            }
            else
            {
                StartCoroutine(DieAnim());
            }

        }


    }
}
