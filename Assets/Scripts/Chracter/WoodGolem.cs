using UnityEngine;

namespace Chracter
{
    public class WoodGolem : BaseCharacter
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
        
            SetCharacterSettings(240,80,22,3.3f,AttackRangeMeleeDefault,true,true,MoveDefault,60,20);
            healthBar.SetHealth(MaxHealth, MaxHealth);
        
        }
    }
}
