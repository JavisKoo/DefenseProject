using UnityEngine;

namespace Chracter
{
    public class MagicWarrior : BaseCharacter
    {
        public ParticleSystem moveParticle;
    
        // Start is called before the first frame update
        void Start()
        {
            if(moveParticle != null)
            {
                moveParticle.Play();
            }

            CheckTeam();
        
            SetCharacterSettings(80,20,6,2.0f,AttackRangeMeleeDefault,false,true,MoveDefault,60,60);
            healthBar.SetHealth(MaxHealth, MaxHealth);
        
        }
    }
}
