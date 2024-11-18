using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : BaseCharacter
{
    public ParticleSystem moveParticle;

    
    ClassType.UnitType unitType = ClassType.UnitType.Warrior;
    
    // Start is called before the first frame update
    void Start()
    {
        if(moveParticle != null)
        {
            moveParticle.Play();
        }

        CheckTeam();

        SetCharacterSettings(500,20);
    }
}
