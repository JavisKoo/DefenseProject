using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneManager : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void GoToPlayerScene() //플레이어 씬으로 이동 (임시)
    {
        SceneManager.LoadScene("PlayerScene");
    }
}
