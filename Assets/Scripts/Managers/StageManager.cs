using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static ItemData;

public class StageManager : MonoBehaviour
{
    private static StageManager instance = null;

    //카드 UI
    public GameObject cardPanel;
    public Text[] cardType;
    public Image[] cardImage;
    public Text[] cardDesc;
    public Card[] cards;
    //카드정보
    public ItemData[] datas;
    public int selectId;
    //유닛생산버튼
    public Item[] unitButtons;

    void Awake()
    {
        if (null == instance)
        {
            instance = this;

            /*DontDestroyOnLoad(this.gameObject);*/
        }
        else
        {
            /*Destroy(this.gameObject);*/
        }
    }

    public static StageManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    private void Start()
    {
        StageStart();
    }

    public void StageStart()
    {
        Time.timeScale = 0f;
        MakeCard();
    }

    public void MakeCard()
    {
        int count = System.Enum.GetValues(typeof(ItemType)).Length; //유닛 종류 개수구하기

        for (int i = 0; i < 3; i++)
        {
            int ranNum = Random.Range(0, count-3); //고블린 슬라임 제외
            Debug.Log(count);

            //UI에 랜덤유닛 정보 집어넣기
            cardType[i].text = datas[ranNum].itemName.ToString();
            cardImage[i].sprite = datas[ranNum].itemIcon;
            cardDesc[i].text = datas[ranNum].itemDesc.ToString();
            //
            cards[i].cardId = ranNum;
            Debug.Log(i+"번째 카드 아이디: " + ranNum);
        }

        cardPanel.SetActive(true);
    }

    public void SelectCard() //카드선택했을때 타입에 맞는 정보 넣기
    {
        for (int i = 0; i < unitButtons.Length; i++)
        {
            Debug.Log("선택한 카드 아이디: " + selectId);
            if (unitButtons[i].data.itemType == ItemData.ItemType.Empty)
            {
                unitButtons[i].Init(datas[selectId]);

                Debug.Log("카드적용왕ㄴ료");
                break;
            }
        }


        Time.timeScale = 1f;
        cardPanel.SetActive(false);
    }
}
