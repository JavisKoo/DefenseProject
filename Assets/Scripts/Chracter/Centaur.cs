using UnityEngine;

namespace Chracter
{
    public class Centaur : BaseCharacter
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
        
            SetCharacterSettings(80,20,0,2.0f,AttackRangeMeleeLong,true,true,MoveDefault,60,40);
            healthBar.SetHealth(MaxHealth, MaxHealth);
        
        }
    }
}
