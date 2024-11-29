using UnityEngine;

namespace Chracter
{
    public class Warrior : BaseCharacter
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
        
            SetCharacterSettings(500,20,0,AttackSpeedDefault,AttackRangeMeleeDefault,true,true,MoveDefault);
            healthBar.SetHealth(MaxHealth, MaxHealth);
        
        }
    }
}
