using Chracter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : BaseCharacter
{
    public bool isGameOver = false;
    //sprite
    public SpriteRenderer renderer;
    //gold
    [SerializeField] private int currentGold = 0;
    [SerializeField] private int maxGold = 1000;
    [SerializeField] private int goldPerSec = 1;
    private bool isCanGetGold = true;
    //time
    [SerializeField] private float currentTime;
    [SerializeField] private float maxTime = 5f;
    //UI
    [Header("UI")]
    public Text goldValueText;
    public Text goldPerSecText;
    //Ä«µå UI
    public GameObject CardUI;

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        SetCharacterSettings(5000);
        goldPerSecText.text = "+" + goldPerSec + "/s";
        goldValueText.text = currentGold + " / " + maxGold;
    }

    private void Update()
    {
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

    public void StageStat()
    {
        ChooseCard();
    }

    public void ChooseCard()
    {
        CardUI.SetActive(true);
    }

    public void OnClickCard()
    {

    }
}
