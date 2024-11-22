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
        //피격 당했을 때 애니메이션
        HitAnim();

        //데미지 계산
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
