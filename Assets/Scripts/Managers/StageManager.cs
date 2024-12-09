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
    public Text[] cardType;
    public Image[] cardImage;
    public Text[] cardDesc;
    public Card[] cards;
    //ī������
    public ItemData[] datas;
    public int selectId;
    //���ֻ����ư
    public Item[] unitButtons;
    //�������� ����
    public int stage = 0;

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
        stage++;
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
            Debug.Log("Stage : " + stage);
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
            cardType[i].text = datas[ranNum].itemName.ToString();
            cardImage[i].sprite = datas[ranNum].itemIcon;
            cardDesc[i].text = datas[ranNum].itemDesc.ToString();
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
    }
}
