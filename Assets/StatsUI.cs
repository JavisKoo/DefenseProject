using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour
{
    [SerializeField] GameObject[] statsImage;
    [SerializeField] String statName;




    void Start()
    {
        int statCount = PlayerPrefs.GetInt(statName, 0);
        for(int i=0; i < statCount; i++)
        {
            statsImage[i].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        //
    }


    public void StatUpgrade()
    {
        int upgradeSoul = 0;
        for(int i=0; i < statsImage.Length; i++)
        {
            if (!statsImage[i].activeInHierarchy)
            {
               


                statsImage[i].SetActive(true);
                PlayerPrefs.SetInt(statName, i + 1);
                return;
            }
        }
        if (statsImage[4].activeInHierarchy)
        {
            Debug.Log("Max Stats");
        }
    }
}
