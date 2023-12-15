using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Core : MonoBehaviour
{
    public GameObject[] Fruits;
    public bool canMerge = true;
    [Header("Statistics")]
    public static int score = 0;
    public static int fruits = 0;
    [Header("GameObjects")]
    public RestartWindow restartWindow;

    public void ShowRestartWindow()
    {
        canMerge = false; 
        restartWindow.SetScore();
        restartWindow.gameObject.SetActive(true);
    }
    public void Restart()
    {
        score = 0;
        fruits = 0;
        SceneManager.UnloadSceneAsync("Level");
        SceneManager.LoadScene("Level");
    }
}
