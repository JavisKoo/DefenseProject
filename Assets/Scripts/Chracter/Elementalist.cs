using System.Collections;
using UnityEngine;

namespace Chracter
{
    public class Elementalist : BaseCharacter
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
            SetCharacterSettings(160,40, 0,1.4f, AttackRangeRangedLong,false,false,MoveDefault,120,80);
            healthBar.SetHealth(MaxHealth, MaxHealth);
        }
    }
}
