using System.Collections;
using UnityEngine;

namespace Chracter
{
    public class Thief : BaseCharacter
    {
        public ParticleSystem moveParticle;
    
        [SerializeField] GameObject rangedAttackPrefab;
        [SerializeField] Transform rangedAttackSpawnPoint;
    
    
        // Start is called before the first frame update
        void Start()
        {
            if(moveParticle != null)
            {
                moveParticle.Play();
            }

            CheckTeam();
            SetCharacterSettings(500,20, 10,1,2);
            healthBar.SetHealth(MaxHealth, MaxHealth);
        }
    
    
        //attack
        protected override IEnumerator Attack(RaycastHit2D hit)
        {
            Debug.Log("Ranged Attack");
            animator.SetTrigger(DoAttack);
            //spawn rangeAttack
            GameObject rangedAttack = Instantiate(rangedAttackPrefab, rangedAttackSpawnPoint.position, Quaternion.identity);
            rangedAttack.GetComponent<RangedAttack>().EnemySetting(hit, Enemy, AttackDammage);
            yield return new WaitForSeconds(0.5f);
            isAttacking = false;
        }
    }
}
