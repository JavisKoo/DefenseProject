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
    private int AttackDammage = 10;
    private float AttackRange = 1;

    private Vector3 firstSpawn;

    private Vector3 move = new Vector3(1, 0, 0);


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

    public void EnemySetting(RaycastHit2D hit, string enemyTag, int attackDammage, float attackRange=2)
    {
        EnemyTag = enemyTag;
        Enemy = hit;
        AttackDammage = attackDammage;
        AttackRange = attackRange;
        _Setting = true;
    }
    
    
    private void FlytoEnemy()
    {
        if (Enemy.collider != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, Enemy.point, 0.1f);
        }
        else if (Enemy.collider == null)
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
            other.GetComponent<BaseCharacter>().TakeDamage(AttackDammage);
            Destroy(gameObject);
        }
    }
}
