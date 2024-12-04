using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    //���� ������
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
        //���� �̹���
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

        //���� ������ �־��ֱ�
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
        if (spawnDelay > maxSpawnDelay) //������ �ð��� ������ �ʾҴٸ�
            return;

        switch (data.itemType)
        {
            case ItemData.ItemType.Warrior: //�˻� LV1 ~
                spawnPoint.CharacterIndex = 0;
                spawnPoint.SpawnCharacter();
                break;

            case ItemData.ItemType.Thief:   //����
                spawnPoint.CharacterIndex = 1;
                spawnPoint.SpawnCharacter();
                break;

            case ItemData.ItemType.Archer:  //�����ü�
                spawnPoint.CharacterIndex = 2;
                spawnPoint.SpawnCharacter();
                break;

            case ItemData.ItemType.Goblin:  //���
                spawnPoint.CharacterIndex = 3;
                spawnPoint.SpawnCharacter();
                break;

            case ItemData.ItemType.Slime:  //������
                spawnPoint.CharacterIndex = 4;
                spawnPoint.SpawnCharacter();
                break;

            case ItemData.ItemType.Wizard:  //������ LV2 ~
                spawnPoint.CharacterIndex = 5;
                spawnPoint.SpawnCharacter();
                break;

            case ItemData.ItemType.MagicWarrior:  //���˻�
                spawnPoint.CharacterIndex = 6;
                spawnPoint.SpawnCharacter();
                break;

            case ItemData.ItemType.Minotaur:  //�̳�Ÿ��ν�
                spawnPoint.CharacterIndex = 7;
                spawnPoint.SpawnCharacter();
                break;

            case ItemData.ItemType.Centaur:  //��Ÿ��ν�
                spawnPoint.CharacterIndex = 8;
                spawnPoint.SpawnCharacter();
                break;

            case ItemData.ItemType.Golem:  //��
                spawnPoint.CharacterIndex = 9;
                spawnPoint.SpawnCharacter();
                break;

            case ItemData.ItemType.Paladin:  //����� LV3~
                spawnPoint.CharacterIndex = 10;
                spawnPoint.SpawnCharacter();
                break;

            case ItemData.ItemType.DeerWarrior:  //�罿���
                spawnPoint.CharacterIndex = 11;
                spawnPoint.SpawnCharacter();
                break;

            case ItemData.ItemType.WoodGolem:  //��������
                spawnPoint.CharacterIndex = 12;
                spawnPoint.SpawnCharacter();
                break;

            case ItemData.ItemType.Elementalist:  //���ɼ���
                spawnPoint.CharacterIndex = 13;
                spawnPoint.SpawnCharacter();
                break;

            case ItemData.ItemType.Dragon:  //�巹��
                spawnPoint.CharacterIndex = 14;
                spawnPoint.SpawnCharacter();
                break;

            case ItemData.ItemType.Empty:
                Debug.Log("����ֽ��ϴ�.");
                break;
        }

        spawnDelay = 0;
    }
}
