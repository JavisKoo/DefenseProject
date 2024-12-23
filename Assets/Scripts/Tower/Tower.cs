using Chracter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Tower : BaseCharacter
{
    [Header("Tower")]
    public bool isGameOver = false;
    //sprite
    public SpriteRenderer renderer;
    //gold
    [Header("Gold")]
    public float currentGold = 0;
    [SerializeField] private float maxGold = 1000;
    [SerializeField] private int goldPerSec = 1;
    private bool isCanGetGold = true;
    //time
    [Header("Time")]
    [SerializeField] private float currentTime;
    [SerializeField] private float maxTime = .1f;
    //UI
    [Header("UI")]
    public Text goldValueText;
    public Text goldPerSecText;
    //Tower Stats
    [Header("Tower Stats")]
    public int maxHp = 1000;
    public UnityEngine.UI.Slider towerHPSlider;
    public Text towerHPText;
    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        SetCharacterSettings(maxHp);
        goldPerSecText.text = "+" + goldPerSec + "/s";
        goldValueText.text = currentGold + " / " + maxGold;

        healthBar.TowerHealth(maxHp,maxHp);
    }

    private void Update()
    {
        towerHPSlider.value = CurrentHealth;
        towerHPText.text = CurrentHealth + " / " + MaxHealth;
        towerHPSlider.maxValue = maxHp;
        towerHPSlider.value = CurrentHealth;

        currentTime += Time.deltaTime;
        if (currentTime >= maxTime)
        {
            currentTime = 0;
            GetGold();
        }
    }

    public void GetGold()
    {
        currentGold += goldPerSec / 10;
        if (currentGold > maxGold)
        {
            currentGold = maxGold;
            isCanGetGold = false;
        }
        else
        {
            isCanGetGold = true;
        }
        InitUI();
    }

    public void InitUI()
    {
        goldValueText.text = currentGold + " / " + maxGold;
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

    public override void Die()
    {
        isGameOver = true;
        StageManager.Instance.GameOver();
    }

    public override void TakeDamage(float damage, float enemyAccuracy = 200,bool pierce=false)
    {
        if (isGameOver)
            return;


        float finalDamage = damage - Armor;
        if (finalDamage <= 0)
        {
            finalDamage = 1;
        }
        CurrentHealth -= finalDamage;
        if (CurrentHealth < 0) //죽음 처리
        {
            Die();
            CurrentHealth = 0;
        }


        if (healthBar != null)
        {
            healthBar.TowerHealth(CurrentHealth, MaxHealth);
        }
    }

    
}
