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
        int count = System.Enum.GetValues(typeof(ItemType)).Length; //���� ���� �������ϱ�

        for (int i = 0; i < 3; i++)
        {
            int ranNum = Random.Range(0, count-3); //��� ������ ����
            Debug.Log(count);

            //UI�� �������� ���� ����ֱ�
            cardType[i].text = datas[ranNum].itemName.ToString();
            cardImage[i].sprite = datas[ranNum].itemIcon;
            cardDesc[i].text = datas[ranNum].itemDesc.ToString();
            //
            cards[i].cardId = ranNum;
            Debug.Log(i+"��° ī�� ���̵�: " + ranNum);
        }

        cardPanel.SetActive(true);
    }

    public void SelectCard() //ī�弱�������� Ÿ�Կ� �´� ���� �ֱ�
    {
        for (int i = 0; i < unitButtons.Length; i++)
        {
            Debug.Log("������ ī�� ���̵�: " + selectId);
            if (unitButtons[i].data.itemType == ItemData.ItemType.Empty)
            {
                unitButtons[i].Init(datas[selectId]);

                Debug.Log("ī������դ���");
                break;
            }
        }


        Time.timeScale = 1f;
        cardPanel.SetActive(false);
    }
}
