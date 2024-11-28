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
    public int currentGold = 0;
    [SerializeField] private int maxGold = 1000;
    [SerializeField] private int goldPerSec = 1;
    private bool isCanGetGold = true;
    //time
    [Header("Time")]
    [SerializeField] private float currentTime;
    [SerializeField] private float maxTime = 1f;
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


        SetCharacterSettings(maxHp);
    }

    private void Update()
    {
        towerHPSlider.value = CurrentHealth;
        towerHPText.text = CurrentHealth + " / " + MaxHealth;
        towerHPSlider.maxValue = maxHp;
        towerHPSlider.value = CurrentHealth;

        //°ñµåÈ¹µæ
        if (!isCanGetGold)
            return;

        currentTime += Time.deltaTime;
        if (currentTime >= maxTime)
        {
            currentTime = 0;
            GetGold();
        }
    }

    public void GetGold()
    {
        currentGold += goldPerSec;
        if (currentGold > maxGold)
        {
            isCanGetGold = false;
            return;
        }
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
        GameOver();
    }

    public void GameOver()
    {
        isGameOver = true;
    }
}
