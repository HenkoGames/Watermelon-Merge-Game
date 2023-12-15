using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MM_Core : MonoBehaviour
{
    private void Awake()
    {
       Application.targetFrameRate = 60;
    }
    public void StartGame()
    {
        Core.score = 0;
        SceneManager.LoadScene("Level");
        SceneManager.UnloadSceneAsync("MainMenu");
    }
}
