using Chracter;
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
    //public Text[] cardDesc;
    public Text[] cardCost;
    public Card[] cards;
    public Image[] cardMember;
    public Text[] cardDefense;
    public Text[] cardHealth;
    public Text[] cardStrength;
    public Text[] cardAttackSpeed;
    public Image[] cardAttribute;
    public Sprite[] attributeImage;
    public Toggle[] cardToggles;

    //
    [Header("Detail")]
    public GameObject exitPanel;
    public GameObject detailPanel;
    public Image dcardImage;
    public Text dCardLevel;
    public Text dCardName;
    public Text dCardCost;
    public Text dCardMember;
    public Sprite[] memberSprites;
    public Image dCardAttribute;

    public Text dCardDefenseValue;
    public Text dCardHealthValue;
    public Text dCardStrengthValue;
    public Text dCardAttackSpeedValue;
    public Text dCardAttackCountLimitValue;
    public Text dCardSpeedValue;
    public Text dCardAccuracyValue;
    public Text dCardAvoidanceValue;
    public Text dCardUnitSize;
    public Text dCardCreateCountValue;

    //카드정보
    public ItemData[] datas;
    public int selectId;

    //유닛생산버튼
    public Item[] unitButtons;

    //스테이지 정보
    public int wave = 1;

    //스테이지 타임
    public float stageTime = 0;
    private float maxStageTime;
    private float[] stageMaxTime = { 120f, 120f, 240f };
    public GameObject stageTimeObj;
    public Text stageTimeText;
    public Text waveText;
    private bool stage3TimeFlag = false;


    //GameOver
    [Header("GameOver")]
    public GameObject GameOverPanel;
    public UnityEngine.UI.Image fadeimage;
    private bool isGameOver = false;

    //
    public EnemyTower enemyTower;
    public GameObject BossObj;

    //boss
    public bool isAppearBoss = false;

    //dungeon
    public static int dungeon = 1;

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
        stageTime = 120f;
        StageStart();
    }

    private void Update()
    {
        stageTime -= Time.deltaTime;
        CheckStageTime();
    }

    public void StageStart()
    {
        Time.timeScale = 0f;
        MakeCard();
    }

    public void MakeCard()
    {
        int count = System.Enum.GetValues(typeof(ItemType)).Length; //유닛 종류 개수구하기
        List<int> nums = new List<int>();

        for (int i = 0; i < 3; i++)
        {
            int ranNum = Random.Range((wave - 1) * 5, ((wave - 1) * 5) + 5); //스테이지 1이면 0~5, 2이면 5~10, 3이면 10~15
            //Debug.Log("첫번째 값: " + (stage - 1) * 5 + "두번째 값: " + ((stage - 1) * 5) + 5);
            //Debug.Log("랜덤 아이디값" + ranNum);
            //중복체크
            while(nums.Contains(ranNum)) //랜덤넘버가 만약 이미 있다면
            {
                ranNum = Random.Range((wave - 1) * 5, ((wave - 1) * 5) + 5);
            }
            nums.Add(ranNum);

            //UI에 랜덤유닛 정보 집어넣기
            cardLevel[i].text = "LV." + datas[ranNum].level;
            cardType[i].text = datas[ranNum].itemName.ToString();
            cardImage[i].sprite = datas[ranNum].itemIcon;
            //cardDesc[i].text = datas[ranNum].itemDesc.ToString();
            cardCost[i].text = datas[ranNum].cost.ToString();
            switch (datas[ranNum].member)
            {
                case 0:
                    cardMember[i].sprite = memberSprites[datas[ranNum].member];
                    break;
                case 1:
                    cardMember[i].sprite = memberSprites[datas[ranNum].member];
                    break;
                case 2:
                    cardMember[i].sprite = memberSprites[datas[ranNum].member];
                    break;
                case 3:
                    cardMember[i].sprite = memberSprites[datas[ranNum].member];
                    break;
            }
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
            Debug.Log("선택한 카드 아이디: " + selectId);

            if(unitButtons[i] != null)
            {
                Debug.Log("aeswf");
            }
       
            if (unitButtons[i].data==null)
            {
                unitButtons[i].Init(datas[selectId]);

                //Debug.Log("카드적용완료");
                break;
            }
        }


        //cardDelayImage[selectId].sprite = datas[selectId].itemIcon;
        Time.timeScale = 1f;
        cardPanel.SetActive(false);


        //카드 끄기
        detailPanel.SetActive(false);
        exitPanel.SetActive(false);
        selectId = 0;
        for (int i = 0; i < cardToggles.Length; i++)
        {
            cardToggles[i].isOn = false;
        }
        //enemyTower


        //웨이브 설정
        switch (wave)
        {
            case 1:
                stageTime = 120f;
                break;
            case 2:
                stageTime = 120f;
                break;
            case 3:
                stageTime = 240f;
                break;
        }

        maxStageTime = stageTime;
        waveText.text = "WAVE " + wave;
        enemyTower.ReadSpawnFile();
    }

    public void CheckStageTime()
    {
        if (isGameOver)
        {
            stageTime = 0f;
            return;
        }

        //Debug.Log("스테이지 시간 : " + Mathf.Floor(stageTime));
        if (wave == 1)
        {
            //30초 (중반으로 넘어가기)
            if (Mathf.Floor(stageTime) == maxStageTime - 30f)
            {
                enemyTower.spwanDelay1 = 8f;
                enemyTower.spwanDelay2 = 12f;
                enemyTower.spwanDelay3 = 25f;
            }
            //60초 (후반으로 넘어가기)
            if (Mathf.Floor(stageTime) == maxStageTime - 90f)
            {
                enemyTower.spwanDelay1 = 5f;
                enemyTower.spwanDelay2 = 10f;
                enemyTower.spwanDelay3 = 20f;
            }

            if (stageTime <= 10f)
            {
                stageTimeObj.SetActive(true);
                stageTimeText.text = "남은 시간 " + Mathf.Floor(stageTime) + "초!";
            }
        }
        else if (wave == 2)
        {
            //30초 (중반으로 넘어가기)
            if (Mathf.Floor(stageTime) == maxStageTime - 30f)
            {
                enemyTower.spwanDelay1 = 8f;
                enemyTower.spwanDelay2 = 12f;
                enemyTower.spwanDelay3 = 25f;
            }
            //60초 (후반으로 넘어가기)
            if (Mathf.Floor(stageTime) == maxStageTime - 90f)
            {
                enemyTower.spwanDelay1 = 5f;
                enemyTower.spwanDelay2 = 10f;
                enemyTower.spwanDelay3 = 20f;
            }

            if (stageTime <= 10f)
            {
                stageTimeObj.SetActive(true);
                stageTimeText.text = "남은 시간 " + Mathf.Floor(stageTime) + "초!";
            }
        }
        else if (wave == 3)
        {
            //30초 (중반으로 넘어가기)
            if (Mathf.Floor(stageTime) == maxStageTime - 30f)
            {
                enemyTower.spwanDelay1 = 8f;
                enemyTower.spwanDelay2 = 12f;
                enemyTower.spwanDelay3 = 25f;
            }
            //60초 (후반으로 넘어가기)
            if (Mathf.Floor(stageTime) == maxStageTime - 90f)
            {
                enemyTower.spwanDelay1 = 5f;
                enemyTower.spwanDelay2 = 10f;
                enemyTower.spwanDelay3 = 20f;
            }

            if (stageTime <= 120f && !stage3TimeFlag)
            {
                stageTimeObj.SetActive(true);
                stageTimeText.text = "남은 시간 " + stageTime + "초!";
                Invoke("SetFalseTimeText", 3f);
            }
            else if (stageTime <= 10f)
            {
                stageTimeObj.SetActive(true);
                stageTimeText.text = "남은 시간 " + Mathf.Floor(stageTime) + "초!";
            }

            if (!isAppearBoss && stageTime <= 240f - 15f) //보스가 출현한 적이 없다면
            {
                isAppearBoss = true;
                AppearBoss();
            }
        }

        if (stageTime <= 0f && !isGameOver)
        {
            stageTimeText.text = "시간초과...";
            isGameOver = true;
            GameOver();
        }
    }

    public void OnClickDetail()
    {
        exitPanel.SetActive(true);
        detailPanel.SetActive(true);

        dcardImage.sprite = datas[selectId].itemIcon;
        dCardLevel.text = "LV." + datas[selectId].level;
        dCardName.text = datas[selectId].itemName;
        dCardCost.text = datas[selectId].cost.ToString();
        dCardMember.text = datas[selectId].member.ToString();

        if (datas[selectId].Attribute == "물리")
        {
            dCardAttribute.sprite = attributeImage[0];
        }
        else
        {
            dCardAttribute.sprite = attributeImage[1];
        }

        //
        dCardDefenseValue.text = datas[selectId].defenseValue.ToString();
        dCardHealthValue.text = datas[selectId].healthValue.ToString();
        dCardStrengthValue.text = datas[selectId].strengthValue.ToString();
        dCardAttackSpeedValue.text = datas[selectId].attackSpeedValue.ToString(); 
        dCardAttackCountLimitValue.text = datas[selectId].attackCountLimitValue.ToString();
        dCardSpeedValue.text = datas[selectId].speedValue.ToString();
        dCardAccuracyValue.text = datas[selectId].accuracyValue.ToString();
        dCardAvoidanceValue.text = datas[selectId].avoidanceValue.ToString();
        
        switch (datas[selectId].size)
        {
            case 1:
                dCardUnitSize.text = "소형";
                break;
            case 2:
                dCardUnitSize.text = "중형";
                break;
            case 3:
                dCardUnitSize.text = "대형";
                break;
        }
        dCardCreateCountValue.text = datas[selectId].createCountValue.ToString();
    }

    public void OnClickExit()
    {
        exitPanel.SetActive(false);
        detailPanel.SetActive(false);
    }

    public void SetFalseTimeText()
    {
        stage3TimeFlag = true;
        stageTimeObj.SetActive(false);
    }

    public void GameOver()
    {
        GameOverPanel.SetActive(true);
        StartCoroutine(FadeCor());
    }

    IEnumerator FadeCor()
    {
        float fadeCount = 0;
        while (true)
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.02f);
            fadeimage.color = new Color(0, 0, 0, fadeCount);
        }
    }

    public void AppearBoss()
    {
        GameObject boss = GameObject.Instantiate(BossObj,enemyTower.enemySpawnPoint);
        BaseCharacter bossCharacter = boss.GetComponent<BaseCharacter>();
        bossCharacter.Spawn();
        bossCharacter.ChangeBossStats(8,2,0.8f);
    }
}