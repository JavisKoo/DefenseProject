using Chracter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] GameObject[] characterPrefab;

    [SerializeField] public int CharacterIndex=0;

    [SerializeField] private Tower towerScript;
    [SerializeField] private ItemData[] datas;





    public void SpawnCharacter() //Item ��Ʈ��Ʈ���� CharacterIndex��, ���������̸� �������ְ�.    =>    �� �Լ� ȣ��
    {
        towerScript.currentGold -= datas[CharacterIndex].cost;
        //spawn character
        GameObject Team = Instantiate(characterPrefab[CharacterIndex], transform.position, Quaternion.identity);
        Debug.Log("ĳ���� �ε����� :"+CharacterIndex);
        Team.GetComponent<BaseCharacter>().Spawn();
        //UI Init
        towerScript.InitUI(); //��� �ؽ�Ʈ �ʱ�ȭ
    }
    

    
}
