using System.Collections;
using UnityEngine;

namespace Chracter
{
    public class Wizard : BaseCharacter
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
            SetCharacterSettings(500,30, 10,1, attackRange,true,false);
            healthBar.SetHealth(MaxHealth, MaxHealth);
        }
    }
}
