using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseGameManager : MonoBehaviour
{
    public static BaseGameManager instance = null;


    public float AttackStats=0;
    public float ArmorStats = 0;
    public float HealthStats = 0;



    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
    }



    public void AttackStat()
    {
        Debug.Log(AttackStats);
    }

    public void SaveStats(string UpgradeName)
    {
        PlayerPrefs.SetFloat(UpgradeName, AttackStats);

    }

    public float LoadStats(string UpgradeName)
    {
        if (PlayerPrefs.GetFloat(UpgradeName) != 0)
        {
            return PlayerPrefs.GetFloat(UpgradeName);
        }
        return 0;

    }




}
