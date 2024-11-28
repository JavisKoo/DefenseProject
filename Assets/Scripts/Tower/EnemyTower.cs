using Chracter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTower : BaseCharacter
{
    float spwanDelay;
    string spawnType;

    int stage = 1;

    //sprite
    public SpriteRenderer renderer;
    //UI
    [Header("UI")]
    public Slider towerHPSlider;
    public Text towerHPText;

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        SetCharacterSettings(5000);
        towerHPSlider.maxValue = MaxHealth;
    }

    private void Update()
    {
        towerHPSlider.value = CurrentHealth;
        towerHPText.text = CurrentHealth + " / " + MaxHealth;
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
