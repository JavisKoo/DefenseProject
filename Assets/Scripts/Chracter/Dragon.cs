using UnityEngine;

namespace Chracter
{
    public class Dragon : BaseCharacter
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
        
            SetCharacterSettings(240,80,22,3.3f,AttackRangeRangedLong,false,false,MoveDefault,120,40);
            healthBar.SetHealth(MaxHealth, MaxHealth);
        
        }
    }
}
