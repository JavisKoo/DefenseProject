using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] GameObject[] characterPrefab;

    [SerializeField] public int CharacterIndex=0;

    [SerializeField] private Tower towerScript;
    [SerializeField] private ItemData[] datas;

    public GameObject warningText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnCharacter()
    {
        if (towerScript.currentGold - datas[CharacterIndex].cost < 0)
        {
            warningText.SetActive(true);
            Invoke("SetFalseWarn", 1f);
        }
        else
        {
            switch (CharacterIndex)
            {
                case 0:
                    towerScript.currentGold -= datas[CharacterIndex].cost;
                    break;
                case 1:
                    towerScript.currentGold -= datas[CharacterIndex].cost;
                    break;
                case 2:
                    towerScript.currentGold -= datas[CharacterIndex].cost;
                    break;
                case 3:
                    towerScript.currentGold -= datas[CharacterIndex].cost;
                    break;

                case 4:
                    Debug.Log("����ֽ��ϴ�.");
                    break;
            }
            //spawn character
            Instantiate(characterPrefab[CharacterIndex], transform.position, Quaternion.identity);
            //UI Init
            towerScript.InitUI();
        }
    }

    public void SetFalseWarn()
    {
        warningText.SetActive(false);
    }
}
