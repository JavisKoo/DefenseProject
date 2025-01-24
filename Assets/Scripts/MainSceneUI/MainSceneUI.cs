using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneUI : MonoBehaviour
{
    public GameObject mapPanel;
    public GameObject upgradePanel;

    public void OpenUpgradePanel()
    {
        upgradePanel.SetActive(true);
    }
    public void CloseUpgradePanel()
    {
        upgradePanel?.SetActive(false);
    }
}
