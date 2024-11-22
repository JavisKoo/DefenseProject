using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float fullHp = 10f;
    public float currentHp = 10f;
    public bool isGameOver = false;
    //sprite
    public SpriteRenderer renderer;

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        currentHp = fullHp;
    }

    public void GetHit(float damage)
    {
        //�ǰ� ������ �� �ִϸ��̼�
        HitAnim();

        //������ ���
        if (isGameOver)
        {
            currentHp -= damage;

            if (currentHp <= 0f)
            {
                GameOver();
            }
        }
    }

    public void HitAnim()
    {
        renderer.color = Color.red;
        Invoke("InvokeHitAnim", .5f);

    }

    public void ReturnColor()
    {
        renderer.color = Color.white;
    }

    public void GameOver()
    {
        isGameOver = true;
    }
}
