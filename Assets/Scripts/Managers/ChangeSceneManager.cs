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

    public void GoToPlayerScene() //�÷��̾� ������ �̵� (�ӽ�)
    {
        SceneManager.LoadScene("PlayerScene");
    }
}
