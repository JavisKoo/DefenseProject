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
        
            SetCharacterSettings(100,30,18,3.3f,AttackRangeMeleeLong,true,true,MoveDefault,40,20);
            healthBar.SetHealth(MaxHealth, MaxHealth);
        
        }
    }
}
