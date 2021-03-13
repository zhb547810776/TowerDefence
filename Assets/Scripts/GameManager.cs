using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject endUI;
    public Text endMessage;

    private EnemySpawner enemySpawner;

    private static GameManager instance;
    public static GameManager Instance { get => instance; }

    void Awake()
    {
        instance = this;
        enemySpawner = GetComponent<EnemySpawner>();
    }

    public void Win()
    {
        endUI.SetActive(true);
        endMessage.text = "胜利";
    }

    public void Failed()
    {
        enemySpawner.StopEnemy();
        endUI.SetActive(true);
        endMessage.text = "失败";
    }

    public void OnButtonRetry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnButtonMenu()
    {
        SceneManager.LoadScene(0);
    }
}
