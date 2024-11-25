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
        
            SetCharacterSettings(500,20);
            healthBar.SetHealth(MaxHealth, MaxHealth);
        
        }



    }
}
