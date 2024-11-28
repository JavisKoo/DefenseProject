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
        if (toggle.isOn) //선택되었다면
        {
            StageManager.Instance.selectId = this.cardId;
            selectBtn.SetActive(true); //선택버튼 활성화
            Debug.Log("토글선택되ㅣㅁ");
        }
        else //선택해제되었다면
        {
            StageManager.Instance.selectId = 100;
            selectBtn.SetActive(false); //선택버튼 비활성화
            Debug.Log("토글선택해제");
        }
    }
}
