using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    //스폰 딜레이
    public float maxSpawnDelay;
    private float spawnDelay = 0;
    private bool isCanSpawn = true;

    public SpawnPoint spawnPoint;
    //info data
    public ItemData data;
    public int level;

    //UI
    public Image unitImage;
    public Image delayImage; //delay image
    public Text levelText;
    public Text costText;

    //GameObject
    [SerializeField] private GameObject[] unitObejcts;

    private void Start()
    {
        //유닛 이미지
        Init(data);
    }

    private void Update()
    {
        spawnDelay += Time.deltaTime;
        float time = spawnDelay / maxSpawnDelay;
        delayImage.fillAmount = time;

        if (spawnDelay >= maxSpawnDelay)
        {
            isCanSpawn = true;
        }
    }

    public void Init(ItemData itemData)
    {
        data = itemData;
        unitImage.sprite = data.itemIcon;

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
    }

    public void CreateUnit()
    {
        if (spawnDelay > maxSpawnDelay) //딜레이 시간이 지나지 않았다면
            return;

        switch (data.itemType)
        {
            case ItemData.ItemType.Warrior: //검사 LV1 ~
                spawnPoint.CharacterIndex = 0;
                spawnPoint.SpawnCharacter();
                break;

            case ItemData.ItemType.Thief:   //도적
                spawnPoint.CharacterIndex = 1;
                spawnPoint.SpawnCharacter();
                break;

            case ItemData.ItemType.Archer:  //엘프궁수
                spawnPoint.CharacterIndex = 2;
                spawnPoint.SpawnCharacter();
                break;

            case ItemData.ItemType.Goblin:  //고블린
                spawnPoint.CharacterIndex = 3;
                spawnPoint.SpawnCharacter();
                break;

            case ItemData.ItemType.Slime:  //슬라임
                spawnPoint.CharacterIndex = 4;
                spawnPoint.SpawnCharacter();
                break;

            case ItemData.ItemType.Wizard:  //마법사 LV2 ~
                spawnPoint.CharacterIndex = 5;
                spawnPoint.SpawnCharacter();
                break;

            case ItemData.ItemType.MagicWarrior:  //마검사
                spawnPoint.CharacterIndex = 6;
                spawnPoint.SpawnCharacter();
                break;

            case ItemData.ItemType.Minotaur:  //미노타우로스
                spawnPoint.CharacterIndex = 7;
                spawnPoint.SpawnCharacter();
                break;

            case ItemData.ItemType.Centaur:  //켄타우로스
                spawnPoint.CharacterIndex = 8;
                spawnPoint.SpawnCharacter();
                break;

            case ItemData.ItemType.Golem:  //골렘
                spawnPoint.CharacterIndex = 9;
                spawnPoint.SpawnCharacter();
                break;

            case ItemData.ItemType.Paladin:  //성기사 LV3~
                spawnPoint.CharacterIndex = 10;
                spawnPoint.SpawnCharacter();
                break;

            case ItemData.ItemType.DeerWarrior:  //사슴기사
                spawnPoint.CharacterIndex = 11;
                spawnPoint.SpawnCharacter();
                break;

            case ItemData.ItemType.WoodGolem:  //나무거인
                spawnPoint.CharacterIndex = 12;
                spawnPoint.SpawnCharacter();
                break;

            case ItemData.ItemType.Elementalist:  //정령술사
                spawnPoint.CharacterIndex = 13;
                spawnPoint.SpawnCharacter();
                break;

            case ItemData.ItemType.Dragon:  //드레곤
                spawnPoint.CharacterIndex = 14;
                spawnPoint.SpawnCharacter();
                break;

            case ItemData.ItemType.Empty:
                Debug.Log("잠겨있습니다.");
                break;
        }

        spawnDelay = 0;
    }
}
