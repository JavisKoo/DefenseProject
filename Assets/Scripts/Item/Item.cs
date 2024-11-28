using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public SpawnPoint spawnPoint;
    //info data
    public ItemData data;
    public int level;

    //UI
    public Image unitImage;
    public Text levelText;
    public Text costText;

    //GameObject
    [SerializeField] private GameObject[] unitObejcts;

    private void Start()
    {
        //유닛 이미지
        Init(data);
    }

    public void Init(ItemData itemData)
    {
        data = itemData;
        unitImage.sprite = data.itemIcon;

        costText.text = data.cost.ToString();
        levelText.text = "Lv." + data.level;
    }

    public void CreateUnit()
    {
        switch (data.itemType)
        {
            case ItemData.ItemType.Warrior:
                spawnPoint.CharacterIndex = 0;
                spawnPoint.SpawnCharacter();
                break;
            case ItemData.ItemType.Wizard:
                spawnPoint.CharacterIndex = 1;
                spawnPoint.SpawnCharacter();
                break;
            case ItemData.ItemType.Archer:
                spawnPoint.CharacterIndex = 2;
                spawnPoint.SpawnCharacter();
                break;
            case ItemData.ItemType.Thief:
                spawnPoint.CharacterIndex = 3;
                spawnPoint.SpawnCharacter();
                break;

            case ItemData.ItemType.Empty:
                Debug.Log("잠겨있습니다.");
                break;
        }
    }
}
