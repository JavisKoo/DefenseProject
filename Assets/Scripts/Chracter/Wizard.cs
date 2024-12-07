using System.Collections;
using UnityEngine;

namespace Chracter
{
    public class Wizard : BaseCharacter
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
            SetCharacterSettings(80,30,0,2.5f,AttackRangeRangedLong,false,false,MoveDefault,60,60);
            healthBar.SetHealth(MaxHealth, MaxHealth);
        }
    }
}
