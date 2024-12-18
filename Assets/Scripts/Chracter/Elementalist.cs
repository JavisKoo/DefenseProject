using System.Collections;
using UnityEngine;

namespace Chracter
{
    public class Elementalist : BaseCharacter
    {

        public override void Spawn()
        {
            base.Spawn();
            SetCharacterSettings(160, 40, 0, 1.4f, AttackRangeRangedLong, false, false, MoveDefault, 120, 80);
            healthBar.SetHealth(MaxHealth, MaxHealth);
        }
    }
}
