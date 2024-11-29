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
        
            SetCharacterSettings(300,20,0,AttackSpeedDefault,AttackRangeMeleeLong,true,true,MoveDefault);
            healthBar.SetHealth(MaxHealth, MaxHealth);
        
        }
    }
}
