using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneUI : MonoBehaviour
{
    public GameObject mapPanel;
    public GameObject upgradePanel;
    public GameObject areaPanel;
    public GameObject dungeonPanel;

    public void OpenUpgradePanel()
    {
        upgradePanel.SetActive(true);
    }

    public void CloseUpgradePanel()
    {
        upgradePanel?.SetActive(false);
    }

    public void OpenAreaPanel()
    {
        areaPanel.SetActive(true);
    }

    public void CloseAreaPanel()
    {
        areaPanel?.SetActive(false);
    }

    public void OpenDungeonPanel()
    {
        dungeonPanel?.SetActive(true);
    }

    public void CloseDungeonPanel()
    {
        dungeonPanel?.SetActive(false);
    }
}
