using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : MonoBehaviour
{
    protected ClassType unitType;
    protected int Health=100;
    protected int AttackDammage=10;
    protected int Armor=5;
    protected int AttackSpeed=1;

    protected static readonly int DoMove = Animator.StringToHash("doMove");
    protected static readonly int DoAttack = Animator.StringToHash("doAttack");
    protected bool isAttacking = false;
    protected bool isMoving = false;
    
    
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
