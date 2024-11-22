using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTower : MonoBehaviour
{
    float spwanDelay;
    string spawnType;

    int stage = 1;

    private void Start()
    {
        //StageStart();
    }

    public void StageStart()
    {
        stage++;
        if (stage >= 3)
        {
            //던전 클리어
        }
    }

    public void StageEnd()
    {

    }
}
