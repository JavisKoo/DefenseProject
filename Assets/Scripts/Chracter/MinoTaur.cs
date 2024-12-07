using UnityEngine;

namespace Chracter
{
    public class MinoTaur : BaseCharacter
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
        
            SetCharacterSettings(100,30,6,2.5f,AttackRangeMeleeLong,true,true,MoveDefault,60,20);
            healthBar.SetHealth(MaxHealth, MaxHealth);
        
        }
    }
}
