using UnityEngine;

namespace Chracter
{
    public class Paladin : BaseCharacter
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
        
            SetCharacterSettings(240,60,14,2.5f,AttackRangeMeleeDefault,false,true,MoveDefault,120,40);
            healthBar.SetHealth(MaxHealth, MaxHealth);
        
        }
    }
}
