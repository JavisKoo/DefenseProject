using UnityEngine;

namespace Chracter
{
    public class Golem : BaseCharacter
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
        
            SetCharacterSettings(100,20,0,AttackSpeedDefault,AttackRangeMeleeLong,true,true,MoveDefault);
            healthBar.SetHealth(MaxHealth, MaxHealth);
        
        }
    }
}
