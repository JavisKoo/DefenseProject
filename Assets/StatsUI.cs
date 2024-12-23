using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour
{
    [SerializeField] GameObject[] statsImage;
    [SerializeField] Button UpgradeButton;




    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StatUpgrade()
    {
        for(int i=0; i < statsImage.Length; i++)
        {
            if (!statsImage[i].activeInHierarchy)
            {
                statsImage[i].SetActive(true);
                return;
            }
        }
        if (statsImage[4].activeInHierarchy)
        {

        }
    }
}
