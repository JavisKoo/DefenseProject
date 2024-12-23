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
    public GameObject detailBtn;

    private void Awake()
    {
        toggle = GetComponent<Toggle>();
    }

    private void Start()
    {
        selectBtn.SetActive(false);
        detailBtn.SetActive(false);
        toggle.isOn = false;
    }

    public void OnClickCard()
    {
        StageManager.Instance.selectId = toggle.isOn ? cardId : 100;
        selectBtn.SetActive(toggle.isOn); //���ù�ư Ȱ��ȭ
        detailBtn.SetActive(toggle.isOn); //������ ��ư Ȱ��ȭ
    }
}
