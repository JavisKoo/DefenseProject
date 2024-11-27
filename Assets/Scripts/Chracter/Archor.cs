using System.Collections;
using UnityEngine;

namespace Chracter
{
    public class Archor : BaseCharacter
    {
        public ParticleSystem moveParticle;
   

        private int attackRange=5;
    
        // Start is called before the first frame update
        void Start()
        {
            if(moveParticle != null)
            {
                moveParticle.Play();
            }

            CheckTeam();
            // SetCharacterSetting MaxHealth,Attack,Armor,AttackSpeed,Attackrange,isphysical,israngedattack
            SetCharacterSettings(500,30, 10,1, attackRange,true,false,2);
            healthBar.SetHealth(MaxHealth, MaxHealth);
        }
    }
}
