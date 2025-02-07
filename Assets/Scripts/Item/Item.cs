using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    //스폰 딜레이
    public float maxSpawnDelay;
    public float spawnDelay = 0;
    private bool isCanSpawn = true;
    private bool isFirstSpawn = true;



    public SpawnPoint spawnPoint;
    //info data
    public ItemData data;
    public int level;
    [SerializeField] private Tower towerScript;

    //UI
    public GameObject lockImageGO;
    public GameObject costTextGO;
    public Image unitImage;
    public Image delayImage; //delay image
    public Text levelText;
    public Text costText;
    public GameObject warningText;

    private int SpawnNum = 1;

    //GameObject
    [SerializeField] private GameObject[] unitObejcts;

    private void Start()
    {
        //유닛 이미지
        Init(data);
    }

    private void Update()
    {
        spawnDelay -= Time.deltaTime;
        float time = spawnDelay / maxSpawnDelay;
        delayImage.fillAmount = time;

        if (spawnDelay <= 0f)
        {
            isCanSpawn = true;
        }
    }

    public void Init(ItemData itemData)
    {
        if (data == null && itemData==null)
        {
            lockImageGO.SetActive(true);
            costTextGO.SetActive(false);
            return;
        }

        data = itemData;
        unitImage.sprite = data.itemIcon;
        lockImageGO.SetActive(false);
        costTextGO.SetActive(true);

        costText.text = data.cost.ToString();
        levelText.text = "Lv." + data.level;

        //스폰 딜레이 넣어주기
        switch (data.level)
        {
            case 1:
                maxSpawnDelay = 4;
                break;
            case 2:
                maxSpawnDelay = 12;
                break;
            case 3:
                maxSpawnDelay = 20;
                break;
        }
        if (isFirstSpawn)
            return;

        isFirstSpawn = false;
        spawnDelay = maxSpawnDelay;
    }

    public void CreateUnit()
    {
        if (data == null)
            return;

        if (spawnDelay > 0f || towerScript.currentGold - data.cost < 0) //딜레이 시간이 지나지 않았다면
        {
            //Warn();

            return;
        }

        switch (data.itemType)
        {
            case ItemData.ItemType.Warrior: //검사 LV1 ~
                spawnPoint.CharacterIndex = 0;   
                spawnPoint.SpawnCharacter(data.createCountValue);
                break;

            case ItemData.ItemType.Thief:   //도적
                spawnPoint.CharacterIndex = 1;
                spawnPoint.SpawnCharacter(data.createCountValue);
                break;

            case ItemData.ItemType.Archer:  //엘프궁수
                spawnPoint.CharacterIndex = 2;
                spawnPoint.SpawnCharacter(data.createCountValue);
                break;

            case ItemData.ItemType.Goblin:  //고블린
                spawnPoint.CharacterIndex = 3;
                spawnPoint.SpawnCharacter(data.createCountValue);
                break;

            case ItemData.ItemType.Slime:  //슬라임
                spawnPoint.CharacterIndex = 4;
                spawnPoint.SpawnCharacter(data.createCountValue);
                break;

            case ItemData.ItemType.SkeletonWarrior:  //해골전사
                spawnPoint.CharacterIndex = 5;
                spawnPoint.SpawnCharacter(data.createCountValue);
                break;

            case ItemData.ItemType.Bat:  //시체박쥐
                spawnPoint.CharacterIndex = 6;
                spawnPoint.SpawnCharacter(data.createCountValue);
                break;

            case ItemData.ItemType.Wizard:  //마법사 LV2 ~
                spawnPoint.CharacterIndex = 7;
                spawnPoint.SpawnCharacter(data.createCountValue);
                break;

            case ItemData.ItemType.MagicWarrior:  //마검사
                spawnPoint.CharacterIndex = 8;
                spawnPoint.SpawnCharacter(data.createCountValue);
                break;

            case ItemData.ItemType.Minotaur:  //미노타우로스
                spawnPoint.CharacterIndex = 9;
                spawnPoint.SpawnCharacter(data.createCountValue);
                break;

            case ItemData.ItemType.Centaur:  //켄타우로스
                spawnPoint.CharacterIndex = 10;
                spawnPoint.SpawnCharacter(data.createCountValue);
                break;

            case ItemData.ItemType.Golem:  //골렘
                spawnPoint.CharacterIndex = 11;
                spawnPoint.SpawnCharacter(data.createCountValue);
                break;

            case ItemData.ItemType.FireSkull:  //불타는해골
                spawnPoint.CharacterIndex = 12;
                spawnPoint.SpawnCharacter(data.createCountValue);
                break;

            case ItemData.ItemType.Paladin:  //성기사 LV3~
                spawnPoint.CharacterIndex = 13;
                spawnPoint.SpawnCharacter(data.createCountValue);
                break;

            case ItemData.ItemType.DeerWarrior:  //사슴기사
                spawnPoint.CharacterIndex = 14;
                spawnPoint.SpawnCharacter(data.createCountValue);
                break;

            case ItemData.ItemType.WoodGolem:  //나무거인
                spawnPoint.CharacterIndex = 15;
                spawnPoint.SpawnCharacter(data.createCountValue);
                break;

            case ItemData.ItemType.Elementalist:  //정령술사
                spawnPoint.CharacterIndex = 16;
                spawnPoint.SpawnCharacter(data.createCountValue);
                break;

            case ItemData.ItemType.Dragon:  //수확자
                spawnPoint.CharacterIndex = 17;
                spawnPoint.SpawnCharacter(data.createCountValue);
                break;

            case ItemData.ItemType.Reaper:  //드레곤
                spawnPoint.CharacterIndex = 18;
                spawnPoint.SpawnCharacter(data.createCountValue);
                break;
        }

        spawnDelay = maxSpawnDelay;
    }
    /*public void Warn()
    {
        warningText.SetActive(true);
        Invoke("SetFalseWarn", 1f);
    }

    public void SetFalseWarn()
    {
        warningText.SetActive(false);
    }*/
}
