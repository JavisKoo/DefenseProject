using System;
using System.Collections;
using System.Collections.Generic;
using Chracter;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    private bool _Setting = false;
    private RaycastHit2D Enemy;
    private string EnemyTag;
    private float AttackDammage = 10;
    private float AttackRange = 1;
    private float Accuracy = 60;

    private Vector3 firstSpawn;

    private Vector3 move = new Vector3(1, 0, 0);
    private Vector3 move2 = new Vector3(-1, 0, 0);


    // Start is called before the first frame update
    void Start()
    {
        firstSpawn = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (_Setting)
            FlytoEnemy();
    }

    public void EnemySetting(RaycastHit2D hit, string enemyTag, float attackDammage, float attackRange=2, float accuracy=60)
    {
      
        EnemyTag = enemyTag;
        if (EnemyTag == "Team")
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
        Enemy = hit;
        AttackDammage = attackDammage;
        AttackRange = attackRange;
        Accuracy = accuracy;
        _Setting = true;
    }
    
    
    private void FlytoEnemy()
    {

            if(EnemyTag == "Team")
            {
                if(this.transform.position.x - firstSpawn.x < -AttackRange * 1.2)
                {
                    Destroy(gameObject);
                }
                transform.position = Vector2.MoveTowards(transform.position,transform.position+move2, 0.1f);
            }
            else
            {
                if(this.transform.position.x - firstSpawn.x > AttackRange * 1.2)
                {
                    Destroy(gameObject);
                }
                transform.position = Vector2.MoveTowards(transform.position,transform.position+move, 0.1f);
            }
            
        
    }
    //if hit enemy
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(EnemyTag))
        {
            other.GetComponent<BaseCharacter>().TakeDamage(AttackDammage,Accuracy);
            Destroy(gameObject);
        }
    }
}