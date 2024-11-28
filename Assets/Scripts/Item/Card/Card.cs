using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public int cardId;
    public ToggleGroup toggleGroup;
    private Toggle toggle;
    private bool isSelect = false;
    //���ù�ư
    public GameObject selectBtn;

    private void Awake()
    {
        toggle = GetComponent<Toggle>();
    }

    private void Start()
    {
        selectBtn.SetActive(false);
        toggle.isOn = false;
    }

    public void OnClickCard()
    {
        if (toggle.isOn) //���õǾ��ٸ�
        {
            StageManager.Instance.selectId = this.cardId;
            selectBtn.SetActive(true); //���ù�ư Ȱ��ȭ
            Debug.Log("��ۼ��õǤӤ�");
        }
        else //���������Ǿ��ٸ�
        {
            StageManager.Instance.selectId = 100;
            selectBtn.SetActive(false); //���ù�ư ��Ȱ��ȭ
            Debug.Log("��ۼ�������");
        }
    }
}
