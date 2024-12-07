using UnityEngine;

namespace Chracter
{
    public class DeerWarrior : BaseCharacter
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
        
            SetCharacterSettings(200,60,0,1.6f,AttackRangeMeleeLong,true,true,MoveDefault,120,40);
            healthBar.SetHealth(MaxHealth, MaxHealth);
        
        }
    }
}
