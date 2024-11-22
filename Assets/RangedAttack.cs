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
    
    // Start is called before the first frame update
    void Start()
    {
        
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

    public void EnemySetting(RaycastHit2D hit, string enemyTag, int attackDammage)
    {
        EnemyTag = enemyTag;
        Enemy = hit;
        AttackDammage = attackDammage;
        _Setting = true;
    }
    
    
    private void FlytoEnemy()
    {
        if (Enemy.collider != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, Enemy.point, 0.1f);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    //if hit enemy
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("hit");
        if (other.CompareTag(EnemyTag))
        {
            other.GetComponent<BaseCharacter>().TakeDamage(AttackDammage);
            Destroy(gameObject);
        }
    }
}
