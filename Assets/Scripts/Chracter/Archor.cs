using System.Collections;
using UnityEngine;

namespace Chracter
{
    public class Archor : BaseCharacter
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
            // SetCharacterSetting MaxHealth,Attack,Armor,AttackSpeed,Attackrange,isphysical,israngedattack
            SetCharacterSettings(20,12, 0,2.0f, AttackRangeRangedDefault,true,false,1.5f,200,120);
            healthBar.SetHealth(MaxHealth, MaxHealth);
        }
    }
}
