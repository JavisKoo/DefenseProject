using UnityEngine;

namespace Chracter
{
    public class Goblin : BaseCharacter
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
        
            SetCharacterSettings(30,8, 0,2.0f, AttackRangeMeleeDefault,true,true,1f,40,60);
            healthBar.SetHealth(MaxHealth, MaxHealth);
        
        }



    }
}
