using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneUI : MonoBehaviour
{
    public GameObject mapPanel;

    public void OpenMap()
    {
        mapPanel.SetActive(true);
    }

    public void CloseMap()
    {
        mapPanel?.SetActive(false);
    }
}
