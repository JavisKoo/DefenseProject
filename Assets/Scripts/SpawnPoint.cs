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





    public void SpawnCharacter() //Item 스트립트에서 CharacterIndex값, 스폰딜레이를 설정해주고.    =>    이 함수 호출
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
                Debug.Log("잠겨있습니다.");
                break;
        }
        //spawn character
        GameObject Team = Instantiate(characterPrefab[CharacterIndex], transform.position, Quaternion.identity);
        Team.GetComponent<BaseCharacter>().Spawn();
        //UI Init
        towerScript.InitUI(); //골드 텍스트 초기화
    }
    

    
}
