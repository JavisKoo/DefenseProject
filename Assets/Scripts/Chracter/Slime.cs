using UnityEngine;

namespace Chracter
{
    public class Slime : BaseCharacter
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
        
            //20	8	5	60	40	0
            SetCharacterSettings(20,8, 0,2.0f, AttackRangeMeleeDefault,false,true,1f,60,40);
            healthBar.SetHealth(MaxHealth, MaxHealth);
        
        }
    }
}
