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

    

    

    public void SpawnCharacter() //Item ��Ʈ��Ʈ���� CharacterIndex��, ���������̸� �������ְ�.    =>    �� �Լ� ȣ��
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
            towerScript.InitUI(); //��� �ؽ�Ʈ �ʱ�ȭ
        }
    }

    public void SetFalseWarn()
    {
        warningText.SetActive(false);
    }
}
