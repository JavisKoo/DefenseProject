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
    public Text[] cardLevel;
    public Text[] cardType;
    public Image[] cardImage;
    public Text[] cardDesc;
    public Text[] cardCost;
    public Card[] cards;
    public Text[] cardMember;
    public Text[] cardDefense;
    public Text[] cardHealth;
    public Text[] cardStrength;
    public Text[] cardAttackSpeed;
    public Image[] cardAttribute;
    public Sprite[] attributeImage;

    //카드정보
    public ItemData[] datas;
    public int selectId;

    //유닛생산버튼
    public Item[] unitButtons;

    //스테이지 정보
    public int stage = 1;

    //스테이지 타임
    public float stageTime = 0;
    public float[] stageMaxTime = { 120f, 120f, 240f };
    public Text stageTimeText;

    //
    public EnemyTower enemyTower;

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

    private void Update()
    {
        stageTime -= Time.deltaTime;
    }

    public void StageStart()
    {
        Time.timeScale = 0f;
        MakeCard();

    }

    public void MakeCard()
    {
        int count = System.Enum.GetValues(typeof(ItemType)).Length; //유닛 종류 개수구하기

        int beforeNum;
        List<int> nums = new List<int>();

        for (int i = 0; i < 3; i++)
        {
            int ranNum = Random.Range((stage - 1) * 5, ((stage - 1) * 5) + 5); //스테이지 1이면 0~5, 2이면 5~10, 3이면 10~15
            //Debug.Log("첫번째 값: " + (stage - 1) * 5 + "두번째 값: " + ((stage - 1) * 5) + 5);
            //Debug.Log("랜덤 아이디값" + ranNum);
            //중복체크
            while(nums.Contains(ranNum)) //랜덤넘버가 만약 이미 있다면
            {
                ranNum = Random.Range((stage - 1) * 5, ((stage - 1) * 5) + 5);
            }
            nums.Add(ranNum);



            //UI에 랜덤유닛 정보 집어넣기
            cardLevel[i].text = "LV." + datas[ranNum].level;
            cardType[i].text = datas[ranNum].itemName.ToString();
            cardImage[i].sprite = datas[ranNum].itemIcon;
            cardDesc[i].text = datas[ranNum].itemDesc.ToString();
            cardCost[i].text = datas[ranNum].cost.ToString();
            cardMember[i].text = datas[ranNum].member.ToString();

            cardDefense[i].text = datas[ranNum].Defense.ToString();

            cardHealth[i].text = datas[ranNum].Health.ToString();

            cardStrength[i].text = datas[ranNum].Strength.ToString();

            cardAttackSpeed[i].text = datas[ranNum].AttackSpeed.ToString();

            if (datas[ranNum].Attribute == "물리")
            {
                cardAttribute[i].sprite = attributeImage[0];
            }
            else
            {
                cardAttribute[i].sprite = attributeImage[1];
            }
            //
            cards[i].cardId = ranNum;
            //Debug.Log(i+"번째 카드 아이디: " + ranNum);

            
        }

        cardPanel.SetActive(true);
    }

    public void SelectCard() //카드선택했을때 타입에 맞는 정보 넣기
    {
        for (int i = 0; i < unitButtons.Length; i++)
        {
            //Debug.Log("선택한 카드 아이디: " + selectId);

            if(unitButtons[i] != null)
            {
                Debug.Log("aeswf");
            }
       
            if (unitButtons[i].data==null)
            {
                unitButtons[i].Init(datas[selectId]); //수정해야함

                //Debug.Log("카드적용완료");
                break;
            }
        }


        //cardDelayImage[selectId].sprite = datas[selectId].itemIcon;
        Time.timeScale = 1f;
        cardPanel.SetActive(false);

        //enemyTower
    }

    public void CheckStageTime()
    {
        if (stage == 1)
        {
            if (stageTime <= stageMaxTime[stage] - 10f)
            {
                stageTimeText.text = "남은 시간 " + stageTime + "초!";
            }
        }
        else if (stage == 2)
        {
            if (stageTime <= stageMaxTime[stage] - 10f)
            {
                stageTimeText.text = "남은 시간 " + stageTime + "초!";
            }
        }
        else if (stage == 3)
        {
            if (stageTime <= stageMaxTime[stage] - 10f)
            {
                stageTimeText.text = "남은 시간 " + stageTime + "초!";
            }
        }
    }
}