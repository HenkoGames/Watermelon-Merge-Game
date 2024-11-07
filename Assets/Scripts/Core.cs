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
    public RestartWindow nextLevelWindow;
    public static List<Fruit> activeFruits = new List<Fruit>();
    public static Core instance;
    private void Awake()
    {
        instance = this;
    }
    public void ShowRestartWindow()
    {
        canMerge = false; 
        restartWindow.gameObject.SetActive(true);
        restartWindow.SetScore();
        SoundManager.instance.PlaySound(SoundManager.Sound.fail);

    }
    public void ShowNextLevelWindow()
    {
        canMerge = false;
        nextLevelWindow.gameObject.SetActive(true);
        nextLevelWindow.SetScore();
        SoundManager.instance.PlaySound(SoundManager.Sound.nextLevel);

    }

    public void Restart()
    {
        score = 0;
        fruits = 0;

        SceneManager.UnloadSceneAsync("Level");
        SceneManager.LoadScene("Level");
    }
    public void ClearFruits()
    {
        StartCoroutine(ClearFruitsC());
    }
    private IEnumerator ClearFruitsC()
    {
        canMerge = false;
        foreach (Fruit fruit in Core.activeFruits)
        {
            fruit.DestroyWithVFX();
            yield return new WaitForSeconds(Random.Range(0f,0.5f));
        }
        
    }

}
