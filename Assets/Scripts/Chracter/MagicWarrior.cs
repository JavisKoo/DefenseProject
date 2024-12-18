using UnityEngine;

namespace Chracter
{
    public class MagicWarrior : BaseCharacter
    {

        public override void Spawn()
        {
            base.Spawn();
            SetCharacterSettings(80, 20, 6, 2.0f, AttackRangeMeleeDefault, false, true, MoveDefault, 60, 60);
            healthBar.SetHealth(MaxHealth, MaxHealth);
        }
    }
}
