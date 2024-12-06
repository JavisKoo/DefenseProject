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
        
            SetCharacterSettings(100,10,2,0.5f,AttackRangeMeleeDefault,true,true,MoveDefault,60,40);
            healthBar.SetHealth(MaxHealth, MaxHealth);
        
        }
    }
}
