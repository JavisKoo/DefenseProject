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
    //선택버튼
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
        StageManager.Instance.selectId = toggle.isOn ? cardId : 100;
        selectBtn.SetActive(toggle.isOn); //선택버튼 활성화
    }
}
