using System.Collections;
using UnityEngine;

namespace Chracter
{
    public class Thief : BaseCharacter
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
            SetCharacterSettings(30,10, 0,1.4f, AttackRangeRangedDefault,true,false,1.5f,60,80);
            healthBar.SetHealth(MaxHealth, MaxHealth);
        }
    }
}
