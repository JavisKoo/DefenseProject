using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneUI : MonoBehaviour
{
    public GameObject mapPanel;
    public GameObject upgradePanel;
    public GameObject areaPanel;
    public GameObject dungeonPanel;

    //dungeon data
    public Dungeon[] dungeonDatas;
    //area
    public Transform areaBase;
    public GameObject[] areaTopUIPrefabs;
    public Image[] areaBossImage;
    public GameObject[] areaClearStar;
    public Text[] areaDungeonNum;

    public void OpenUpgradePanel()
    {
        upgradePanel.SetActive(true);
    }

    public void CloseUpgradePanel()
    {
        upgradePanel?.SetActive(false);
    }

    //
    public void OpenAreaPanel(int type)
    {
        //top
        bool isClearTable = false;
        GameObject go = Instantiate(areaTopUIPrefabs[type]);
        go.transform.SetParent(areaBase,false);
        areaTop areaTopScript = go.GetComponent<areaTop>();
        areaTopScript.isDisable = true;
        //items
        for (int i = 0; i < areaDungeonNum.Length; i++) //스크롤 하나씩 돌음
        {
            
            areaDungeonNum[i].text = (type + 1) + "-" + (i+1);
            switch (type)
            {
                case 0:
                    areaBossImage[i].sprite = dungeonDatas[i].dungeonBoss.itemIcon;
                    isClearTable = dungeonDatas[i].isClear ? true : false;
                    break;

                case 1: //i가 3,4,5여야함
                    areaBossImage[i].sprite = dungeonDatas[i+3].dungeonBoss.itemIcon;
                    isClearTable = dungeonDatas[i+3].isClear ? true : false;
                    break;

                case 2://i가 6,7,8여야함
                    areaBossImage[i].sprite = dungeonDatas[i+6].dungeonBoss.itemIcon;
                    isClearTable = dungeonDatas[i+6].isClear ? true : false;
                    break;

                case 3://i가 9,10,11여야함
                    areaBossImage[i].sprite = dungeonDatas[i+9].dungeonBoss.itemIcon;
                    isClearTable = dungeonDatas[i+9].isClear ? true : false;
                    break;
            }

            areaClearStar[i].SetActive(isClearTable);
        }

        areaPanel.SetActive(true);
    }

    public void CloseAreaPanel()
    {
        areaPanel.SetActive(false);
    }

    public void OpenDungeonPanel()
    {
        CloseAreaPanel();
        dungeonPanel.SetActive(true);
    }

    public void CloseDungeonPanel()
    {
        dungeonPanel.SetActive(false);
    }
}
