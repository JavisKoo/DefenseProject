using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static ItemData;

public class StageManager : MonoBehaviour
{
    private static StageManager instance = null;

    //ī�� UI
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

    //ī������
    public ItemData[] datas;
    public int selectId;

    //���ֻ����ư
    public Item[] unitButtons;

    //�������� ����
    public int stage = 1;

    //�������� Ÿ��
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
        int count = System.Enum.GetValues(typeof(ItemType)).Length; //���� ���� �������ϱ�

        int beforeNum;
        List<int> nums = new List<int>();

        for (int i = 0; i < 3; i++)
        {
            int ranNum = Random.Range((stage - 1) * 5, ((stage - 1) * 5) + 5); //�������� 1�̸� 0~5, 2�̸� 5~10, 3�̸� 10~15
            //Debug.Log("ù��° ��: " + (stage - 1) * 5 + "�ι�° ��: " + ((stage - 1) * 5) + 5);
            //Debug.Log("���� ���̵�" + ranNum);
            //�ߺ�üũ
            while(nums.Contains(ranNum)) //�����ѹ��� ���� �̹� �ִٸ�
            {
                ranNum = Random.Range((stage - 1) * 5, ((stage - 1) * 5) + 5);
            }
            nums.Add(ranNum);



            //UI�� �������� ���� ����ֱ�
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

            if (datas[ranNum].Attribute == "����")
            {
                cardAttribute[i].sprite = attributeImage[0];
            }
            else
            {
                cardAttribute[i].sprite = attributeImage[1];
            }
            //
            cards[i].cardId = ranNum;
            //Debug.Log(i+"��° ī�� ���̵�: " + ranNum);

            
        }

        cardPanel.SetActive(true);
    }

    public void SelectCard() //ī�弱�������� Ÿ�Կ� �´� ���� �ֱ�
    {
        for (int i = 0; i < unitButtons.Length; i++)
        {
            //Debug.Log("������ ī�� ���̵�: " + selectId);

            if(unitButtons[i] != null)
            {
                Debug.Log("aeswf");
            }
       
            if (unitButtons[i].data==null)
            {
                unitButtons[i].Init(datas[selectId]); //�����ؾ���

                //Debug.Log("ī������Ϸ�");
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
                stageTimeText.text = "���� �ð� " + stageTime + "��!";
            }
        }
        else if (stage == 2)
        {
            if (stageTime <= stageMaxTime[stage] - 10f)
            {
                stageTimeText.text = "���� �ð� " + stageTime + "��!";
            }
        }
        else if (stage == 3)
        {
            if (stageTime <= stageMaxTime[stage] - 10f)
            {
                stageTimeText.text = "���� �ð� " + stageTime + "��!";
            }
        }
    }
}